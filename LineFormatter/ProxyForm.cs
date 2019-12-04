using System;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
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
                if (!UseIE && Url == "") return null; // URLがなければ指定しない

                var proxy = UseIE ? WebRequest.GetSystemWebProxy() : new WebProxy(Url);
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

        private void noProxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noProxyCheckBox.Checked) ieCheckBox.Checked = false;
            TextEnabledToggle();
        }

        private void ieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ieCheckBox.Checked) noProxyCheckBox.Checked = false;
            if (ieCheckBox.Checked)
            {
                UrlTxt.Enabled = false; // 設定できないようにする
                UsernameTxt.Enabled = true;
                PasswordTxt.Enabled = true;
            }
            else
            {
                UrlTxt.Enabled = true; // 設定できるようにする
                UsernameTxt.Enabled = true;
                PasswordTxt.Enabled = true;
            }
        }

        private void TextEnabledToggle()
        {
            if (noProxyCheckBox.Checked || ieCheckBox.Checked)
            {
                UrlTxt.Enabled = false; // 設定できないようにする
                UsernameTxt.Enabled = false;
                PasswordTxt.Enabled = false;
            }
            else
            {
                UrlTxt.Enabled = true; // 設定できるようにする
                UsernameTxt.Enabled = true;
                PasswordTxt.Enabled = true;
            }
        }
    }
}
