/*
Copyright 2021 takubokudori

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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace LineFormatter
{
    // 翻訳
    public class Translation
    {
        private const string TranslationUrl = "https://translate.googleapis.com/translate_a/single";
        public Func<TranslationText, string> DownloadCallbackFunc = null;
        public Func<string, string> TransTextCallbackFunc = null;
        public Func<string, string> OrigTextCallbackFunc = null;
        private TranslationText _tt;

        public static IWebProxy Proxy = null; // プロキシ

        public void Translate(string origText, string fromLang, string toLang)
        {
            var text = System.Web.HttpUtility.UrlEncode(origText);
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
            wc.Proxy = Proxy;

            wc.DownloadStringCompleted += CompleteDownloadProc1;
            wc.DownloadStringAsync(
                new Uri(TranslationUrl +
                        "?client=it" +
                        "&sl=" + fromLang +
                        "&tl=" + toLang +
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

            var transText = "";
            var ptList = new List<PTrans>();
            var transPos = 0;
            var origPos = 0;
            var origText = "";
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                var oText = sentence.orig;
                var tText = sentence.trans;
                oText = OrigTextCallbackFunc == null ? oText : OrigTextCallbackFunc(oText);
                tText = TransTextCallbackFunc == null ? tText : TransTextCallbackFunc(tText);
                if (oText == null || tText == null) break;
                origText += oText;
                transText += tText;
                ptList.Add(new PTrans(origPos, transPos, oText, tText));
                origPos += oText.Length * 2 - oText.TrimStart().Length; // 先頭空白による位置ずれ調整
                transPos += tText.Length;
            }

            _tt = new TranslationText(origText, transText, ptList);

            DownloadCallbackFunc?.Invoke(_tt);
        }
    }

    // 文章単位対訳
    public class PTrans
    {
        public int OrigPos; // 原文始点位置
        public string OrigText; // 原文
        public int TransPos; // 訳文始点位置
        public string TransText; // 訳文
        public PTrans(int origPos, int transPos, string origText, string transText)
        {
            OrigPos = origPos;
            OrigText = origText;
            TransPos = transPos;
            TransText = transText;
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

    public class TranslationText
    {
        private string OrigText = ""; // オリジナル
        private string TransText = ""; // 訳文
        private readonly List<PTrans> _pTList = new List<PTrans>(); // 対訳リスト

        public TranslationText(string OrigText, string TransText, List<PTrans> _pTList)
        {
            this.OrigText = OrigText;
            this.TransText = TransText;
            this._pTList = _pTList;
        }

        public string GetOrigText() { return OrigText; }

        public string GetTransText() { return TransText; }

        // 指定位置の対を取得
        public PTrans GetOrig(int pos)
        {
            var l = 0;
            var r = _pTList.Count;
            if (r == 0) return null; // リストが空の場合
            if (pos < 0) return _pTList[0]; // posが負の場合
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (_pTList[m].TransPos <= pos)
                {
                    if (_pTList.Count <= m + 1 || pos < _pTList[m + 1].TransPos)
                    {
                        return _pTList[m];
                    }

                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            return _pTList[_pTList.Count - 1];
        }

        public PTrans GetTrans(int pos)
        {
            var l = 0;
            var r = _pTList.Count;
            if (r == 0) return null; // リストが空の場合
            if (pos < 0) return _pTList[0]; // posが負の場合
            while (l <= r)
            {
                var m = (l + r) / 2;
                if (_pTList[m].OrigPos <= pos)
                {
                    if (_pTList.Count <= m + 1 || pos < _pTList[m + 1].OrigPos)
                    {
                        return _pTList[m];
                    }

                    l = m;
                }
                else
                {
                    r = m;
                }
            }

            return _pTList[_pTList.Count - 1];
        }

        // 訳文を最大100文字プレビュー
        public override string ToString()
        {
            var x = TransText.Length < 100 ? TransText.Length : 100;
            return TransText.Substring(0, x);
        }
    }
}
