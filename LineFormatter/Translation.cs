﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace LineFormatter
{
    // 翻訳
    public class Translation
    {
        private const string TranslationUrl = "https://translate.googleapis.com/translate_a/single";
        public string OrigText = ""; // オリジナル
        public string TransText = ""; // 訳文
        public Func<string, string> DownloadCallbackFunc = null;
        public Func<string, string> TransTextCallbackFunc = null;
        public Func<string, string> OrigTextCallbackFunc = null;
        private readonly List<PTrans> _pTList = new List<PTrans>(); // 対訳リスト
        public IWebProxy Proxy = null; // プロキシ
        public void Translate()
        {
            var text = System.Web.HttpUtility.UrlEncode(OrigText);
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

            TransText = "";
            _pTList.Clear();
            var transPos = 0;
            var origPos = 0;
            OrigText = "";
            if (res?.sentences == null) return;
            foreach (var sentence in res.sentences)
            {
                var oText = sentence.orig;
                var tText = sentence.trans;
                oText = OrigTextCallbackFunc?.Invoke(oText);
                tText = TransTextCallbackFunc?.Invoke(tText);
                if (oText == null || tText == null) break;
                OrigText += oText;
                TransText += tText;
                for (; OrigText[origPos] != sentence.orig[0]; origPos++) { } // 先頭の空白がtrimされるのでその分位置をずらす
                _pTList.Add(new PTrans(origPos, transPos, oText, tText));
                transPos += tText.Length;
                origPos += oText.Length;
            }

            DownloadCallbackFunc?.Invoke(TransText);
        }

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

        public string GetOrigText(int pos)
        {
            return GetOrig(pos)?.OrigText ?? "";
        }

        public string GetTransText(int pos)
        {
            return GetTrans(pos)?.TransText ?? "";
        }

        public int GetOrigPos(int pos)
        {
            return GetOrig(pos)?.OrigPos ?? 0;
        }

        public int GetTransPos(int pos)
        {
            return GetTrans(pos)?.TransPos ?? 0;
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
}
