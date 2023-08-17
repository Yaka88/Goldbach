namespace Goldbach
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnPrime = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnEven = new System.Windows.Forms.Button();
            this.txtEvenCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrimePair = new System.Windows.Forms.Button();
            this.btnDecide = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextPrime = new System.Windows.Forms.RichTextBox();
            this.richTextPrimePair = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Even:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(67, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 26);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "1000";
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrime
            // 
            this.btnPrime.Location = new System.Drawing.Point(170, 10);
            this.btnPrime.Name = "btnPrime";
            this.btnPrime.Size = new System.Drawing.Size(140, 30);
            this.btnPrime.TabIndex = 2;
            this.btnPrime.Text = "Prime Collection";
            this.btnPrime.UseVisualStyleBackColor = true;
            this.btnPrime.Click += new System.EventHandler(this.btnPrime_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(380, 12);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(90, 26);
            this.txtCount.TabIndex = 5;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEven
            // 
            this.btnEven.Location = new System.Drawing.Point(1038, 10);
            this.btnEven.Name = "btnEven";
            this.btnEven.Size = new System.Drawing.Size(134, 30);
            this.btnEven.TabIndex = 6;
            this.btnEven.Text = "Even Collection";
            this.btnEven.UseVisualStyleBackColor = true;
            this.btnEven.Click += new System.EventHandler(this.btnEven_Click);
            // 
            // txtEvenCount
            // 
            this.txtEvenCount.Location = new System.Drawing.Point(922, 13);
            this.txtEvenCount.Name = "txtEvenCount";
            this.txtEvenCount.ReadOnly = true;
            this.txtEvenCount.Size = new System.Drawing.Size(111, 26);
            this.txtEvenCount.TabIndex = 8;
            this.txtEvenCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(857, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Result:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(558, 13);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 26);
            this.txtTime.TabIndex = 11;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time(ms):";
            // 
            // btnPrimePair
            // 
            this.btnPrimePair.Location = new System.Drawing.Point(664, 11);
            this.btnPrimePair.Name = "btnPrimePair";
            this.btnPrimePair.Size = new System.Drawing.Size(109, 30);
            this.btnPrimePair.TabIndex = 12;
            this.btnPrimePair.Text = "Prime Pair";
            this.btnPrimePair.UseVisualStyleBackColor = true;
            this.btnPrimePair.Click += new System.EventHandler(this.btnPrimePair_Click);
            // 
            // btnDecide
            // 
            this.btnDecide.Location = new System.Drawing.Point(777, 11);
            this.btnDecide.Name = "btnDecide";
            this.btnDecide.Size = new System.Drawing.Size(74, 30);
            this.btnDecide.TabIndex = 13;
            this.btnDecide.Text = "Decide";
            this.btnDecide.UseVisualStyleBackColor = true;
            this.btnDecide.Click += new System.EventHandler(this.btnDecide_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(1178, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 24);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Senary";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // richTextPrime
            // 
            this.richTextPrime.Location = new System.Drawing.Point(16, 46);
            this.richTextPrime.Name = "richTextPrime";
            this.richTextPrime.ReadOnly = true;
            this.richTextPrime.Size = new System.Drawing.Size(480, 610);
            this.richTextPrime.TabIndex = 15;
            this.richTextPrime.Text = "";
            this.richTextPrime.WordWrap = false;
            // 
            // richTextPrimePair
            // 
            this.richTextPrimePair.Location = new System.Drawing.Point(504, 47);
            this.richTextPrimePair.Name = "richTextPrimePair";
            this.richTextPrimePair.ReadOnly = true;
            this.richTextPrimePair.Size = new System.Drawing.Size(742, 610);
            this.richTextPrimePair.TabIndex = 16;
            this.richTextPrimePair.Text = "";
            this.richTextPrimePair.WordWrap = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.richTextPrimePair);
            this.Controls.Add(this.richTextPrime);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnDecide);
            this.Controls.Add(this.btnPrimePair);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEvenCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEven);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrime);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Goldbach";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnPrime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnEven;
        private System.Windows.Forms.TextBox txtEvenCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrimePair;
        private System.Windows.Forms.Button btnDecide;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextPrime;
        private System.Windows.Forms.RichTextBox richTextPrimePair;
    }
}

