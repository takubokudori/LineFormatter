using System.Windows.Forms;

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
            if (MessageBox.Show(@"選択されているテキストを翻訳します。よろしいですか？
今入力されている変換後のテキストは上書きされます。", @"翻訳", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            foreach (DataGridViewRow row in FixationDGV.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                var t = new Translation();
                var before = (string)row.Cells[1].Value;
                t.DownloadCallbackFunc = Tt =>
                {
                    row.Cells[2].Value = Tt.GetTransText();
                    return Tt.GetTransText();
                };
                t.Translate(before, "en", "ja");
            }
        }
    }
}
