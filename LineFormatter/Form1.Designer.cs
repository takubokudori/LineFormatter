namespace LineFormatter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BeforeLenLbl = new System.Windows.Forms.Label();
            this.AfterLenLbl = new System.Windows.Forms.Label();
            this.HistoryCmbBox = new System.Windows.Forms.ComboBox();
            this.AfterBox = new System.Windows.Forms.RichTextBox();
            this.AfterBoxCtxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchWithGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BeforeBox = new System.Windows.Forms.RichTextBox();
            this.BeforeBoxCtxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchWithGoogleTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FixationTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.FormatBtn = new System.Windows.Forms.Button();
            this.isAutoFormat = new System.Windows.Forms.CheckBox();
            this.isAutoTranslation = new System.Windows.Forms.CheckBox();
            this.TranslateBtn = new System.Windows.Forms.Button();
            this.TranslationTimer = new System.Windows.Forms.Timer(this.components);
            this.ProxyBtn = new System.Windows.Forms.Button();
            this.Lbtn = new System.Windows.Forms.Button();
            this.Rbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinusBtn = new System.Windows.Forms.Button();
            this.PlusBtn = new System.Windows.Forms.Button();
            this.PtColorDialog = new System.Windows.Forms.ColorDialog();
            this.PColorBtn = new System.Windows.Forms.Button();
            this.FixationBtn = new System.Windows.Forms.Button();
            this.FromComboBox = new System.Windows.Forms.ComboBox();
            this.ToComboBox = new System.Windows.Forms.ComboBox();
            this.LangSwapBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.AfterBoxCtxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BeforeBoxCtxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.BeforeLenLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.AfterLenLbl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.HistoryCmbBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AfterBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BeforeBox, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 196);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 764);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BeforeLenLbl
            // 
            this.BeforeLenLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BeforeLenLbl.AutoSize = true;
            this.BeforeLenLbl.Location = new System.Drawing.Point(185, 63);
            this.BeforeLenLbl.Name = "BeforeLenLbl";
            this.BeforeLenLbl.Size = new System.Drawing.Size(137, 24);
            this.BeforeLenLbl.TabIndex = 16;
            this.BeforeLenLbl.Text = "原文: 0 文字";
            // 
            // AfterLenLbl
            // 
            this.AfterLenLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AfterLenLbl.AutoSize = true;
            this.AfterLenLbl.Location = new System.Drawing.Point(804, 63);
            this.AfterLenLbl.Name = "AfterLenLbl";
            this.AfterLenLbl.Size = new System.Drawing.Size(137, 24);
            this.AfterLenLbl.TabIndex = 17;
            this.AfterLenLbl.Text = "訳文: 0 文字";
            // 
            // HistoryCmbBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.HistoryCmbBox, 3);
            this.HistoryCmbBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HistoryCmbBox.FormattingEnabled = true;
            this.HistoryCmbBox.Location = new System.Drawing.Point(3, 3);
            this.HistoryCmbBox.Name = "HistoryCmbBox";
            this.HistoryCmbBox.Size = new System.Drawing.Size(1121, 32);
            this.HistoryCmbBox.TabIndex = 18;
            this.HistoryCmbBox.SelectedIndexChanged += new System.EventHandler(this.HistoryCmbBox_SelectedIndexChanged);
            // 
            // AfterBox
            // 
            this.AfterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AfterBox.ContextMenuStrip = this.AfterBoxCtxMenuStrip;
            this.AfterBox.Location = new System.Drawing.Point(622, 93);
            this.AfterBox.Name = "AfterBox";
            this.AfterBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.AfterBox.Size = new System.Drawing.Size(502, 668);
            this.AfterBox.TabIndex = 4;
            this.AfterBox.Text = "";
            this.AfterBox.Click += new System.EventHandler(this.AfterBox_Click);
            this.AfterBox.TextChanged += new System.EventHandler(this.AfterBox_TextChanged);
            this.AfterBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AfterBox_KeyDown);
            // 
            // AfterBoxCtxMenuStrip
            // 
            this.AfterBoxCtxMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.AfterBoxCtxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchWithGoogleToolStripMenuItem});
            this.AfterBoxCtxMenuStrip.Name = "AfterBoxCtxMenuStrip";
            this.AfterBoxCtxMenuStrip.Size = new System.Drawing.Size(298, 42);
            // 
            // searchWithGoogleToolStripMenuItem
            // 
            this.searchWithGoogleToolStripMenuItem.Name = "searchWithGoogleToolStripMenuItem";
            this.searchWithGoogleToolStripMenuItem.Size = new System.Drawing.Size(297, 38);
            this.searchWithGoogleToolStripMenuItem.Text = "Search with Google";
            this.searchWithGoogleToolStripMenuItem.Click += new System.EventHandler(this.searchWithGoogleToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::LineFormatter.Resource1.arrow;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(510, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 668);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BeforeBox
            // 
            this.BeforeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeforeBox.ContextMenuStrip = this.BeforeBoxCtxMenuStrip;
            this.BeforeBox.Location = new System.Drawing.Point(3, 93);
            this.BeforeBox.Name = "BeforeBox";
            this.BeforeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.BeforeBox.Size = new System.Drawing.Size(501, 668);
            this.BeforeBox.TabIndex = 3;
            this.BeforeBox.Text = "";
            this.BeforeBox.Click += new System.EventHandler(this.BeforeBox_Click);
            this.BeforeBox.TextChanged += new System.EventHandler(this.BeforeBox_TextChanged);
            this.BeforeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BeforeBox_KeyDown);
            // 
            // BeforeBoxCtxMenuStrip
            // 
            this.BeforeBoxCtxMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BeforeBoxCtxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchWithGoogleTSMI,
            this.FixationTSMI});
            this.BeforeBoxCtxMenuStrip.Name = "BeforeBoxCtxMenuStrip";
            this.BeforeBoxCtxMenuStrip.Size = new System.Drawing.Size(298, 80);
            // 
            // searchWithGoogleTSMI
            // 
            this.searchWithGoogleTSMI.Name = "searchWithGoogleTSMI";
            this.searchWithGoogleTSMI.Size = new System.Drawing.Size(297, 38);
            this.searchWithGoogleTSMI.Text = "Search with Google";
            this.searchWithGoogleTSMI.Click += new System.EventHandler(this.searchWithGoogleToolStripMenuItem1_Click);
            // 
            // FixationTSMI
            // 
            this.FixationTSMI.Name = "FixationTSMI";
            this.FixationTSMI.Size = new System.Drawing.Size(297, 38);
            this.FixationTSMI.Text = "固定リストに追加";
            this.FixationTSMI.Click += new System.EventHandler(this.FixationTSMI_Click);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(12, 27);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(214, 24);
            this.TitleLbl.TabIndex = 2;
            this.TitleLbl.Text = "LineFormatter v1.4.0";
            // 
            // FormatBtn
            // 
            this.FormatBtn.Location = new System.Drawing.Point(658, 13);
            this.FormatBtn.Name = "FormatBtn";
            this.FormatBtn.Size = new System.Drawing.Size(117, 47);
            this.FormatBtn.TabIndex = 3;
            this.FormatBtn.Text = "整形";
            this.FormatBtn.UseVisualStyleBackColor = true;
            this.FormatBtn.Click += new System.EventHandler(this.FormatBtn_Click);
            // 
            // isAutoFormat
            // 
            this.isAutoFormat.AutoSize = true;
            this.isAutoFormat.Checked = true;
            this.isAutoFormat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoFormat.Location = new System.Drawing.Point(490, 13);
            this.isAutoFormat.Name = "isAutoFormat";
            this.isAutoFormat.Size = new System.Drawing.Size(138, 28);
            this.isAutoFormat.TabIndex = 4;
            this.isAutoFormat.Text = "自動整形";
            this.isAutoFormat.UseVisualStyleBackColor = true;
            // 
            // isAutoTranslation
            // 
            this.isAutoTranslation.AutoSize = true;
            this.isAutoTranslation.Checked = true;
            this.isAutoTranslation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutoTranslation.Location = new System.Drawing.Point(490, 47);
            this.isAutoTranslation.Name = "isAutoTranslation";
            this.isAutoTranslation.Size = new System.Drawing.Size(138, 28);
            this.isAutoTranslation.TabIndex = 5;
            this.isAutoTranslation.Text = "自動翻訳";
            this.isAutoTranslation.UseVisualStyleBackColor = true;
            // 
            // TranslateBtn
            // 
            this.TranslateBtn.Location = new System.Drawing.Point(781, 13);
            this.TranslateBtn.Name = "TranslateBtn";
            this.TranslateBtn.Size = new System.Drawing.Size(117, 47);
            this.TranslateBtn.TabIndex = 6;
            this.TranslateBtn.Text = "翻訳";
            this.TranslateBtn.UseVisualStyleBackColor = true;
            this.TranslateBtn.Click += new System.EventHandler(this.TranslateBtn_Click);
            // 
            // TranslationTimer
            // 
            this.TranslationTimer.Interval = 2000;
            this.TranslationTimer.Tick += new System.EventHandler(this.TranslationTimer_Tick);
            // 
            // ProxyBtn
            // 
            this.ProxyBtn.Location = new System.Drawing.Point(357, 12);
            this.ProxyBtn.Name = "ProxyBtn";
            this.ProxyBtn.Size = new System.Drawing.Size(117, 47);
            this.ProxyBtn.TabIndex = 7;
            this.ProxyBtn.Text = "プロキシ";
            this.ProxyBtn.UseVisualStyleBackColor = true;
            this.ProxyBtn.Click += new System.EventHandler(this.ProxyBtn_Click);
            // 
            // Lbtn
            // 
            this.Lbtn.Location = new System.Drawing.Point(357, 76);
            this.Lbtn.Name = "Lbtn";
            this.Lbtn.Size = new System.Drawing.Size(37, 38);
            this.Lbtn.TabIndex = 8;
            this.Lbtn.Text = "←";
            this.Lbtn.UseVisualStyleBackColor = true;
            this.Lbtn.Click += new System.EventHandler(this.LBtn_Click);
            // 
            // Rbtn
            // 
            this.Rbtn.Location = new System.Drawing.Point(437, 76);
            this.Rbtn.Name = "Rbtn";
            this.Rbtn.Size = new System.Drawing.Size(37, 38);
            this.Rbtn.TabIndex = 9;
            this.Rbtn.Text = "→";
            this.Rbtn.UseVisualStyleBackColor = true;
            this.Rbtn.Click += new System.EventHandler(this.RBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "比率:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "文字サイズ:";
            // 
            // MinusBtn
            // 
            this.MinusBtn.Location = new System.Drawing.Point(781, 76);
            this.MinusBtn.Name = "MinusBtn";
            this.MinusBtn.Size = new System.Drawing.Size(37, 38);
            this.MinusBtn.TabIndex = 13;
            this.MinusBtn.Text = "-";
            this.MinusBtn.UseVisualStyleBackColor = true;
            this.MinusBtn.Click += new System.EventHandler(this.MinusBtn_Click);
            // 
            // PlusBtn
            // 
            this.PlusBtn.Location = new System.Drawing.Point(861, 76);
            this.PlusBtn.Name = "PlusBtn";
            this.PlusBtn.Size = new System.Drawing.Size(37, 38);
            this.PlusBtn.TabIndex = 14;
            this.PlusBtn.Text = "+";
            this.PlusBtn.UseVisualStyleBackColor = true;
            this.PlusBtn.Click += new System.EventHandler(this.PlusBtn_Click);
            // 
            // PtColorDialog
            // 
            this.PtColorDialog.Color = System.Drawing.Color.LightSkyBlue;
            // 
            // PColorBtn
            // 
            this.PColorBtn.Location = new System.Drawing.Point(658, 120);
            this.PColorBtn.Name = "PColorBtn";
            this.PColorBtn.Size = new System.Drawing.Size(117, 47);
            this.PColorBtn.TabIndex = 15;
            this.PColorBtn.Text = "対訳色";
            this.PColorBtn.UseVisualStyleBackColor = true;
            this.PColorBtn.Click += new System.EventHandler(this.PColorBtn_Click);
            // 
            // FixationBtn
            // 
            this.FixationBtn.Location = new System.Drawing.Point(16, 76);
            this.FixationBtn.Name = "FixationBtn";
            this.FixationBtn.Size = new System.Drawing.Size(117, 47);
            this.FixationBtn.TabIndex = 16;
            this.FixationBtn.Text = "固定";
            this.FixationBtn.UseVisualStyleBackColor = true;
            this.FixationBtn.Click += new System.EventHandler(this.FixationBtn_Click);
            // 
            // FromComboBox
            // 
            this.FromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromComboBox.FormattingEnabled = true;
            this.FromComboBox.Items.AddRange(new object[] {
            "ja,日本語",
            "en,英語",
            "zh-CN,中国語",
            "ru,ロシア語",
            "ko,韓国語",
            "is,アイスランド語",
            "ga,アイルランド語",
            "az,アゼルバイジャン語",
            "af,アフリカーンス語",
            "am,アムハラ語",
            "ar,アラビア語",
            "sq,アルバニア語",
            "hy,アルメニア語",
            "it,イタリア語",
            "yi,イディッシュ語",
            "ig,イボ語",
            "id,インドネシア語",
            "ug,ウイグル語",
            "cy,ウェールズ語",
            "uk,ウクライナ語",
            "uz,ウズベク語",
            "ur,ウルドゥ語",
            "et,エストニア語",
            "eo,エスペラント語",
            "nl,オランダ語",
            "or,オリヤ語",
            "kk,カザフ語",
            "ca,カタルーニャ語",
            "gl,ガリシア語",
            "kn,カンナダ語",
            "rw,キニヤルワンダ語",
            "el,ギリシャ語",
            "ky,キルギス語",
            "gu,グジャラト語",
            "km,クメール語",
            "ku,クルド語",
            "hr,クロアチア語",
            "xh,コーサ語",
            "co,コルシカ語",
            "sm,サモア語",
            "jw,ジャワ語",
            "ka,ジョージア(グルジア)語",
            "sn,ショナ語",
            "sd,シンド語",
            "si,シンハラ語",
            "sv,スウェーデン語",
            "zu,ズールー語",
            "gd,スコットランド ゲール語",
            "es,スペイン語",
            "sk,スロバキア語",
            "sl,スロベニア語",
            "sw,スワヒリ語",
            "su,スンダ語",
            "ceb,セブアノ語",
            "sr,セルビア語",
            "st,ソト語",
            "so,ソマリ語",
            "th,タイ語",
            "tl,タガログ語",
            "tg,タジク語",
            "tt,タタール語",
            "ta,タミル語",
            "cs,チェコ語",
            "ny,チェワ語",
            "te,テルグ語",
            "da,デンマーク語",
            "de,ドイツ語",
            "tk,トルクメン語",
            "tr,トルコ語",
            "ne,ネパール語",
            "no,ノルウェー語",
            "ht,ハイチ語",
            "ha,ハウサ語",
            "ps,パシュト語",
            "eu,バスク語",
            "haw,ハワイ語",
            "hu,ハンガリー語",
            "pa,パンジャブ語",
            "hi,ヒンディー語",
            "fi,フィンランド語",
            "fr,フランス語",
            "fy,フリジア語",
            "bg,ブルガリア語",
            "vi,ベトナム語",
            "iw,ヘブライ語",
            "be,ベラルーシ語",
            "fa,ペルシャ語",
            "bn,ベンガル語",
            "pl,ポーランド語",
            "bs,ボスニア語",
            "pt,ポルトガル語",
            "mi,マオリ語",
            "mk,マケドニア語",
            "mr,マラーティー語",
            "mg,マラガシ語",
            "ml,マラヤーラム語",
            "mt,マルタ語",
            "ms,マレー語",
            "my,ミャンマー語",
            "mn,モンゴル語",
            "hmn,モン語",
            "yo,ヨルバ語",
            "lo,ラオ語",
            "la,ラテン語",
            "lv,ラトビア語",
            "lt,リトアニア語",
            "ro,ルーマニア語",
            "lb,ルクセンブルク語"});
            this.FromComboBox.Location = new System.Drawing.Point(30, 147);
            this.FromComboBox.Name = "FromComboBox";
            this.FromComboBox.Size = new System.Drawing.Size(251, 32);
            this.FromComboBox.TabIndex = 17;
            // 
            // ToComboBox
            // 
            this.ToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToComboBox.FormattingEnabled = true;
            this.ToComboBox.Items.AddRange(new object[] {
            "ja,日本語",
            "en,英語",
            "zh-CN,中国語",
            "ru,ロシア語",
            "ko,韓国語",
            "is,アイスランド語",
            "ga,アイルランド語",
            "az,アゼルバイジャン語",
            "af,アフリカーンス語",
            "am,アムハラ語",
            "ar,アラビア語",
            "sq,アルバニア語",
            "hy,アルメニア語",
            "it,イタリア語",
            "yi,イディッシュ語",
            "ig,イボ語",
            "id,インドネシア語",
            "ug,ウイグル語",
            "cy,ウェールズ語",
            "uk,ウクライナ語",
            "uz,ウズベク語",
            "ur,ウルドゥ語",
            "et,エストニア語",
            "eo,エスペラント語",
            "nl,オランダ語",
            "or,オリヤ語",
            "kk,カザフ語",
            "ca,カタルーニャ語",
            "gl,ガリシア語",
            "kn,カンナダ語",
            "rw,キニヤルワンダ語",
            "el,ギリシャ語",
            "ky,キルギス語",
            "gu,グジャラト語",
            "km,クメール語",
            "ku,クルド語",
            "hr,クロアチア語",
            "xh,コーサ語",
            "co,コルシカ語",
            "sm,サモア語",
            "jw,ジャワ語",
            "ka,ジョージア(グルジア)語",
            "sn,ショナ語",
            "sd,シンド語",
            "si,シンハラ語",
            "sv,スウェーデン語",
            "zu,ズールー語",
            "gd,スコットランド ゲール語",
            "es,スペイン語",
            "sk,スロバキア語",
            "sl,スロベニア語",
            "sw,スワヒリ語",
            "su,スンダ語",
            "ceb,セブアノ語",
            "sr,セルビア語",
            "st,ソト語",
            "so,ソマリ語",
            "th,タイ語",
            "tl,タガログ語",
            "tg,タジク語",
            "tt,タタール語",
            "ta,タミル語",
            "cs,チェコ語",
            "ny,チェワ語",
            "te,テルグ語",
            "da,デンマーク語",
            "de,ドイツ語",
            "tk,トルクメン語",
            "tr,トルコ語",
            "ne,ネパール語",
            "no,ノルウェー語",
            "ht,ハイチ語",
            "ha,ハウサ語",
            "ps,パシュト語",
            "eu,バスク語",
            "haw,ハワイ語",
            "hu,ハンガリー語",
            "pa,パンジャブ語",
            "hi,ヒンディー語",
            "fi,フィンランド語",
            "fr,フランス語",
            "fy,フリジア語",
            "bg,ブルガリア語",
            "vi,ベトナム語",
            "iw,ヘブライ語",
            "be,ベラルーシ語",
            "fa,ペルシャ語",
            "bn,ベンガル語",
            "pl,ポーランド語",
            "bs,ボスニア語",
            "pt,ポルトガル語",
            "mi,マオリ語",
            "mk,マケドニア語",
            "mr,マラーティー語",
            "mg,マラガシ語",
            "ml,マラヤーラム語",
            "mt,マルタ語",
            "ms,マレー語",
            "my,ミャンマー語",
            "mn,モンゴル語",
            "hmn,モン語",
            "yo,ヨルバ語",
            "lo,ラオ語",
            "la,ラテン語",
            "lv,ラトビア語",
            "lt,リトアニア語",
            "ro,ルーマニア語",
            "lb,ルクセンブルク語"});
            this.ToComboBox.Location = new System.Drawing.Point(368, 147);
            this.ToComboBox.Name = "ToComboBox";
            this.ToComboBox.Size = new System.Drawing.Size(239, 32);
            this.ToComboBox.TabIndex = 18;
            // 
            // LangSwapBtn
            // 
            this.LangSwapBtn.Location = new System.Drawing.Point(287, 139);
            this.LangSwapBtn.Name = "LangSwapBtn";
            this.LangSwapBtn.Size = new System.Drawing.Size(75, 47);
            this.LangSwapBtn.TabIndex = 19;
            this.LangSwapBtn.Text = "⇔";
            this.LangSwapBtn.UseVisualStyleBackColor = true;
            this.LangSwapBtn.Click += new System.EventHandler(this.LangSwapBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 972);
            this.Controls.Add(this.LangSwapBtn);
            this.Controls.Add(this.ToComboBox);
            this.Controls.Add(this.FromComboBox);
            this.Controls.Add(this.FixationBtn);
            this.Controls.Add(this.PColorBtn);
            this.Controls.Add(this.PlusBtn);
            this.Controls.Add(this.MinusBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rbtn);
            this.Controls.Add(this.Lbtn);
            this.Controls.Add(this.ProxyBtn);
            this.Controls.Add(this.TranslateBtn);
            this.Controls.Add(this.isAutoTranslation);
            this.Controls.Add(this.isAutoFormat);
            this.Controls.Add(this.FormatBtn);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "LineFormatter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.AfterBoxCtxMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BeforeBoxCtxMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Button FormatBtn;
        private System.Windows.Forms.CheckBox isAutoFormat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox isAutoTranslation;
        private System.Windows.Forms.Button TranslateBtn;
        private System.Windows.Forms.Timer TranslationTimer;
        private System.Windows.Forms.Button ProxyBtn;
        private System.Windows.Forms.Button Lbtn;
        private System.Windows.Forms.Button Rbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MinusBtn;
        private System.Windows.Forms.Button PlusBtn;
        private System.Windows.Forms.RichTextBox AfterBox;
        private System.Windows.Forms.RichTextBox BeforeBox;
        private System.Windows.Forms.ColorDialog PtColorDialog;
        private System.Windows.Forms.Button PColorBtn;
        private System.Windows.Forms.Label BeforeLenLbl;
        private System.Windows.Forms.Label AfterLenLbl;
        private System.Windows.Forms.ContextMenuStrip AfterBoxCtxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem searchWithGoogleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip BeforeBoxCtxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem searchWithGoogleTSMI;
        private System.Windows.Forms.Button FixationBtn;
        private System.Windows.Forms.ToolStripMenuItem FixationTSMI;
        private System.Windows.Forms.ComboBox HistoryCmbBox;
        private System.Windows.Forms.ComboBox FromComboBox;
        private System.Windows.Forms.ComboBox ToComboBox;
        private System.Windows.Forms.Button LangSwapBtn;
    }
}

