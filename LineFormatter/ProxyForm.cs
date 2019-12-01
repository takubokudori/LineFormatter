using System;
using System.Windows.Forms;

namespace LineFormatter
{
    public partial class ProxyForm : Form
    {
        public string Url = "";
        public string Username = "";
        public string Password = "";
        public ProxyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Url = UrlTxt.Text;
            Username = UsernameTxt.Text;
            Password = PasswordTxt.Text;
            Hide();

        }
    }
}
