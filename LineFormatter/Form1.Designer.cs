namespace LineFormatter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.isAutoFormat = new System.Windows.Forms.CheckBox();
            this.isAutoTranslation = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TranslationTimer = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.Lbtn = new System.Windows.Forms.Button();
            this.Rbtn = new System.Windows.Forms.Button();
            this.origTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinusBtn = new System.Windows.Forms.Button();
            this.PlusBtn = new System.Windows.Forms.Button();
            this.BeforeBox = new System.Windows.Forms.RichTextBox();
            this.AfterBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.AfterBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BeforeBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 488);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::LineFormatter.Resource1.arrow;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(399, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 482);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(12, 27);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(214, 24);
            this.TitleLbl.TabIndex = 2;
            this.TitleLbl.Text = "LineFormatter v1.1.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "整形";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // isAutoFormat
            // 
            this.isAutoFormat.AutoSize = true;
            this.isAutoFormat.Checked = true;
            this.isAutoFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoFormat.Location = new System.Drawing.Point(490, 13);
            this.isAutoFormat.Name = "isAutoFormat";
            this.isAutoFormat.Size = new System.Drawing.Size(138, 28);
            this.isAutoFormat.TabIndex = 4;
            this.isAutoFormat.Text = "自動整形";
            this.isAutoFormat.UseVisualStyleBackColor = true;
            // 
            // isAutoTranslation
            // 
            this.isAutoTranslation.AutoSize = true;
            this.isAutoTranslation.Checked = true;
            this.isAutoTranslation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoTranslation.Location = new System.Drawing.Point(490, 47);
            this.isAutoTranslation.Name = "isAutoTranslation";
            this.isAutoTranslation.Size = new System.Drawing.Size(138, 28);
            this.isAutoTranslation.TabIndex = 5;
            this.isAutoTranslation.Text = "自動翻訳";
            this.isAutoTranslation.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(781, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 47);
            this.button2.TabIndex = 6;
            this.button2.Text = "翻訳";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TranslationTimer
            // 
            this.TranslationTimer.Interval = 2000;
            this.TranslationTimer.Tick += new System.EventHandler(this.TranslationTimer_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(357, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 47);
            this.button3.TabIndex = 7;
            this.button3.Text = "プロキシ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Lbtn
            // 
            this.Lbtn.Location = new System.Drawing.Point(357, 76);
            this.Lbtn.Name = "Lbtn";
            this.Lbtn.Size = new System.Drawing.Size(37, 38);
            this.Lbtn.TabIndex = 8;
            this.Lbtn.Text = "←";
            this.Lbtn.UseVisualStyleBackColor = true;
            this.Lbtn.Click += new System.EventHandler(this.LBtn_Click);
            // 
            // Rbtn
            // 
            this.Rbtn.Location = new System.Drawing.Point(437, 76);
            this.Rbtn.Name = "Rbtn";
            this.Rbtn.Size = new System.Drawing.Size(37, 38);
            this.Rbtn.TabIndex = 9;
            this.Rbtn.Text = "→";
            this.Rbtn.UseVisualStyleBackColor = true;
            this.Rbtn.Click += new System.EventHandler(this.RBtn_Click);
            // 
            // origTextBox
            // 
            this.origTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.origTextBox.Location = new System.Drawing.Point(16, 138);
            this.origTextBox.Multiline = true;
            this.origTextBox.Name = "origTextBox";
            this.origTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.origTextBox.Size = new System.Drawing.Size(873, 58);
            this.origTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "比率:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "文字サイズ:";
            // 
            // MinusBtn
            // 
            this.MinusBtn.Location = new System.Drawing.Point(781, 76);
            this.MinusBtn.Name = "MinusBtn";
            this.MinusBtn.Size = new System.Drawing.Size(37, 38);
            this.MinusBtn.TabIndex = 13;
            this.MinusBtn.Text = "-";
            this.MinusBtn.UseVisualStyleBackColor = true;
            this.MinusBtn.Click += new System.EventHandler(this.MinusBtn_Click);
            // 
            // PlusBtn
            // 
            this.PlusBtn.Location = new System.Drawing.Point(861, 76);
            this.PlusBtn.Name = "PlusBtn";
            this.PlusBtn.Size = new System.Drawing.Size(37, 38);
            this.PlusBtn.TabIndex = 14;
            this.PlusBtn.Text = "+";
            this.PlusBtn.UseVisualStyleBackColor = true;
            this.PlusBtn.Click += new System.EventHandler(this.PlusBtn_Click);
            // 
            // BeforeBox
            // 
            this.BeforeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeforeBox.Location = new System.Drawing.Point(3, 3);
            this.BeforeBox.Name = "BeforeBox";
            this.BeforeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.BeforeBox.Size = new System.Drawing.Size(390, 482);
            this.BeforeBox.TabIndex = 3;
            this.BeforeBox.Text = "";
            this.BeforeBox.Click += new System.EventHandler(this.BeforeBox_Click);
            this.BeforeBox.TextChanged += new System.EventHandler(this.BeforeBox_TextChanged);
            // 
            // AfterBox
            // 
            this.AfterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AfterBox.Location = new System.Drawing.Point(487, 3);
            this.AfterBox.Name = "AfterBox";
            this.AfterBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.AfterBox.Size = new System.Drawing.Size(390, 482);
            this.AfterBox.TabIndex = 4;
            this.AfterBox.Text = "";
            this.AfterBox.Click += new System.EventHandler(this.AfterBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 702);
            this.Controls.Add(this.PlusBtn);
            this.Controls.Add(this.MinusBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.origTextBox);
            this.Controls.Add(this.Rbtn);
            this.Controls.Add(this.Lbtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.isAutoTranslation);
            this.Controls.Add(this.isAutoFormat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "LineFormatter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox isAutoFormat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox isAutoTranslation;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer TranslationTimer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Lbtn;
        private System.Windows.Forms.Button Rbtn;
        private System.Windows.Forms.TextBox origTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MinusBtn;
        private System.Windows.Forms.Button PlusBtn;
        private System.Windows.Forms.RichTextBox AfterBox;
        private System.Windows.Forms.RichTextBox BeforeBox;
    }
}

