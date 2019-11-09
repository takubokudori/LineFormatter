using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;

namespace LineFormatter
{
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

    public partial class Form1 : Form
    {
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
            var a = BeforeBox.Text.Replace("\r", "").Replace("\n", " ").Replace("  ", " ");
            AfterBox.Text = a.Replace(". ", ".\r\n").Replace(".\n", ".\r\n").Replace(".\t", ".\r\n");
        }

        private void BeforeBox_TextChanged(object sender, EventArgs e)
        {
            if (isAutoFormat.Checked) Formatting();
            if (isAutoTranslation.Checked) Translate();
        }

        private void Translate()
        {
            string text = System.Web.HttpUtility.UrlEncode(AfterBox.Text);
            string url = "https://translate.googleapis.com/translate_a/single";
            WebClient wc = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            wc.Headers.Add("Host", "translate.googleapis.com");
            wc.Headers.Add("User-Agent",
                "GoogleTranslate/5.9.59004 (iPhone; iOS 10.2; ja; iPhone9,1)");
            wc.Headers.Add("Accept", "*/*");
            wc.Headers.Add("Accept-Language", "ja-JP,en-US,*");
            try
            {
                wc.DownloadStringCompleted += CompleteDownloadProc1;
                wc.DownloadStringAsync(
                    new Uri(url +
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
            catch (WebException e)
            {
                MessageBox.Show(@"Failed to google");
            }
        }

        public void CompleteDownloadProc1(Object sender, DownloadStringCompletedEventArgs e)
        {
            Translation res;
            var serializer =
                new DataContractJsonSerializer(typeof(Translation));
            using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(e.Result)))
            {
                res = (Translation) serializer.ReadObject(ms);
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
    }
}

