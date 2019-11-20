using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace LineFormatter
{
    // 翻訳
    class Translation
    {

        private const string TranslationUrl = "https://translate.googleapis.com/translate_a/single";
        public string orig = ""; // オリジナル
        public string trans = ""; // 訳文
        public TextBox tb = null;
        private List<PTrans> pTlist = new List<PTrans>(); // 対訳リスト
        public WebProxy proxy = null; // プロキシ
        public void Translate()
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
            if (proxy != null) wc.Proxy = proxy;

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

            trans = "";
            pTlist.Clear();
            int pos = 0;
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                trans += sentence.trans;
                pTlist.Add(new PTrans(pos, sentence.orig, sentence.trans));
                pos += sentence.trans.Length;
            }

            if (tb != null) tb.Text = trans;
        }

        // 指定位置の対を取得
        public string GetOrig(int pos)
        {
            var l = 0;
            var r = pTlist.Count;
            if (r == 0) return "";
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (pTlist[m].pos <= pos)
                {
                    if (pTlist.Count <= m + 1 || pos < pTlist[m + 1].pos)
                    {
                        return pTlist[m].orig;
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
    }

    // 文章単位対訳
    public class PTrans
    {
        public int pos;
        public string orig;
        public string sentence;
        public PTrans(int pos, string orig, string sentence)
        {
            this.pos = pos;
            this.orig = orig;
            this.sentence = sentence;
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
