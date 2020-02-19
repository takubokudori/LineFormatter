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
            this.ReplaceDGV = new System.Windows.Forms.DataGridView();
            this.BeforeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReplaceDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ReplaceDGV
            // 
            this.ReplaceDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReplaceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReplaceDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BeforeCol,
            this.AfterCol});
            this.ReplaceDGV.Location = new System.Drawing.Point(12, 12);
            this.ReplaceDGV.Name = "ReplaceDGV";
            this.ReplaceDGV.RowHeadersWidth = 82;
            this.ReplaceDGV.RowTemplate.Height = 33;
            this.ReplaceDGV.Size = new System.Drawing.Size(776, 233);
            this.ReplaceDGV.TabIndex = 0;
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
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ReplaceDGV);
            this.Name = "ReplaceForm";
            this.Text = "ReplaceForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ReplaceDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView ReplaceDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeforeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfterCol;
        private System.Windows.Forms.Button CloseBtn;
    }
}