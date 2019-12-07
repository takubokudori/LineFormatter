using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LineFormatter
{

    public partial class Form1 : Form
    {
        private readonly ProxyForm _proxyForm = new ProxyForm();
        private readonly Translation _trans = new Translation();
        private Color _beforeBoxDefaultColor;
        private Color _afterBoxDefaultColor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _afterBoxDefaultColor = AfterBox.BackColor;
            _beforeBoxDefaultColor = BeforeBox.BackColor;
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
            _trans.Proxy = _proxyForm.Proxy;

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

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size + 2;
            if (x >= 100) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
            BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            var x = AfterBox.Font.Size - 2;
            if (x <= 0) return;
            AfterBox.Font = new Font(AfterBox.Font.OriginalFontName, x);
            BeforeBox.Font = new Font(BeforeBox.Font.OriginalFontName, x);
        }

        private void BeforeBox_Click(object sender, EventArgs e)
        {
            var pt = _trans.GetTrans(BeforeBox.SelectionStart);
            if (pt == null) return;
            AfterBox.Focus(); // 色変えとキャレット移動にはフォーカスが必要
            ClearSelectionBackColor(AfterBox, _afterBoxDefaultColor);
            AfterBox.SelectionStart = pt.TransPos;
            AfterBox.SelectionLength = pt.TransText.Length;
            AfterBox.SelectionBackColor = Color.DeepSkyBlue; // ハイライト
            AfterBox.ScrollToCaret();
            BeforeBox.Focus(); // フォーカスを戻す
        }

        private void AfterBox_Click(object sender, EventArgs e)
        {
            var pt = _trans.GetOrig(AfterBox.SelectionStart);
            if (pt == null) return;
            BeforeBox.TextChanged -= BeforeBox_TextChanged; // 自動整形と競合するので一旦ハンドラを外す
            BeforeBox.Focus(); // 色変えとキャレット移動にはフォーカスが必要
            ClearSelectionBackColor(BeforeBox, _beforeBoxDefaultColor);
            BeforeBox.SelectionStart = pt.OrigPos;
            BeforeBox.SelectionLength = pt.OrigText.Length;
            BeforeBox.SelectionBackColor = Color.DeepSkyBlue; // ハイライト
            BeforeBox.ScrollToCaret();
            AfterBox.Focus(); // フォーカスを戻す
            BeforeBox.TextChanged += BeforeBox_TextChanged;
        }

        private void ClearSelectionBackColor(RichTextBox rtb, Color color)
        {
            // rtbがフォーカスされていないと失敗する
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionBackColor = color; // 色クリア
        }

        // 対訳ハイライト
        private void HighlightPt(RichTextBox rtb, int pos, int len)
        {
            rtb.SelectionStart = pos;
            rtb.SelectionLength = len;
            rtb.SelectionBackColor = Color.DeepSkyBlue; // ハイライト

        }
    }
}
