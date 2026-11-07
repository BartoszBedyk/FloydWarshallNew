namespace FloydWarshallNew
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.loadTimeLabel = new System.Windows.Forms.Label();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.lastResult = new System.Windows.Forms.Label();
            this.newestResult = new System.Windows.Forms.Label();
            this.complexity = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.benchmarkChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearChatButton = new System.Windows.Forms.Button();
            this.graphDensity = new System.Windows.Forms.ComboBox();
            this.startTextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.findRoute = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.benchmarkChart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "32 wierzchołki";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Załaduj dane";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 86);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "64 wierzchołki";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 122);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "128 wierzchołków";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 158);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "256 wiechołków";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(19, 193);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 31);
            this.button5.TabIndex = 5;
            this.button5.Text = "512 wierzchołki";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // loadTimeLabel
            // 
            this.loadTimeLabel.AutoSize = true;
            this.loadTimeLabel.Location = new System.Drawing.Point(285, 22);
            this.loadTimeLabel.Name = "loadTimeLabel";
            this.loadTimeLabel.Size = new System.Drawing.Size(137, 16);
            this.loadTimeLabel.TabIndex = 6;
            this.loadTimeLabel.Text = "Załadowano dane w: ";
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.Location = new System.Drawing.Point(289, 62);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1037, 833);
            this.graphPanel.TabIndex = 7;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint_1);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseMove);
            // 
            // lastResult
            // 
            this.lastResult.AutoSize = true;
            this.lastResult.Location = new System.Drawing.Point(16, 372);
            this.lastResult.Name = "lastResult";
            this.lastResult.Size = new System.Drawing.Size(119, 16);
            this.lastResult.TabIndex = 8;
            this.lastResult.Text = "Poprzedni pomiar :";
            // 
            // newestResult
            // 
            this.newestResult.AutoSize = true;
            this.newestResult.Location = new System.Drawing.Point(15, 400);
            this.newestResult.Name = "newestResult";
            this.newestResult.Size = new System.Drawing.Size(120, 16);
            this.newestResult.TabIndex = 9;
            this.newestResult.Text = "Najnowszy pomiar:";
            // 
            // complexity
            // 
            this.complexity.AutoSize = true;
            this.complexity.Location = new System.Drawing.Point(641, 22);
            this.complexity.Name = "complexity";
            this.complexity.Size = new System.Drawing.Size(159, 16);
            this.complexity.TabIndex = 10;
            this.complexity.Text = "Złożoność obliczeniowa: ";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(16, 278);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(156, 36);
            this.calculateButton.TabIndex = 11;
            this.calculateButton.Text = "Wywołaj algorytm";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // benchmarkChart
            // 
            chartArea1.Name = "ChartArea1";
            this.benchmarkChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.benchmarkChart.Legends.Add(legend1);
            this.benchmarkChart.Location = new System.Drawing.Point(12, 431);
            this.benchmarkChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.benchmarkChart.Name = "benchmarkChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.benchmarkChart.Series.Add(series1);
            this.benchmarkChart.Size = new System.Drawing.Size(272, 279);
            this.benchmarkChart.TabIndex = 12;
            this.benchmarkChart.Text = "chart1";
            // 
            // clearChatButton
            // 
            this.clearChatButton.Location = new System.Drawing.Point(16, 320);
            this.clearChatButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearChatButton.Name = "clearChatButton";
            this.clearChatButton.Size = new System.Drawing.Size(156, 36);
            this.clearChatButton.TabIndex = 13;
            this.clearChatButton.Text = "Wyczyść wykres";
            this.clearChatButton.UseVisualStyleBackColor = true;
            this.clearChatButton.Click += new System.EventHandler(this.clearChatButton_Click);
            // 
            // graphDensity
            // 
            this.graphDensity.FormattingEnabled = true;
            this.graphDensity.Location = new System.Drawing.Point(20, 230);
            this.graphDensity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphDensity.Name = "graphDensity";
            this.graphDensity.Size = new System.Drawing.Size(160, 24);
            this.graphDensity.TabIndex = 14;
            // 
            // startTextBox
            // 
            this.startTextBox.Location = new System.Drawing.Point(20, 739);
            this.startTextBox.Name = "startTextBox";
            this.startTextBox.Size = new System.Drawing.Size(100, 22);
            this.startTextBox.TabIndex = 15;
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(20, 778);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(100, 22);
            this.endTextBox.TabIndex = 16;
            // 
            // findRoute
            // 
            this.findRoute.Location = new System.Drawing.Point(20, 824);
            this.findRoute.Name = "findRoute";
            this.findRoute.Size = new System.Drawing.Size(75, 23);
            this.findRoute.TabIndex = 17;
            this.findRoute.Text = "Znajdź trase";
            this.findRoute.UseVisualStyleBackColor = true;
            this.findRoute.Click += new System.EventHandler(this.findRoute_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(25, 869);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(16, 16);
            this.resultLabel.TabIndex = 18;
            this.resultLabel.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 908);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.findRoute);
            this.Controls.Add(this.endTextBox);
            this.Controls.Add(this.startTextBox);
            this.Controls.Add(this.graphDensity);
            this.Controls.Add(this.clearChatButton);
            this.Controls.Add(this.benchmarkChart);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.complexity);
            this.Controls.Add(this.newestResult);
            this.Controls.Add(this.lastResult);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.loadTimeLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.benchmarkChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label loadTimeLabel;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label lastResult;
        private System.Windows.Forms.Label newestResult;
        private System.Windows.Forms.Label complexity;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart benchmarkChart;
        private System.Windows.Forms.Button clearChatButton;
        private System.Windows.Forms.ComboBox graphDensity;
        private System.Windows.Forms.TextBox startTextBox;
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.Button findRoute;
        private System.Windows.Forms.Label resultLabel;
    }
}

