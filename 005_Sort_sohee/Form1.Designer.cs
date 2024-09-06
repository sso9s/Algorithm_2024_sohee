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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.txtBubble = new System.Windows.Forms.Label();
            this.txtQuick = new System.Windows.Forms.Label();
            this.txtMerge = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터 갯수";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(174, 87);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 25);
            this.txtInput.TabIndex = 1;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(315, 87);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(126, 25);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "랜덤 숫자 생성";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(459, 87);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(106, 25);
            this.btnTime.TabIndex = 3;
            this.btnTime.Text = "시간 측정";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // txtBubble
            // 
            this.txtBubble.AutoSize = true;
            this.txtBubble.Location = new System.Drawing.Point(89, 152);
            this.txtBubble.Name = "txtBubble";
            this.txtBubble.Size = new System.Drawing.Size(0, 15);
            this.txtBubble.TabIndex = 4;
            // 
            // txtQuick
            // 
            this.txtQuick.AutoSize = true;
            this.txtQuick.Location = new System.Drawing.Point(89, 194);
            this.txtQuick.Name = "txtQuick";
            this.txtQuick.Size = new System.Drawing.Size(0, 15);
            this.txtQuick.TabIndex = 5;
            // 
            // txtMerge
            // 
            this.txtMerge.AutoSize = true;
            this.txtMerge.Location = new System.Drawing.Point(89, 233);
            this.txtMerge.Name = "txtMerge";
            this.txtMerge.Size = new System.Drawing.Size(0, 15);
            this.txtMerge.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 290);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(473, 254);
            this.textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 608);
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
    }
}

