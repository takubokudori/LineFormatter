using System;
using System.Collections.Generic;
using System.Text;
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
        public string Orig = ""; // オリジナル
        public string Trans = ""; // 訳文
        public TextBox Tb = null;
        private readonly List<PTrans> _pTList = new List<PTrans>(); // 対訳リスト
        public WebProxy Proxy = null; // プロキシ
        public void Translate()
        {
            var text = System.Web.HttpUtility.UrlEncode(Orig);
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
            if (Proxy != null) wc.Proxy = Proxy;

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

            Trans = "";
            _pTList.Clear();
            var transPos = 0;
            var origPos = 0;
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                Trans += sentence.trans;
                _pTList.Add(new PTrans(origPos, transPos, sentence.orig, sentence.trans));
                transPos += sentence.trans.Length;
                origPos += sentence.orig.Length;
            }

            if (Tb != null) Tb.Text = Trans;
        }

        // 指定位置の対を取得
        public string GetOrig(int pos)
        {
            var l = 0;
            var r = _pTList.Count;
            if (r == 0) return "";
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (_pTList[m].TransPos <= pos)
                {
                    if (_pTList.Count <= m + 1 || pos < _pTList[m + 1].TransPos)
                    {
                        return _pTList[m].Orig;
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
        public int OrigPos; // 原文始点位置
        public string Orig; // 原文
        public int TransPos; // 訳文始点位置
        public string Sentence; // 訳文
        public PTrans(int origPos, int transPos, string orig, string sentence)
        {
            OrigPos = origPos;
            Orig = orig;
            TransPos = transPos;
            Sentence = sentence;
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
