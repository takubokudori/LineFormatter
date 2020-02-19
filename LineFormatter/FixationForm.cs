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
    }
}
