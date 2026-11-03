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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            ((System.ComponentModel.ISupportInitialize)(this.benchmarkChart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 41);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "32 wierzchołki";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Załaduj dane";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 70);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "64 wierzchołki";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 99);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "128 wierzchołków";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 128);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 25);
            this.button4.TabIndex = 4;
            this.button4.Text = "256 wiechołków";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 157);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 25);
            this.button5.TabIndex = 5;
            this.button5.Text = "512 wierzchołki";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // loadTimeLabel
            // 
            this.loadTimeLabel.AutoSize = true;
            this.loadTimeLabel.Location = new System.Drawing.Point(214, 18);
            this.loadTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.loadTimeLabel.Name = "loadTimeLabel";
            this.loadTimeLabel.Size = new System.Drawing.Size(112, 13);
            this.loadTimeLabel.TabIndex = 6;
            this.loadTimeLabel.Text = "Załadowano dane w: ";
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.Location = new System.Drawing.Point(217, 50);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(2);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(778, 526);
            this.graphPanel.TabIndex = 7;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint_1);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseMove);
            // 
            // lastResult
            // 
            this.lastResult.AutoSize = true;
            this.lastResult.Location = new System.Drawing.Point(12, 302);
            this.lastResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastResult.Name = "lastResult";
            this.lastResult.Size = new System.Drawing.Size(94, 13);
            this.lastResult.TabIndex = 8;
            this.lastResult.Text = "Poprzedni pomiar :";
            // 
            // newestResult
            // 
            this.newestResult.AutoSize = true;
            this.newestResult.Location = new System.Drawing.Point(11, 325);
            this.newestResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.newestResult.Name = "newestResult";
            this.newestResult.Size = new System.Drawing.Size(95, 13);
            this.newestResult.TabIndex = 9;
            this.newestResult.Text = "Najnowszy pomiar:";
            // 
            // complexity
            // 
            this.complexity.AutoSize = true;
            this.complexity.Location = new System.Drawing.Point(481, 18);
            this.complexity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.complexity.Name = "complexity";
            this.complexity.Size = new System.Drawing.Size(128, 13);
            this.complexity.TabIndex = 10;
            this.complexity.Text = "Złożoność obliczeniowa: ";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(12, 226);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(2);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(117, 29);
            this.calculateButton.TabIndex = 11;
            this.calculateButton.Text = "Wywołaj algorytm";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // benchmarkChart
            // 
            chartArea5.Name = "ChartArea1";
            this.benchmarkChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.benchmarkChart.Legends.Add(legend5);
            this.benchmarkChart.Location = new System.Drawing.Point(9, 350);
            this.benchmarkChart.Margin = new System.Windows.Forms.Padding(2);
            this.benchmarkChart.Name = "benchmarkChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.benchmarkChart.Series.Add(series5);
            this.benchmarkChart.Size = new System.Drawing.Size(204, 227);
            this.benchmarkChart.TabIndex = 12;
            this.benchmarkChart.Text = "chart1";
            // 
            // clearChatButton
            // 
            this.clearChatButton.Location = new System.Drawing.Point(12, 260);
            this.clearChatButton.Name = "clearChatButton";
            this.clearChatButton.Size = new System.Drawing.Size(117, 29);
            this.clearChatButton.TabIndex = 13;
            this.clearChatButton.Text = "Wyczyść wykres";
            this.clearChatButton.UseVisualStyleBackColor = true;
            this.clearChatButton.Click += new System.EventHandler(this.clearChatButton_Click);
            // 
            // graphDensity
            // 
            this.graphDensity.FormattingEnabled = true;
            this.graphDensity.Location = new System.Drawing.Point(15, 187);
            this.graphDensity.Name = "graphDensity";
            this.graphDensity.Size = new System.Drawing.Size(121, 21);
            this.graphDensity.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 587);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

