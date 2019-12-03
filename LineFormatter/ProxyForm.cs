using System;
using System.Net;
using System.Windows.Forms;

namespace LineFormatter
{
    public partial class ProxyForm : Form
    {
        public string Url = "";
        public string Username = "";
        public string Password = "";

        public bool UseIE => ieCheckBox.Checked;
        public bool NoProxy => noProxyCheckBox.Checked;

        public IWebProxy Proxy
        {
            get
            {
                if (NoProxy) return null; //プロキシを使用しない
                if (UseIE) return WebRequest.GetSystemWebProxy(); // システムプロキシを使用する
                if (Url == "") return null; // URLがなければ指定しない
                var proxy = new WebProxy(Url);
                if (Username != "")
                {
                    proxy.Credentials = new NetworkCredential(Username, Password);
                }
                return proxy;

            }
        }
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
