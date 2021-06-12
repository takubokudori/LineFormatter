/*
Copyright 2021 takubokudori

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
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
