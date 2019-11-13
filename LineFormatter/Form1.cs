using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;

namespace LineFormatter
{

    public partial class Form1 : Form
    {
        const string TranslationUrl = "https://translate.googleapis.com/translate_a/single";
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
            AfterBox.Text = BeforeBox.Text
            .Replace("\r", "") // CRLF
            .Replace("\n", " ")
            .Replace("  ", " ") // 冗長な空白
            .Replace(". ", ".\r\n")
            .Replace(".\n", ".\r\n")
            .Replace(".\t", ".\r\n")
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

        private void Translate()
        {
            var text = System.Web.HttpUtility.UrlEncode(AfterBox.Text);
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

            try
            {
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
            catch (WebException)
            {
                MessageBox.Show(@"Failed to google");
            }
            catch (SocketException)
            {
                MessageBox.Show(@"エラーが発生しました");
            }
            catch (TargetInvocationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CompleteDownloadProc1(Object sender, DownloadStringCompletedEventArgs e)
        {
            Translation res;
            var serializer =
                new DataContractJsonSerializer(typeof(Translation));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result)))
            {
                res = (Translation)serializer.ReadObject(ms);
            }

            AfterBox.Text = "";
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                AfterBox.Text += sentence.trans;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Translate();
        }

        private void TranslationTimer_Tick(object sender, EventArgs e)
        {
            Translate();
            TranslationTimer.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _proxyForm.Show();
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

    public class Translation
    {
        public List<Sentence> sentences { get; set; }
        public string src { get; set; }
    }
}
