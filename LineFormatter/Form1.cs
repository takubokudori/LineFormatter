using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;

namespace LineFormatter
{

    public partial class Form1 : Form
    {
        private List<PTrans> _tlist = new List<PTrans>();
        private const string TranslationUrl = "https://translate.googleapis.com/translate_a/single";
        private ProxyForm _proxyForm = new ProxyForm();

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
            BeforeBox.Text = BeforeBox.Text
            .Replace("\r", "") // CRLF
            .Replace("\n", " ")
            .Replace("  ", " ") // 冗長な空白
            .Replace(". ", ".\r\n") // .
            .Replace(".\n", ".\r\n")
            .Replace(".\t", ".\r\n")
            .Replace("! ", "!\r\n") // !
            .Replace("!\n", "!\r\n")
            .Replace("!\t", "!\r\n")
            .Replace("? ", "?\r\n") // ?
            .Replace("?\n", "?\r\n")
            .Replace("?\t", "?\r\n")
            .Replace("Fig.\r\n", "Fig. ") // 図
            .Replace("et al.\r\n", "et al. ") // 著者ら
            .Replace("et al,.\r\n", "et al. ");
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
            var text = System.Web.HttpUtility.UrlEncode(orig);
            if (text == "") return;
            var wc = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            wc.Headers.Add("Host", "translate.googleapis.com");
            wc.Headers.Add("User-Agent",
                "GoogleTranslate/5.9.59004 (iPhone; iOS 10.2; ja; iPhone9,1)");
            wc.Headers.Add("Accept", "*/*");
            wc.Headers.Add("Accept-Language", "ja-JP,en-US,*");
            if (_proxyForm.Url != "")
            {
                var proxy = new WebProxy(_proxyForm.Url);
                if (_proxyForm.Username != "")
                {
                    proxy.Credentials = new NetworkCredential(_proxyForm.Username, _proxyForm.Password);
                    wc.Proxy = proxy;
                }
            }

            wc.DownloadStringCompleted += CompleteDownloadProc1;
            wc.DownloadStringAsync(
                new Uri(TranslationUrl +
                        "?client=it" +
                        "&sl=en" +
                        "&tl=ja" +
                        "&dt=t" +
                        "&ie=UTF-8" +
                        "&oe=UTF-8" +
                        "&dj=1" +
                        "&otf=2" +
                        "&q=" + text));
        }

        public void CompleteDownloadProc1(Object sender, DownloadStringCompletedEventArgs e)
        {
            GTransResp res;
            var serializer =
                new DataContractJsonSerializer(typeof(GTransResp));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result)))
            {
                res = (GTransResp)serializer.ReadObject(ms);
            }

            AfterBox.Text = "";
            _tlist.Clear();
            int pos = 0;
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                AfterBox.Text += sentence.trans;
                _tlist.Add(new PTrans(pos, sentence.orig, sentence.trans));
                pos += sentence.trans.Length;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Translate(AfterBox.Text);
        }

        private void TranslationTimer_Tick(object sender, EventArgs e)
        {
            Translate(AfterBox.Text);
            TranslationTimer.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _proxyForm.Show();
        }

        private void Lbtn_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnStyles[0].Width <= 5) return;
            tableLayoutPanel1.ColumnStyles[0].Width -= 5;
            tableLayoutPanel1.ColumnStyles[2].Width += 5;
        }

        private void Rbtn_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnStyles[2].Width <= 5) return;
            tableLayoutPanel1.ColumnStyles[0].Width += 5;
            tableLayoutPanel1.ColumnStyles[2].Width -= 5;
        }

        // 指定位置の対を取得
        public string GetOrig(int pos)
        {
            var l = 0;
            var r = _tlist.Count;
            if (r == 0) return "";
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (_tlist[m].pos <= pos)
                {
                    if (_tlist.Count <= m + 1 || pos < _tlist[m + 1].pos)
                    {
                        return _tlist[m].orig;
                    }

                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            return "";
        }

        private void AfterBox_Click(object sender, EventArgs e)
        {
            origTextBox.Text = GetOrig(AfterBox.SelectionStart);
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size + 2;
            if (x >= 100) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size - 2;
            if (x <= 0) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
        }
    }

    public class ModelTracking
    {
        public string checkpoint_md5 { get; set; }
        public string launch_doc { get; set; }
    }

    public class TranslationEngineDebugInfo
    {
        public ModelTracking model_tracking { get; set; }
    }

    public class Sentence
    {
        public string trans { get; set; }
        public string orig { get; set; }
        public int backend { get; set; }
        public List<TranslationEngineDebugInfo> translation_engine_debug_info { get; set; }
    }

    public class GTransResp
    {
        public List<Sentence> sentences { get; set; }
        public string src { get; set; }
    }


}
