namespace LineFormatter
{
    partial class ProxyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UrlTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ieCheckBox = new System.Windows.Forms.CheckBox();
            this.noProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // UrlTxt
            // 
            this.UrlTxt.Enabled = false;
            this.UrlTxt.Location = new System.Drawing.Point(155, 54);
            this.UrlTxt.Name = "UrlTxt";
            this.UrlTxt.Size = new System.Drawing.Size(308, 31);
            this.UrlTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Enabled = false;
            this.UsernameTxt.Location = new System.Drawing.Point(155, 114);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(308, 31);
            this.UsernameTxt.TabIndex = 3;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Enabled = false;
            this.PasswordTxt.Location = new System.Drawing.Point(155, 176);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(308, 31);
            this.PasswordTxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ieCheckBox
            // 
            this.ieCheckBox.AutoSize = true;
            this.ieCheckBox.Checked = true;
            this.ieCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ieCheckBox.Location = new System.Drawing.Point(27, 224);
            this.ieCheckBox.Name = "ieCheckBox";
            this.ieCheckBox.Size = new System.Drawing.Size(234, 28);
            this.ieCheckBox.TabIndex = 7;
            this.ieCheckBox.Text = "IEの設定を使用する";
            this.ieCheckBox.UseVisualStyleBackColor = true;
            this.ieCheckBox.CheckedChanged += new System.EventHandler(this.ieCheckBox_CheckedChanged);
            // 
            // noProxyCheckBox
            // 
            this.noProxyCheckBox.AutoSize = true;
            this.noProxyCheckBox.Location = new System.Drawing.Point(27, 278);
            this.noProxyCheckBox.Name = "noProxyCheckBox";
            this.noProxyCheckBox.Size = new System.Drawing.Size(241, 28);
            this.noProxyCheckBox.TabIndex = 8;
            this.noProxyCheckBox.Text = "プロキシを使用しない";
            this.noProxyCheckBox.UseVisualStyleBackColor = true;
            this.noProxyCheckBox.CheckedChanged += new System.EventHandler(this.noProxyCheckBox_CheckedChanged);
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 351);
            this.Controls.Add(this.noProxyCheckBox);
            this.Controls.Add(this.ieCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UrlTxt);
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrlTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ieCheckBox;
        private System.Windows.Forms.CheckBox noProxyCheckBox;
    }
}