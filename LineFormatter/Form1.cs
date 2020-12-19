using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LineFormatter
{

    public partial class Form1 : Form
    {
        class Rep
        {
            public readonly string Before;
            public readonly string After;
            public readonly string Temp;

            public Rep(string before, string after, string temp)
            {
                Before = before;
                After = after;
                Temp = temp;
            }
        }
        private readonly ProxyForm _proxyForm = new ProxyForm();
        private readonly Translation _trans = new Translation();
        private TranslationText _tt = new TranslationText("", "", new List<PTrans>());
        private readonly FixationForm _fixationForm = new FixationForm();
        private readonly List<Rep> _reps = new List<Rep>();
        private Color _beforeBoxDefaultColor;
        private Color _afterBoxDefaultColor;

        public Form1()
        {
            InitializeComponent();
            FromComboBox.SelectedIndex = 0; // auto
            ToComboBox.SelectedIndex = 0; // ja
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _afterBoxDefaultColor = AfterBox.BackColor;
            _beforeBoxDefaultColor = BeforeBox.BackColor;
        }

        private void FormatBtn_Click(object sender, EventArgs e)
        {
            AutoChangeFunc(() =>
            {
                Formatting();
                return true;
            });
        }

        private static string GenRandomStr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var r = new Random();
            var ret = "";
            for (var i = 0; i < length; i++)
            {
                ret += chars[r.Next(chars.Length)];
            }
            return ret;
        }

        private string ReplaceText(string text)
        {
            const int len = 5;
            var c = text.Split(' ');
            var sList = new HashSet<string>();
            foreach (var x in c)
            {
                if (x.Length == len) sList.Add(x);
            }

            var tList = new HashSet<string>();
            _reps.Clear();
            foreach (DataGridViewRow row in _fixationForm.FixationDGV.Rows)
            {
                var before = (string)row.Cells[1].Value;
                var after = (string)row.Cells[2].Value;
                if (before == null) break;
                string tmp;
                do
                {
                    tmp = GenRandomStr(len);
                } while (sList.Contains(tmp) || tList.Contains(tmp));

                tList.Add(tmp);
                if (string.IsNullOrEmpty(after)) after = before;
                _reps.Add(new Rep(before, after, tmp));
                text = text.Replace(before, tmp);
            }

            return text;
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
            .Replace("。", "。\r\n") // 。(全角)
            .Replace("。\n", "。\r\n")
            .Replace("。\t", "。\r\n")
            .Replace("：", "：\r\n") // ：(全角)
            .Replace("：\n", "：\r\n")
            .Replace("：\t", "：\r\n")
            .Replace("；", "；\r\n") // ；(全角)
            .Replace("；\n", "；\r\n")
            .Replace("；\t", "；\r\n")
            .Replace("！", "！\r\n") // ！(全角)
            .Replace("！\n", "！\r\n")
            .Replace("！\t", "！\r\n")
            .Replace("？", "？\r\n") // ？(全角)
            .Replace("？\n", "？\r\n")
            .Replace("？\t", "？\r\n")
            .Replace("Fig.\r\n", "Fig. ") // 図
            .Replace("etc.\r\n", "etc. ") // 等
            .Replace("e.g.\r\n", "e.g. ") // 例
            .Replace("i.e.\r\n", "i.e. ") // つまり
            .Replace("c.f.\r\n", "c.f. ") // 参照
            .Replace("et al.\r\n", "et al ") // 著者ら
            .Replace("et al,.\r\n", "et al ");
            text = Regex.Replace(text, "\\d(\\d|\\.)*?\\.((\r??\n)|$)", // 1. 11. 1.1.
                match => match.Value.TrimEnd('\r', '\n') + " ",
                RegexOptions.Compiled);
            return text;
        }

        private void BeforeBox_TextChanged(object sender, EventArgs e)
        {
            StopDrawingFunc(BeforeBox, bfb =>
            {
                if (isAutoFormat.Checked)
                {
                    var temp = BeforeBox.SelectionStart; // 整形でキャレット位置がずれるのを防ぐ
                    Formatting();
                    BeforeBox.SelectionStart = temp;
                }
                if (isAutoTranslation.Checked)
                {
                    TranslationTimer.Stop();
                    TranslationTimer.Enabled = true;
                    TranslationTimer.Interval = 500;
                    TranslationTimer.Start();
                }

                SelectionFunc(BeforeBox, x =>
                {
                    x.SelectionBackColor = Color.White;
                    x.SelectionFont = x.Font; // 元のフォントに戻す
                    return true;
                });
                return true;
            });

            BeforeLenLbl.Text = $@"原文: {BeforeBox.TextLength} 文字";
        }

        private void Translate(string orig)
        {
            var OrigText = ReplaceText(orig);
            _trans.TransTextCallbackFunc = transText =>
            {
                foreach (var rep in _reps)
                {
                    transText = transText.Replace(rep.Temp, rep.After);
                }

                return transText;
            };
            _trans.OrigTextCallbackFunc = origText =>
            {
                foreach (var rep in _reps)
                {
                    origText = origText.Replace(rep.Temp, rep.Before);
                }

                return origText;
            };
            _trans.DownloadCallbackFunc = tt =>
            {
                AfterBox.Text = tt.GetTransText();
                _tt = tt;
                // 履歴に追加
                HistoryCmbBox.Items.Insert(0, tt);
                // 直近30個のみ保存し、それ以上は削除
                if (HistoryCmbBox.Items.Count >= 30)
                {
                    HistoryCmbBox.Items.RemoveAt(HistoryCmbBox.Items.Count - 1);
                }
                return AfterBox.Text;
            };
            var fromLang = ((string)FromComboBox.SelectedItem).Split(',')[0];
            var toLang = ((string)ToComboBox.SelectedItem).Split(',')[0];
            _trans.Translate(OrigText, fromLang, toLang);
        }

        private void TranslateBtn_Click(object sender, EventArgs e)
        {
            AutoChangeFunc(() =>
            {
                Translate(BeforeBox.Text);
                return true;
            });
        }

        private void TranslationTimer_Tick(object sender, EventArgs e)
        {
            Translate(BeforeBox.Text);
            TranslationTimer.Enabled = false;
        }

        private void ProxyBtn_Click(object sender, EventArgs e)
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

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            AutoChangeFunc(() =>
            {
                var x = AfterBox.Font.Size + 2;
                if (x >= 100) return true;
                AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
                BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
                return true;
            });
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            AutoChangeFunc(() =>
            {
                var x = AfterBox.Font.Size - 2;
                if (x <= 0) return true;
                AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
                BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
                return true;
            });
        }

        private void BeforeBox_Click(object sender, EventArgs e)
        {
            // 対訳ハイライト
            var pt = _tt.GetTrans(BeforeBox.SelectionStart);
            if (pt == null) return;
            StopDrawingFunc(BeforeBox, bfb =>
            {
                StopDrawingFunc(AfterBox, afb =>
                {
                    bfb.TextChanged -= BeforeBox_TextChanged; // 自動整形と競合するので一旦ハンドラを外す
                    afb.TextChanged -= AfterBox_TextChanged;

                    ClearSelectionBackColor(bfb, _beforeBoxDefaultColor, true);
                    HighlightPt(bfb, pt.OrigPos, pt.OrigText.Length, true);
                    ClearSelectionBackColor(afb, _afterBoxDefaultColor, true);
                    HighlightPt(afb, pt.TransPos, pt.TransText.Length);
                    afb.SelectionLength = 0; // 選択解除
                    afb.ScrollToCaret();
                    bfb.Focus(); // フォーカスを戻す

                    afb.TextChanged += AfterBox_TextChanged;
                    bfb.TextChanged += BeforeBox_TextChanged;
                    return true;
                });
                return true;
            });
        }

        private void AfterBox_Click(object sender, EventArgs e)
        {
            // 対訳ハイライト
            var pt = _tt.GetOrig(AfterBox.SelectionStart);
            if (pt == null) return;
            StopDrawingFunc(BeforeBox, bfb =>
            {
                StopDrawingFunc(AfterBox, afb =>
                {
                    bfb.TextChanged -= BeforeBox_TextChanged; // 自動整形と競合するので一旦ハンドラを外す
                    afb.TextChanged -= AfterBox_TextChanged;

                    ClearSelectionBackColor(afb, _afterBoxDefaultColor, true);
                    HighlightPt(afb, pt.TransPos, pt.TransText.Length, true);
                    ClearSelectionBackColor(bfb, _beforeBoxDefaultColor, true);
                    HighlightPt(bfb, pt.OrigPos, pt.OrigText.Length);
                    bfb.SelectionLength = 0; // 選択解除
                    bfb.ScrollToCaret();
                    afb.Focus(); // フォーカスを戻す

                    afb.TextChanged += AfterBox_TextChanged;
                    bfb.TextChanged += BeforeBox_TextChanged;

                    return true;
                });
                return true;
            });
        }

        private static void ClearSelectionBackColor(RichTextBox rtb, Color color, bool isStay = false)
        {
            Highlight(rtb, 0, rtb.TextLength, color, isStay);
        }

        // 対訳ハイライト
        private void HighlightPt(RichTextBox rtb, int pos, int len, bool isStay = false)
        {
            Highlight(rtb, pos, len, PtColorDialog.Color, isStay);
        }

        private static void Highlight(RichTextBox rtb, int pos, int len, Color color, bool isStay = false)
        {
            // rtbがフォーカスされていないと失敗する
            SelectionFunc(rtb, x =>
            {
                x.SelectionStart = pos;
                x.SelectionLength = len;
                x.SelectionBackColor = color; // ハイライト
                return true;
            }, isStay, false);
        }

        private void PColorBtn_Click(object sender, EventArgs e)
        {
            PtColorDialog.ShowDialog();
        }

        private void AfterBox_TextChanged(object sender, EventArgs e)
        {
            AfterLenLbl.Text = $@"訳文: {AfterBox.TextLength} 文字";
        }

        private void searchWithGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AfterBox.SelectedText == "") return;
            System.Diagnostics.Process.Start($"https://google.com/search?q={System.Web.HttpUtility.UrlEncode(AfterBox.SelectedText)}");
        }

        private void searchWithGoogleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (BeforeBox.SelectedText == "") return;
            System.Diagnostics.Process.Start($"https://google.com/search?q={System.Web.HttpUtility.UrlEncode(BeforeBox.SelectedText)}");
        }

        private void AfterBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control || e.KeyCode != Keys.G) return;
            // Ctrl+Gで検索
            searchWithGoogleToolStripMenuItem_Click(sender, e);
            e.SuppressKeyPress = true;
        }

        private void BeforeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control || e.KeyCode != Keys.G) return;
            // Ctrl+Gで検索
            searchWithGoogleToolStripMenuItem1_Click(sender, e);
            e.SuppressKeyPress = true;
        }

        /// <summary>
        /// 指定した
        /// </summary>
        /// <param name="rtb">RichTextBox</param>
        /// <param name="callbackFunc">コールバック</param>
        /// <param name="isStay">trueの場合、選択箇所を元に戻す</param>
        /// <param name="isAll">全選択</param>
        private static void SelectionFunc(RichTextBox rtb, Func<RichTextBox, bool> callbackFunc, bool isStay = true, bool isAll = true)
        {
            rtb.Focus();
            var start = rtb.SelectionStart;
            var length = rtb.SelectionLength;
            if (isAll)
            {
                // 全選択
                rtb.SelectionStart = 0;
                rtb.SelectionLength = rtb.TextLength;
            }
            callbackFunc(rtb);
            if (!isStay) return;
            // 選択を元に戻す
            rtb.SelectionStart = start;
            rtb.SelectionLength = length;
        }

        private static void StopDrawingFunc(RichTextBox rtb, Func<RichTextBox, bool> callbackFunc)
        {
            WinApi.StopDrawing(rtb);
            callbackFunc(rtb);
            WinApi.StartDrawing(rtb);
        }

        private static void StopDrawingFunc2(Control ctrl, Func<bool> callbackFunc)
        {
            WinApi.StopDrawing(ctrl);
            callbackFunc();
            WinApi.StartDrawing(ctrl);
        }

        private void FixationBtn_Click(object sender, EventArgs e)
        {
            _fixationForm.Show();
        }

        private void FixationTSMI_Click(object sender, EventArgs e)
        {
            var text = BeforeBox.SelectedText.Trim();
            if (text == "") return;
            _fixationForm.FixationDGV.Rows.Add(false, text, "");
        }

        // BeforeBoxの内容が変化したときに自動整形や自動翻訳が暴発するのを防ぐコールバック
        private void AutoChangeFunc(Func<bool> callbackFunc)
        {
            StopDrawingFunc2(isAutoFormat, () =>
            {
                StopDrawingFunc2(isAutoTranslation, () =>
                 {
                     var isAf = isAutoFormat.Checked;
                     var isAt = isAutoTranslation.Checked;
                     isAutoFormat.Checked = false; // 内容を壊さないように一時的に切る
                     isAutoTranslation.Checked = false;
                     callbackFunc();
                     isAutoFormat.Checked = isAf;
                     isAutoTranslation.Checked = isAt;
                     return true;
                 });
                return true;
            });
        }

        private void HistoryCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 指定した翻訳文をコピー

            var isAF = isAutoFormat.Checked;
            var isAT = isAutoTranslation.Checked;
            isAutoFormat.Checked = false; // 内容を壊さないように一時的に切る
            isAutoTranslation.Checked = false;
            var x = (TranslationText)HistoryCmbBox.SelectedItem;
            _tt = x;
            BeforeBox.Text = _tt.GetOrigText();
            AfterBox.Text = _tt.GetTransText();
            isAutoFormat.Checked = isAF;
            isAutoTranslation.Checked = isAT;
        }

        private void LangSwapBtn_Click(object sender, EventArgs e)
        {
            var t = FromComboBox.SelectedIndex;
            if (t == 0)
            {
                // 翻訳元がautoの場合は何もしない
                return;
            }
            FromComboBox.SelectedIndex = ToComboBox.SelectedIndex + 1;
            ToComboBox.SelectedIndex = t - 1;
        }

        private void FromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 翻訳前と翻訳後が同じ言語の場合は翻訳後を日本語にする
            // ただし翻訳前が日本語の場合は英語にする
            var from = FromComboBox.SelectedIndex;
            var to = ToComboBox.SelectedIndex;
            if (from == 0) return; // autoなら何もしない
            from--; // Fromのほうはautoが含まれるために番号が1多いので1引く
            if (from == 0 && to == 0)
            { // 両方とも日本語の場合は翻訳後を英語にする
                ToComboBox.SelectedIndex = 1;
                return;
            }
            // 同じ言語(日本語以外)の場合は日本語にする
            if (from == to)
            {
                ToComboBox.SelectedIndex = 0; // 日本語
            }
        }

        private void ToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 翻訳前と翻訳後が同じ言語の場合は翻訳前を日本語にする
            // ただし翻訳後が日本語の場合はautoにする
            var from = FromComboBox.SelectedIndex;
            var to = ToComboBox.SelectedIndex;
            if (from == 0) return; // autoなら何もしない
            from--; // Fromのほうはautoが含まれるために番号が1多いので1引く
            if (from == 0 && to == 0)
            { // 両方とも日本語の場合は翻訳前をautoにする
                FromComboBox.SelectedIndex = 0;
                return;
            }
            // 同じ言語(日本語以外)の場合は日本語にする
            if (from == to)
            {
                FromComboBox.SelectedIndex = 1; // 日本語
            }

        }
    }
}
