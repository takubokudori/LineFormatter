using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LineFormatter
{

    public partial class Form1 : Form
    {
        private readonly ProxyForm _proxyForm = new ProxyForm();
        private readonly Translation _trans = new Translation();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formatting();
        }

        private void Formatting()
        {
            BeforeBox.Text = Format(BeforeBox.Text);
        }

        public static string Format(string text)
        {
            text = text
            .Replace("\r", "") // CRLF
            .Replace("\n", " ")
            .Replace("  ", " ") // 冗長な空白
            .Replace(". ", ".\r\n") // .
            .Replace(".\n", ".\r\n")
            .Replace(".\t", ".\r\n")
            .Replace(": ", ":\r\n") // :
            .Replace(":\n", ":\r\n")
            .Replace(":\t", ":\r\n")
            .Replace("; ", ";\r\n") // ;
            .Replace(";\n", ";\r\n")
            .Replace(";\t", ";\r\n")
            .Replace("! ", "!\r\n") // !
            .Replace("!\n", "!\r\n")
            .Replace("!\t", "!\r\n")
            .Replace("? ", "?\r\n") // ?
            .Replace("?\n", "?\r\n")
            .Replace("?\t", "?\r\n")
            .Replace("Fig.\r\n", "Fig. ") // 図
            .Replace("etc.\r\n", "etc. ") // 等
            .Replace("e.g.\r\n", "e.g. ") // 例
            .Replace("et al.\r\n", "et al. ") // 著者ら
            .Replace("et al,.\r\n", "et al. ");
            text = Regex.Replace(text, "\\d(\\d|\\.)*?\\.((\r??\n)|$)", // 1. 11. 1.1.
                match => match.Value.TrimEnd('\r', '\n') + " ",
                RegexOptions.Compiled);
            return text;
        }

        private void BeforeBox_TextChanged(object sender, EventArgs e)
        {
            if (isAutoFormat.Checked) Formatting();
            if (isAutoTranslation.Checked)
            {
                TranslationTimer.Stop();
                TranslationTimer.Enabled = true;
                TranslationTimer.Interval = 500;
                TranslationTimer.Start();
            }
        }

        private void Translate(string orig)
        {
            if (_proxyForm.Url != "")
            {
                var proxy = new WebProxy(_proxyForm.Url);
                if (_proxyForm.Username != "")
                {
                    proxy.Credentials = new NetworkCredential(_proxyForm.Username, _proxyForm.Password);
                }
                _trans.Proxy = proxy;
            }
            else _trans.Proxy = null;

            _trans.Orig = orig;
            _trans.Tb = AfterBox;
            _trans.Translate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Translate(BeforeBox.Text);
        }

        private void TranslationTimer_Tick(object sender, EventArgs e)
        {
            Translate(BeforeBox.Text);
            TranslationTimer.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _proxyForm.Show();
        }

        private void LBtn_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnStyles[0].Width <= 5) return;
            tableLayoutPanel1.ColumnStyles[0].Width -= 5;
            tableLayoutPanel1.ColumnStyles[2].Width += 5;
        }

        private void RBtn_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnStyles[2].Width <= 5) return;
            tableLayoutPanel1.ColumnStyles[0].Width += 5;
            tableLayoutPanel1.ColumnStyles[2].Width -= 5;
        }

        private void AfterBox_Click(object sender, EventArgs e)
        {
            origTextBox.Text = _trans.GetOrig(AfterBox.SelectionStart);
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size + 2;
            if (x >= 100) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
            BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
            origTextBox.Font = new Font(origTextBox.Font.OriginalFontName, x);
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size - 2;
            if (x <= 0) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
            BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
            origTextBox.Font = new Font(origTextBox.Font.OriginalFontName, x);
        }

        private void BeforeBox_Click(object sender, EventArgs e)
        {
            origTextBox.Text = _trans.GetTrans(BeforeBox.SelectionStart);
        }
    }

}
