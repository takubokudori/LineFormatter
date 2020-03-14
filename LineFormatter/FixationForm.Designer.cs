namespace LineFormatter
{
    partial class FixationForm
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
            this.FixationDGV = new System.Windows.Forms.DataGridView();
            this.CheckCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BeforeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.TransBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FixationDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // FixationDGV
            // 
            this.FixationDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FixationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FixationDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckCol,
            this.BeforeCol,
            this.AfterCol});
            this.FixationDGV.Location = new System.Drawing.Point(12, 12);
            this.FixationDGV.Name = "FixationDGV";
            this.FixationDGV.RowHeadersWidth = 82;
            this.FixationDGV.RowTemplate.Height = 33;
            this.FixationDGV.Size = new System.Drawing.Size(776, 233);
            this.FixationDGV.TabIndex = 0;
            // 
            // CheckCol
            // 
            this.CheckCol.HeaderText = "チェック";
            this.CheckCol.MinimumWidth = 10;
            this.CheckCol.Name = "CheckCol";
            this.CheckCol.Width = 60;
            // 
            // BeforeCol
            // 
            this.BeforeCol.HeaderText = "変換前";
            this.BeforeCol.MinimumWidth = 10;
            this.BeforeCol.Name = "BeforeCol";
            this.BeforeCol.Width = 140;
            // 
            // AfterCol
            // 
            this.AfterCol.HeaderText = "変換後";
            this.AfterCol.MinimumWidth = 10;
            this.AfterCol.Name = "AfterCol";
            this.AfterCol.Width = 140;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(611, 264);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(125, 53);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "閉じる";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // TransBtn
            // 
            this.TransBtn.Location = new System.Drawing.Point(441, 264);
            this.TransBtn.Name = "TransBtn";
            this.TransBtn.Size = new System.Drawing.Size(110, 53);
            this.TransBtn.TabIndex = 2;
            this.TransBtn.Text = "翻訳";
            this.TransBtn.UseVisualStyleBackColor = true;
            this.TransBtn.Click += new System.EventHandler(this.TransBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(280, 264);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(110, 53);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "削除";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // FixationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.TransBtn);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.FixationDGV);
            this.Name = "FixationForm";
            this.Text = "FixationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FixationDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView FixationDGV;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button TransBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeforeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfterCol;
    }
}