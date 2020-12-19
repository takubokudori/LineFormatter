/*
Copyright 2020 takubokudori

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
            Translation.Proxy = Proxy;
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

        private void ProxyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; // 閉じるときにオブジェクトを破棄しない
        }
    }
}
