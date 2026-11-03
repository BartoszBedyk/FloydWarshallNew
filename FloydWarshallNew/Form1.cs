using AlgorytmyStrukturyDanych1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FloydWarshallNew
{
    public partial class Form1 : Form, IMessageFilter
    {
        private readonly Pen edgePen = new Pen(Color.Black, 2);
        private readonly Font weightFont = new Font("Arial", 9, FontStyle.Regular);

        private readonly Pen hoveredEdgePen = new Pen(Color.Red, 3);
        private readonly Font hoveredWeightFont = new Font("Arial", 10, FontStyle.Bold);
        private Edge hoveredEdge = null;

        private float zoom = 1.0f;
        private const float MinZoom = 0.2f;
        private const float MaxZoom = 5.0f;

        private PointF panOffset = PointF.Empty;
        private bool isDragging;
        private Point lastMousePosition;

        private readonly Dictionary<int, Point> nodePositions = new Dictionary<int, Point>();
        private Graph currentGraph;

        private const int WM_MOUSEWHEEL = 0x020A;
        private bool messageFilterRegistered;

        List<LastTest> lastTests = new List<LastTest>();

        public Form1()
        {
            InitializeComponent();

            graphDensity.Items.AddRange(new object[] { "Rzadki", "Średni", "Gęsty" });
            graphDensity.SelectedIndex = 0;


            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, graphPanel, new object[] { true });

            graphPanel.MouseDown += graphPanel_MouseDown;
            graphPanel.MouseMove += graphPanel_MouseMove;
            graphPanel.MouseUp += graphPanel_MouseUp;
            graphPanel.MouseCaptureChanged += graphPanel_MouseCaptureChanged;

            graphPanel.MouseLeave += (s, e) => {
                if (hoveredEdge != null)
                {
                    hoveredEdge = null;
                    graphPanel.Cursor = Cursors.Cross;
                    graphPanel.Invalidate();
                }
            };

            graphPanel.Cursor = Cursors.Cross;

            Application.AddMessageFilter(this);
            messageFilterRegistered = true;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_MOUSEWHEEL ||
                graphPanel.IsDisposed ||
                !graphPanel.IsHandleCreated ||
                !graphPanel.Visible ||
                !graphPanel.Enabled)
            {
                return false;
            }

            long packedPosition = m.LParam.ToInt64();
            int screenX = unchecked((short)(packedPosition & 0xFFFF));
            int screenY = unchecked((short)((packedPosition >> 16) & 0xFFFF));
            Point panelPosition = graphPanel.PointToClient(new Point(screenX, screenY));

            if (!graphPanel.ClientRectangle.Contains(panelPosition))
                return false;

            int delta = unchecked((short)((m.WParam.ToInt64() >> 16) & 0xFFFF));
            if (delta == 0)
                return false;

            ZoomGraph(panelPosition, delta);

            return true;
        }

        private void ZoomGraph(Point mousePosition, int delta)
        {
            float oldZoom = zoom;
            float wheelSteps = delta / 120f;
            float factor = (float)Math.Pow(1.15, wheelSteps);
            float newZoom = oldZoom * factor;

            newZoom = Math.Max(MinZoom, Math.Min(MaxZoom, newZoom));

            if (Math.Abs(newZoom - oldZoom) < 0.0001f)
                return;

            zoom = newZoom;
            float ratio = zoom / oldZoom;

            panOffset.X = mousePosition.X - (mousePosition.X - panOffset.X) * ratio;
            panOffset.Y = mousePosition.Y - (mousePosition.Y - panOffset.Y) * ratio;

            graphPanel.Invalidate();
        }

        private string FormDensityGet()
        {
            string density = graphDensity.SelectedItem.ToString();

            if (density == "Rzadki")
            {
                return "graf_rzadki_";
            }
            else if (density == "Średni")
            {
                return "graf_sredni_";
            }
            else if (density == "Gęsty")
            {
                return "graf_gesty_";
            }

            return "graf_rzadki_";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuildAndDrawGraph(32, FormDensityGet() + "32.csv");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuildAndDrawGraph(64, FormDensityGet() + "64.csv");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuildAndDrawGraph(128, FormDensityGet() + "128.csv");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuildAndDrawGraph(256, FormDensityGet() + "256.csv");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BuildAndDrawGraph(512, FormDensityGet() + "512.csv");
        }

        private void BuildAndDrawGraph(int graphSize, string csvFile)
        {
            currentGraph = BuildNewGraph(graphSize, false);
            currentGraph.size = graphSize;

            loadTimeLabel.Text = "Ładowanie...";
            loadTimeLabel.Refresh();

            //List<(int, int, int)> allEdges = PrepareEdgesForPush("edges_1k.csv");
            //List<(int, int, int)> allEdges = PrepareEdgesForPush("graf_rzadki_16.csv");
            //List<(int, int, int)> allEdges = PrepareEdgesForPush("graf_sredni_16.csv");
            List<(int, int, int)> allEdges = PrepareEdgesForPush(csvFile);

            List<(int, int, int)> edges = allEdges
                .FindAll(edge => edge.Item1 < graphSize && edge.Item2 < graphSize);

            double loadTime = AddEdgesFromCsvAndMeasure(edges, currentGraph);

            GenerateNodePositions(graphSize, 400, 300, 400);
            ResetGraphView();

            loadTimeLabel.Text = $"Załadowane dane w: {loadTime} ms";
            graphPanel.Focus();
            graphPanel.Invalidate();
        }


        private void GenerateNodePositions(int count, int centerX, int centerY, int radius)
        {
            nodePositions.Clear();

            for (int i = 0; i < count; i++)
            {
                double angle = i * 2 * Math.PI / count;

                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));

                nodePositions[i] = new Point(x, y);
            }
        }

        private void DrawGraph(Graph graphToDraw, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

           
            foreach (Edge edge in graphToDraw.GetEdges())
            {
                if (edge == hoveredEdge) continue;

                if (!nodePositions.ContainsKey(edge.from) || !nodePositions.ContainsKey(edge.to))
                    continue;

                Point p1 = nodePositions[edge.from];
                Point p2 = nodePositions[edge.to];

                g.DrawLine(edgePen, p1, p2);
                DrawEdgeWeight(g, p1, p2, edge.distance.ToString(), weightFont, Brushes.White, System.Drawing.Color.DarkRed);
            }

            const int nodeRadius = 15;
            foreach (KeyValuePair<int, Point> node in nodePositions)
            {
                int id = node.Key;
                Point point = node.Value;

                Rectangle rectangle = new Rectangle(
                    point.X - nodeRadius,
                    point.Y - nodeRadius,
                    nodeRadius * 2,
                    nodeRadius * 2);

                g.FillEllipse(Brushes.CornflowerBlue, rectangle);
                g.DrawEllipse(Pens.DarkBlue, rectangle);

                string idText = id.ToString();
                SizeF idSize = g.MeasureString(idText, weightFont);

                g.DrawString(
                    idText,
                    weightFont,
                    Brushes.White,
                    point.X - idSize.Width / 2,
                    point.Y - idSize.Height / 2);
            }

            if (hoveredEdge != null &&
                nodePositions.ContainsKey(hoveredEdge.from) &&
                nodePositions.ContainsKey(hoveredEdge.to))
            {
                Point p1 = nodePositions[hoveredEdge.from];
                Point p2 = nodePositions[hoveredEdge.to];

                g.DrawLine(hoveredEdgePen, p1, p2);
                DrawEdgeWeight(g, p1, p2, hoveredEdge.distance.ToString(), hoveredWeightFont, Brushes.Yellow, Color.Red);
            }
        }


        private void DrawEdgeWeight(Graphics g, Point p1, Point p2, string text, Font font, Brush backgroundBrush, Color textColor)
        {
            int midX = (p1.X + p2.X) / 2;
            int midY = (p1.Y + p2.Y) / 2;

            SizeF textSize = g.MeasureString(text, font);
            float textX = midX - textSize.Width / 2;
            float textY = midY - textSize.Height / 2;

            g.FillRectangle(backgroundBrush, textX, textY, textSize.Width, textSize.Height);

            using (Brush textBrush = new SolidBrush(textColor))
            {
                g.DrawString(text, font, textBrush, textX, textY);
            }
        }

        private static Graph BuildNewGraph(int size, bool directed)
        {
            return new Graph(size, directed);
        }

        private static List<(int, int, int)> PrepareEdgesForPush(string path)
        {
            string fullPath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                path);

            return BenchmarkTools.LoadEdgesFromCsv(fullPath);
        }

        private static double AddEdgesFromCsvAndMeasure(
            List<(int, int, int)> data,
            Graph graph)
        {
            double emptyLoopTime = BenchmarkTools.MeasureTime(() =>
            {
                for (int i = 0; i < data.Count; i++)
                {
                    // Pomiar narzutu pustej pętli.
                }
            });

            double timeTaken = BenchmarkTools.MeasureTime(() =>
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Item1 < graph.vertexCount &&
                        data[i].Item2 < graph.vertexCount)
                    {
                        graph.AddEdge(
                            data[i].Item1,
                            data[i].Item2,
                            data[i].Item3);
                    }
                }
            });

            double finalTime = timeTaken - emptyLoopTime;

            Console.WriteLine($"Dodano elementy do grafu. Czas: {finalTime} ms");

            return finalTime;
        }

        private void graphPanel_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(graphPanel.BackColor);

            if (currentGraph == null)
                return;

            GraphicsState state = e.Graphics.Save();

            try
            {
                using (Matrix transform = new Matrix(
                    zoom, 0,
                    0, zoom,
                    panOffset.X, panOffset.Y))
                {
                    e.Graphics.Transform = transform;
                    DrawGraph(currentGraph, e);
                }
            }
            finally
            {
                e.Graphics.Restore(state);
            }
        }


        private void graphPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            graphPanel.Focus();
            isDragging = true;
            lastMousePosition = e.Location;

            graphPanel.Capture = true;
            graphPanel.Cursor = Cursors.Hand;
        }

        private void graphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                panOffset.X += e.X - lastMousePosition.X;
                panOffset.Y += e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;
                graphPanel.Invalidate();
                return;
            }


            Edge newHoveredEdge = FindEdgeUnderMouse(e.Location);
            if (newHoveredEdge != hoveredEdge)
            {
                hoveredEdge = newHoveredEdge;
                graphPanel.Cursor = hoveredEdge != null ? Cursors.Hand : Cursors.Cross;
                graphPanel.Invalidate();
            }
        }

        private Edge FindEdgeUnderMouse(System.Drawing.Point screenLocation)
        {
            if (currentGraph == null)
                return null;


            float worldX = (screenLocation.X - panOffset.X) / zoom;
            float worldY = (screenLocation.Y - panOffset.Y) / zoom;
            PointF mouseWorld = new PointF(worldX, worldY);

            const float tolerance = 6.0f;

            foreach (Edge edge in currentGraph.GetEdges())
            {
                if (!nodePositions.ContainsKey(edge.from) || !nodePositions.ContainsKey(edge.to))
                    continue;

                Point p1 = nodePositions[edge.from];
                Point p2 = nodePositions[edge.to];

                if (IsPointNearLineSegment(mouseWorld, p1, p2, tolerance))
                {
                    return edge;
                }
            }

            return null;
        }

        private bool IsPointNearLineSegment(PointF p, Point a, Point b, float tolerance)
        {
            float l2 = (b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y);
            if (l2 == 0) return Distance(p, a) <= tolerance;

            float t = ((p.X - a.X) * (b.X - a.X) + (p.Y - a.Y) * (b.Y - a.Y)) / l2;
            t = Math.Max(0, Math.Min(1, t));

            PointF projection = new PointF(a.X + t * (b.X - a.X), a.Y + t * (b.Y - a.Y));
            return Distance(p, projection) <= tolerance;
        }

        private float Distance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void graphPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isDragging = false;
            graphPanel.Capture = false;
            graphPanel.Cursor = Cursors.Cross;
        }

        private void graphPanel_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (!graphPanel.Capture)
            {
                isDragging = false;
                graphPanel.Cursor = Cursors.Cross;
            }
        }

        private void ResetGraphView()
        {
            zoom = 1.0f;
            panOffset = PointF.Empty;

            graphPanel.Invalidate();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if(currentGraph == null)
            {
                MessageBox.Show("Przed wywołaniem algorytmu należy załadować dane do grafu.");
                return;
            }

            int[,] matrix = currentGraph.toDistanceMatrix();

            double algorithmTime = BenchmarkTools.MeasureTime(() =>
            {
                FloydWarshall.FloydWarshallAlgorithm(matrix);
            });

            lastTests.Add(new LastTest(currentGraph.size, algorithmTime));

            if (newestResult.Text != "Najnowszy pomiar:")
            {
                lastResult.Text = newestResult.Text;
            }

            newestResult.Text = $"Najnowszy pomiar: {algorithmTime}";



            if (lastTests.Count >= 2)
            {
                Double complexityNumber = 0.0;
            string complexityName = "";

                complexityNumber =  BenchmarkTools.NewCalclateComplexity(
                    lastTests[lastTests.Count - 1],
                    lastTests[lastTests.Count - 2]
                );

                complexityName = BenchmarkTools.EstimateComplexityName(complexityNumber);
                complexity.Text = $"Złożoność obliczeniowa: {complexityName} lub {complexityNumber.ToString()}";
            }

            GenerateChart(lastTests);

        }

        private void GenerateChart(List<LastTest> tests)
        {
            benchmarkChart.Series.Clear();
            benchmarkChart.Legends.Clear();

            var chartArea = benchmarkChart.ChartAreas[0];

            chartArea.AxisX.CustomLabels.Clear();
            chartArea.AxisX.LabelStyle.Enabled = true;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Minimum = 0.5;
            chartArea.AxisX.Maximum = tests.Count + 0.5;

            var series = benchmarkChart.Series.Add("Czas wykonania");

            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.IsXValueIndexed = true;

            var sortedTests = tests.OrderBy(x => x.size).ToList();

            for (int i = 0; i < sortedTests.Count; i++)
            {
                var test = sortedTests[i];

                series.Points.AddXY(i + 1, test.timeTaken);

                chartArea.AxisX.CustomLabels.Add(
                    i + 0.5,
                    i + 1.5,
                    test.size.ToString()
                );
            }

            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.Interval = 1;
            chartArea.AxisX.MajorTickMark.Interval = 1;

            chartArea.AxisX.Title = "Rozmiar danych";
            chartArea.AxisY.Title = "Czas wykonania";

            chartArea.AxisY.IsStartedFromZero = true;
        }

        private void clearChatButton_Click(object sender, EventArgs e)
        {
            currentGraph = null;

            benchmarkChart.Series.Clear();
            benchmarkChart.Legends.Clear();
            lastTests.Clear();

            graphPanel.Invalidate();
        }
    }

}
