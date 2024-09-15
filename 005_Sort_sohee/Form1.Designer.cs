namespace _005_Sort_sohee
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.txtBubble = new System.Windows.Forms.Label();
            this.txtQuick = new System.Windows.Forms.Label();
            this.txtMerge = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터 갯수 :";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(156, 64);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 25);
            this.txtInput.TabIndex = 1;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(353, 58);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(126, 36);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "랜덤 숫자 생성";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(497, 58);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(106, 36);
            this.btnTime.TabIndex = 3;
            this.btnTime.Text = "시간 측정";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // txtBubble
            // 
            this.txtBubble.AutoSize = true;
            this.txtBubble.Location = new System.Drawing.Point(662, 77);
            this.txtBubble.Name = "txtBubble";
            this.txtBubble.Size = new System.Drawing.Size(0, 15);
            this.txtBubble.TabIndex = 4;
            // 
            // txtQuick
            // 
            this.txtQuick.AutoSize = true;
            this.txtQuick.Location = new System.Drawing.Point(662, 119);
            this.txtQuick.Name = "txtQuick";
            this.txtQuick.Size = new System.Drawing.Size(0, 15);
            this.txtQuick.TabIndex = 5;
            // 
            // txtMerge
            // 
            this.txtMerge.AutoSize = true;
            this.txtMerge.Location = new System.Drawing.Point(662, 158);
            this.txtMerge.Name = "txtMerge";
            this.txtMerge.Size = new System.Drawing.Size(0, 15);
            this.txtMerge.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(556, 463);
            this.textBox1.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(651, 190);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(578, 392);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 632);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtMerge);
            this.Controls.Add(this.txtQuick);
            this.Controls.Add(this.txtBubble);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Label txtBubble;
        private System.Windows.Forms.Label txtQuick;
        private System.Windows.Forms.Label txtMerge;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

