﻿using System.Windows.Forms;

namespace LineFormatter
{
    public partial class FixationForm : Form
    {
        public FixationForm()
        {
            InitializeComponent();
        }

        private void ReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; // 閉じるときにオブジェクトを破棄しない
        }

        private void CloseBtn_Click(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void TransBtn_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(@"選択されているテキストを翻訳します。よろしいですか？", @"翻訳", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            foreach (DataGridViewRow row in FixationDGV.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    MessageBox.Show(@"翻訳");
                }
            }
        }
    }
}