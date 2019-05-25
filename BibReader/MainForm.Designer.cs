namespace BibReader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.tbSourсe = new System.Windows.Forms.TextBox();
            this.tbKeywords = new System.Windows.Forms.TextBox();
            this.tbAffiliation = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbDoi = new System.Windows.Forms.TextBox();
            this.tbPages = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbPublisher = new System.Windows.Forms.TextBox();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbJournalName = new System.Windows.Forms.TextBox();
            this.tbAbstract = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbSourse = new System.Windows.Forms.Label();
            this.lbPublisher = new System.Windows.Forms.Label();
            this.lbKeywords = new System.Windows.Forms.Label();
            this.lbAbstract = new System.Windows.Forms.Label();
            this.lbAffiliation = new System.Windows.Forms.Label();
            this.lbUrl = new System.Windows.Forms.Label();
            this.lbDoi = new System.Windows.Forms.Label();
            this.lbPage = new System.Windows.Forms.Label();
            this.lbVolume = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.lbJournalName = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbAuthors = new System.Windows.Forms.Label();
            this.tpBib = new System.Windows.Forms.TabPage();
            this.btSaveBibRef = new System.Windows.Forms.Button();
            this.btPrintBib = new System.Windows.Forms.Button();
            this.cbBibStyles = new System.Windows.Forms.ComboBox();
            this.rtbBib = new System.Windows.Forms.RichTextBox();
            this.tpStatistic = new System.Windows.Forms.TabPage();
            this.btSaveStatistic = new System.Windows.Forms.Button();
            this.tabControlForStatistic = new System.Windows.Forms.TabControl();
            this.tpYearStat = new System.Windows.Forms.TabPage();
            this.lvYearStatistic = new System.Windows.Forms.ListView();
            this.tpSourses = new System.Windows.Forms.TabPage();
            this.lvSourceStatistic = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvTypeOfDoc = new System.Windows.Forms.ListView();
            this.tpJournalStat = new System.Windows.Forms.TabPage();
            this.lvJournalStat = new System.Windows.Forms.ListView();
            this.tpGeography = new System.Windows.Forms.TabPage();
            this.lvGeography = new System.Windows.Forms.ListView();
            this.tpConf = new System.Windows.Forms.TabPage();
            this.lvConferenceStat = new System.Windows.Forms.ListView();
            this.lvLibItems = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.корпусДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.библОписанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.классификацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.названияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ключевыеСловаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аннотацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCurrSelectedItem = new System.Windows.Forms.Label();
            this.btFirst = new System.Windows.Forms.Button();
            this.btUnique = new System.Windows.Forms.Button();
            this.btRelevance = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLoadUniqueData = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btNextFindedLibItem = new System.Windows.Forms.Button();
            this.btPrevFindedLibItem = new System.Windows.Forms.Button();
            this.cbSearchCriterion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFindedItemsCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpData.SuspendLayout();
            this.tpBib.SuspendLayout();
            this.tpStatistic.SuspendLayout();
            this.tabControlForStatistic.SuspendLayout();
            this.tpYearStat.SuspendLayout();
            this.tpSourses.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpJournalStat.SuspendLayout();
            this.tpGeography.SuspendLayout();
            this.tpConf.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Location = new System.Drawing.Point(848, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 740);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpData);
            this.tabControl.Controls.Add(this.tpBib);
            this.tabControl.Controls.Add(this.tpStatistic);
            this.tabControl.Location = new System.Drawing.Point(6, 21);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(664, 713);
            this.tabControl.TabIndex = 0;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.tbSourсe);
            this.tpData.Controls.Add(this.tbKeywords);
            this.tpData.Controls.Add(this.tbAffiliation);
            this.tpData.Controls.Add(this.tbUrl);
            this.tpData.Controls.Add(this.tbDoi);
            this.tpData.Controls.Add(this.tbPages);
            this.tpData.Controls.Add(this.tbNumber);
            this.tpData.Controls.Add(this.tbPublisher);
            this.tpData.Controls.Add(this.tbVolume);
            this.tpData.Controls.Add(this.tbYear);
            this.tpData.Controls.Add(this.tbJournalName);
            this.tpData.Controls.Add(this.tbAbstract);
            this.tpData.Controls.Add(this.tbTitle);
            this.tpData.Controls.Add(this.tbAuthors);
            this.tpData.Controls.Add(this.lbNumber);
            this.tpData.Controls.Add(this.lbSourse);
            this.tpData.Controls.Add(this.lbPublisher);
            this.tpData.Controls.Add(this.lbKeywords);
            this.tpData.Controls.Add(this.lbAbstract);
            this.tpData.Controls.Add(this.lbAffiliation);
            this.tpData.Controls.Add(this.lbUrl);
            this.tpData.Controls.Add(this.lbDoi);
            this.tpData.Controls.Add(this.lbPage);
            this.tpData.Controls.Add(this.lbVolume);
            this.tpData.Controls.Add(this.lbYear);
            this.tpData.Controls.Add(this.lbJournalName);
            this.tpData.Controls.Add(this.lbTitle);
            this.tpData.Controls.Add(this.lbAuthors);
            this.tpData.Location = new System.Drawing.Point(4, 25);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(656, 684);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Данные";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // tbSourсe
            // 
            this.tbSourсe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourсe.Location = new System.Drawing.Point(179, 639);
            this.tbSourсe.Name = "tbSourсe";
            this.tbSourсe.Size = new System.Drawing.Size(471, 22);
            this.tbSourсe.TabIndex = 27;
            // 
            // tbKeywords
            // 
            this.tbKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeywords.Location = new System.Drawing.Point(179, 578);
            this.tbKeywords.Multiline = true;
            this.tbKeywords.Name = "tbKeywords";
            this.tbKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKeywords.Size = new System.Drawing.Size(471, 55);
            this.tbKeywords.TabIndex = 26;
            // 
            // tbAffiliation
            // 
            this.tbAffiliation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAffiliation.Location = new System.Drawing.Point(179, 512);
            this.tbAffiliation.Multiline = true;
            this.tbAffiliation.Name = "tbAffiliation";
            this.tbAffiliation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAffiliation.Size = new System.Drawing.Size(471, 60);
            this.tbAffiliation.TabIndex = 25;
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Location = new System.Drawing.Point(179, 447);
            this.tbUrl.Multiline = true;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUrl.Size = new System.Drawing.Size(471, 59);
            this.tbUrl.TabIndex = 24;
            // 
            // tbDoi
            // 
            this.tbDoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDoi.Location = new System.Drawing.Point(179, 419);
            this.tbDoi.Name = "tbDoi";
            this.tbDoi.Size = new System.Drawing.Size(471, 22);
            this.tbDoi.TabIndex = 23;
            // 
            // tbPages
            // 
            this.tbPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPages.Location = new System.Drawing.Point(179, 391);
            this.tbPages.Name = "tbPages";
            this.tbPages.Size = new System.Drawing.Size(471, 22);
            this.tbPages.TabIndex = 22;
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumber.Location = new System.Drawing.Point(179, 363);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(471, 22);
            this.tbNumber.TabIndex = 21;
            // 
            // tbPublisher
            // 
            this.tbPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPublisher.Location = new System.Drawing.Point(179, 335);
            this.tbPublisher.Name = "tbPublisher";
            this.tbPublisher.Size = new System.Drawing.Size(471, 22);
            this.tbPublisher.TabIndex = 20;
            // 
            // tbVolume
            // 
            this.tbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVolume.Location = new System.Drawing.Point(179, 305);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(471, 22);
            this.tbVolume.TabIndex = 19;
            // 
            // tbYear
            // 
            this.tbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbYear.Location = new System.Drawing.Point(179, 271);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(471, 22);
            this.tbYear.TabIndex = 18;
            // 
            // tbJournalName
            // 
            this.tbJournalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJournalName.Location = new System.Drawing.Point(179, 243);
            this.tbJournalName.Name = "tbJournalName";
            this.tbJournalName.Size = new System.Drawing.Size(471, 22);
            this.tbJournalName.TabIndex = 17;
            // 
            // tbAbstract
            // 
            this.tbAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAbstract.Location = new System.Drawing.Point(179, 141);
            this.tbAbstract.Multiline = true;
            this.tbAbstract.Name = "tbAbstract";
            this.tbAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAbstract.Size = new System.Drawing.Size(471, 96);
            this.tbAbstract.TabIndex = 16;
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(179, 110);
            this.tbTitle.Multiline = true;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(471, 22);
            this.tbTitle.TabIndex = 15;
            // 
            // tbAuthors
            // 
            this.tbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuthors.Location = new System.Drawing.Point(179, 20);
            this.tbAuthors.Multiline = true;
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAuthors.Size = new System.Drawing.Size(471, 84);
            this.tbAuthors.TabIndex = 14;
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(3, 363);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(51, 17);
            this.lbNumber.TabIndex = 13;
            this.lbNumber.Text = "Номер";
            // 
            // lbSourse
            // 
            this.lbSourse.AutoSize = true;
            this.lbSourse.Location = new System.Drawing.Point(6, 639);
            this.lbSourse.Name = "lbSourse";
            this.lbSourse.Size = new System.Drawing.Size(71, 17);
            this.lbSourse.TabIndex = 12;
            this.lbSourse.Text = "Источник";
            // 
            // lbPublisher
            // 
            this.lbPublisher.AutoSize = true;
            this.lbPublisher.Location = new System.Drawing.Point(6, 335);
            this.lbPublisher.Name = "lbPublisher";
            this.lbPublisher.Size = new System.Drawing.Size(71, 17);
            this.lbPublisher.TabIndex = 11;
            this.lbPublisher.Text = "Издатель";
            // 
            // lbKeywords
            // 
            this.lbKeywords.AutoSize = true;
            this.lbKeywords.Location = new System.Drawing.Point(7, 578);
            this.lbKeywords.Name = "lbKeywords";
            this.lbKeywords.Size = new System.Drawing.Size(118, 17);
            this.lbKeywords.TabIndex = 10;
            this.lbKeywords.Text = "Ключевые слова";
            // 
            // lbAbstract
            // 
            this.lbAbstract.AutoSize = true;
            this.lbAbstract.Location = new System.Drawing.Point(6, 140);
            this.lbAbstract.Name = "lbAbstract";
            this.lbAbstract.Size = new System.Drawing.Size(80, 17);
            this.lbAbstract.TabIndex = 9;
            this.lbAbstract.Text = "Аннотация";
            // 
            // lbAffiliation
            // 
            this.lbAffiliation.AutoSize = true;
            this.lbAffiliation.Location = new System.Drawing.Point(7, 515);
            this.lbAffiliation.Name = "lbAffiliation";
            this.lbAffiliation.Size = new System.Drawing.Size(65, 17);
            this.lbAffiliation.TabIndex = 8;
            this.lbAffiliation.Text = "Affiliation";
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(7, 447);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(26, 17);
            this.lbUrl.TabIndex = 7;
            this.lbUrl.Text = "Url";
            // 
            // lbDoi
            // 
            this.lbDoi.AutoSize = true;
            this.lbDoi.Location = new System.Drawing.Point(6, 419);
            this.lbDoi.Name = "lbDoi";
            this.lbDoi.Size = new System.Drawing.Size(29, 17);
            this.lbDoi.TabIndex = 6;
            this.lbDoi.Text = "Doi";
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(6, 391);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(74, 17);
            this.lbPage.TabIndex = 5;
            this.lbPage.Text = "Страницы";
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(6, 305);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(34, 17);
            this.lbVolume.TabIndex = 4;
            this.lbVolume.Text = "Том";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(6, 271);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(32, 17);
            this.lbYear.TabIndex = 3;
            this.lbYear.Text = "Год";
            // 
            // lbJournalName
            // 
            this.lbJournalName.AutoSize = true;
            this.lbJournalName.Location = new System.Drawing.Point(3, 243);
            this.lbJournalName.Name = "lbJournalName";
            this.lbJournalName.Size = new System.Drawing.Size(60, 17);
            this.lbJournalName.TabIndex = 2;
            this.lbJournalName.Text = "Журнал";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(6, 110);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(72, 17);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Название";
            // 
            // lbAuthors
            // 
            this.lbAuthors.AutoSize = true;
            this.lbAuthors.Location = new System.Drawing.Point(6, 20);
            this.lbAuthors.Name = "lbAuthors";
            this.lbAuthors.Size = new System.Drawing.Size(57, 17);
            this.lbAuthors.TabIndex = 0;
            this.lbAuthors.Text = "Авторы";
            // 
            // tpBib
            // 
            this.tpBib.Controls.Add(this.btSaveBibRef);
            this.tpBib.Controls.Add(this.btPrintBib);
            this.tpBib.Controls.Add(this.cbBibStyles);
            this.tpBib.Controls.Add(this.rtbBib);
            this.tpBib.Location = new System.Drawing.Point(4, 25);
            this.tpBib.Name = "tpBib";
            this.tpBib.Padding = new System.Windows.Forms.Padding(3);
            this.tpBib.Size = new System.Drawing.Size(656, 684);
            this.tpBib.TabIndex = 1;
            this.tpBib.Text = "Библ. описания";
            this.tpBib.UseVisualStyleBackColor = true;
            // 
            // btSaveBibRef
            // 
            this.btSaveBibRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSaveBibRef.Location = new System.Drawing.Point(7, 626);
            this.btSaveBibRef.Name = "btSaveBibRef";
            this.btSaveBibRef.Size = new System.Drawing.Size(124, 52);
            this.btSaveBibRef.TabIndex = 3;
            this.btSaveBibRef.Text = "Сохранить в Word";
            this.btSaveBibRef.UseVisualStyleBackColor = true;
            this.btSaveBibRef.Click += new System.EventHandler(this.btSaveBibRef_Click);
            // 
            // btPrintBib
            // 
            this.btPrintBib.Location = new System.Drawing.Point(230, 17);
            this.btPrintBib.Name = "btPrintBib";
            this.btPrintBib.Size = new System.Drawing.Size(88, 23);
            this.btPrintBib.TabIndex = 2;
            this.btPrintBib.Text = "Изменить";
            this.btPrintBib.UseVisualStyleBackColor = true;
            this.btPrintBib.Click += new System.EventHandler(this.btPrintBib_Click);
            // 
            // cbBibStyles
            // 
            this.cbBibStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBibStyles.FormattingEnabled = true;
            this.cbBibStyles.Items.AddRange(new object[] {
            "ГОСТ",
            "APA",
            "Harvard",
            "IEEE"});
            this.cbBibStyles.Location = new System.Drawing.Point(7, 17);
            this.cbBibStyles.Name = "cbBibStyles";
            this.cbBibStyles.Size = new System.Drawing.Size(205, 24);
            this.cbBibStyles.TabIndex = 1;
            // 
            // rtbBib
            // 
            this.rtbBib.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBib.Location = new System.Drawing.Point(7, 48);
            this.rtbBib.Name = "rtbBib";
            this.rtbBib.Size = new System.Drawing.Size(643, 572);
            this.rtbBib.TabIndex = 0;
            this.rtbBib.Text = "";
            // 
            // tpStatistic
            // 
            this.tpStatistic.Controls.Add(this.btSaveStatistic);
            this.tpStatistic.Controls.Add(this.tabControlForStatistic);
            this.tpStatistic.Location = new System.Drawing.Point(4, 25);
            this.tpStatistic.Name = "tpStatistic";
            this.tpStatistic.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistic.Size = new System.Drawing.Size(656, 684);
            this.tpStatistic.TabIndex = 2;
            this.tpStatistic.Text = "Статистика";
            this.tpStatistic.UseVisualStyleBackColor = true;
            // 
            // btSaveStatistic
            // 
            this.btSaveStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSaveStatistic.Location = new System.Drawing.Point(17, 630);
            this.btSaveStatistic.Name = "btSaveStatistic";
            this.btSaveStatistic.Size = new System.Drawing.Size(107, 48);
            this.btSaveStatistic.TabIndex = 2;
            this.btSaveStatistic.Text = "Сохранить в Excel";
            this.btSaveStatistic.UseVisualStyleBackColor = true;
            this.btSaveStatistic.Click += new System.EventHandler(this.btSaveStatistic_Click);
            // 
            // tabControlForStatistic
            // 
            this.tabControlForStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlForStatistic.Controls.Add(this.tpYearStat);
            this.tabControlForStatistic.Controls.Add(this.tpSourses);
            this.tabControlForStatistic.Controls.Add(this.tabPage1);
            this.tabControlForStatistic.Controls.Add(this.tpJournalStat);
            this.tabControlForStatistic.Controls.Add(this.tpGeography);
            this.tabControlForStatistic.Controls.Add(this.tpConf);
            this.tabControlForStatistic.Location = new System.Drawing.Point(6, 7);
            this.tabControlForStatistic.Name = "tabControlForStatistic";
            this.tabControlForStatistic.SelectedIndex = 0;
            this.tabControlForStatistic.Size = new System.Drawing.Size(643, 616);
            this.tabControlForStatistic.TabIndex = 1;
            // 
            // tpYearStat
            // 
            this.tpYearStat.Controls.Add(this.lvYearStatistic);
            this.tpYearStat.Location = new System.Drawing.Point(4, 25);
            this.tpYearStat.Name = "tpYearStat";
            this.tpYearStat.Padding = new System.Windows.Forms.Padding(3);
            this.tpYearStat.Size = new System.Drawing.Size(635, 587);
            this.tpYearStat.TabIndex = 0;
            this.tpYearStat.Text = "Годы";
            this.tpYearStat.UseVisualStyleBackColor = true;
            // 
            // lvYearStatistic
            // 
            this.lvYearStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvYearStatistic.Location = new System.Drawing.Point(6, 6);
            this.lvYearStatistic.Name = "lvYearStatistic";
            this.lvYearStatistic.Size = new System.Drawing.Size(623, 572);
            this.lvYearStatistic.TabIndex = 0;
            this.lvYearStatistic.UseCompatibleStateImageBehavior = false;
            this.lvYearStatistic.View = System.Windows.Forms.View.Details;
            // 
            // tpSourses
            // 
            this.tpSourses.Controls.Add(this.lvSourceStatistic);
            this.tpSourses.Location = new System.Drawing.Point(4, 25);
            this.tpSourses.Name = "tpSourses";
            this.tpSourses.Padding = new System.Windows.Forms.Padding(3);
            this.tpSourses.Size = new System.Drawing.Size(635, 587);
            this.tpSourses.TabIndex = 1;
            this.tpSourses.Text = "Источники";
            this.tpSourses.UseVisualStyleBackColor = true;
            // 
            // lvSourceStatistic
            // 
            this.lvSourceStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSourceStatistic.Location = new System.Drawing.Point(6, 6);
            this.lvSourceStatistic.Name = "lvSourceStatistic";
            this.lvSourceStatistic.Size = new System.Drawing.Size(623, 572);
            this.lvSourceStatistic.TabIndex = 1;
            this.lvSourceStatistic.UseCompatibleStateImageBehavior = false;
            this.lvSourceStatistic.View = System.Windows.Forms.View.Details;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvTypeOfDoc);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 587);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Тип документа";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvTypeOfDoc
            // 
            this.lvTypeOfDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTypeOfDoc.Location = new System.Drawing.Point(7, 6);
            this.lvTypeOfDoc.Name = "lvTypeOfDoc";
            this.lvTypeOfDoc.Size = new System.Drawing.Size(622, 572);
            this.lvTypeOfDoc.TabIndex = 0;
            this.lvTypeOfDoc.UseCompatibleStateImageBehavior = false;
            this.lvTypeOfDoc.View = System.Windows.Forms.View.Details;
            // 
            // tpJournalStat
            // 
            this.tpJournalStat.Controls.Add(this.lvJournalStat);
            this.tpJournalStat.Location = new System.Drawing.Point(4, 25);
            this.tpJournalStat.Name = "tpJournalStat";
            this.tpJournalStat.Padding = new System.Windows.Forms.Padding(3);
            this.tpJournalStat.Size = new System.Drawing.Size(635, 587);
            this.tpJournalStat.TabIndex = 3;
            this.tpJournalStat.Text = "Журналы";
            this.tpJournalStat.UseVisualStyleBackColor = true;
            // 
            // lvJournalStat
            // 
            this.lvJournalStat.Location = new System.Drawing.Point(7, 4);
            this.lvJournalStat.Name = "lvJournalStat";
            this.lvJournalStat.Size = new System.Drawing.Size(622, 577);
            this.lvJournalStat.TabIndex = 0;
            this.lvJournalStat.UseCompatibleStateImageBehavior = false;
            this.lvJournalStat.View = System.Windows.Forms.View.Details;
            // 
            // tpGeography
            // 
            this.tpGeography.Controls.Add(this.lvGeography);
            this.tpGeography.Location = new System.Drawing.Point(4, 25);
            this.tpGeography.Name = "tpGeography";
            this.tpGeography.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeography.Size = new System.Drawing.Size(635, 587);
            this.tpGeography.TabIndex = 4;
            this.tpGeography.Text = "География";
            this.tpGeography.UseVisualStyleBackColor = true;
            // 
            // lvGeography
            // 
            this.lvGeography.Location = new System.Drawing.Point(7, 7);
            this.lvGeography.Name = "lvGeography";
            this.lvGeography.Size = new System.Drawing.Size(622, 574);
            this.lvGeography.TabIndex = 0;
            this.lvGeography.UseCompatibleStateImageBehavior = false;
            this.lvGeography.View = System.Windows.Forms.View.Details;
            // 
            // tpConf
            // 
            this.tpConf.Controls.Add(this.lvConferenceStat);
            this.tpConf.Location = new System.Drawing.Point(4, 25);
            this.tpConf.Name = "tpConf";
            this.tpConf.Padding = new System.Windows.Forms.Padding(3);
            this.tpConf.Size = new System.Drawing.Size(635, 587);
            this.tpConf.TabIndex = 5;
            this.tpConf.Text = "Конференции";
            this.tpConf.UseVisualStyleBackColor = true;
            // 
            // lvConferenceStat
            // 
            this.lvConferenceStat.Location = new System.Drawing.Point(7, 7);
            this.lvConferenceStat.Name = "lvConferenceStat";
            this.lvConferenceStat.Size = new System.Drawing.Size(622, 574);
            this.lvConferenceStat.TabIndex = 0;
            this.lvConferenceStat.UseCompatibleStateImageBehavior = false;
            this.lvConferenceStat.View = System.Windows.Forms.View.Details;
            // 
            // lvLibItems
            // 
            this.lvLibItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLibItems.FullRowSelect = true;
            this.lvLibItems.Location = new System.Drawing.Point(12, 189);
            this.lvLibItems.MultiSelect = false;
            this.lvLibItems.Name = "lvLibItems";
            this.lvLibItems.Size = new System.Drawing.Size(776, 555);
            this.lvLibItems.TabIndex = 2;
            this.lvLibItems.UseCompatibleStateImageBehavior = false;
            this.lvLibItems.View = System.Windows.Forms.View.Details;
            this.lvLibItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvItems_ItemSelectionChanged);
            this.lvLibItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvItems_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.классификацияToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1536, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.корпусДокументовToolStripMenuItem,
            this.библОписанияToolStripMenuItem,
            this.статистикуToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // корпусДокументовToolStripMenuItem
            // 
            this.корпусДокументовToolStripMenuItem.Name = "корпусДокументовToolStripMenuItem";
            this.корпусДокументовToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.корпусДокументовToolStripMenuItem.Text = "Корпус документов";
            this.корпусДокументовToolStripMenuItem.Click += new System.EventHandler(this.корпусДокументовToolStripMenuItem_Click);
            // 
            // библОписанияToolStripMenuItem
            // 
            this.библОписанияToolStripMenuItem.Name = "библОписанияToolStripMenuItem";
            this.библОписанияToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.библОписанияToolStripMenuItem.Text = "Библ. описания";
            this.библОписанияToolStripMenuItem.Click += new System.EventHandler(this.библОписанияToolStripMenuItem_Click);
            // 
            // статистикуToolStripMenuItem
            // 
            this.статистикуToolStripMenuItem.Name = "статистикуToolStripMenuItem";
            this.статистикуToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.статистикуToolStripMenuItem.Text = "Статистику";
            this.статистикуToolStripMenuItem.Click += new System.EventHandler(this.статистикуToolStripMenuItem_Click);
            // 
            // классификацияToolStripMenuItem
            // 
            this.классификацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.получитьToolStripMenuItem});
            this.классификацияToolStripMenuItem.Name = "классификацияToolStripMenuItem";
            this.классификацияToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.классификацияToolStripMenuItem.Text = "Классификация";
            // 
            // получитьToolStripMenuItem
            // 
            this.получитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.названияToolStripMenuItem,
            this.ключевыеСловаToolStripMenuItem,
            this.аннотацииToolStripMenuItem});
            this.получитьToolStripMenuItem.Name = "получитьToolStripMenuItem";
            this.получитьToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.получитьToolStripMenuItem.Text = "Получить";
            // 
            // названияToolStripMenuItem
            // 
            this.названияToolStripMenuItem.Name = "названияToolStripMenuItem";
            this.названияToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.названияToolStripMenuItem.Text = "Названия";
            this.названияToolStripMenuItem.Click += new System.EventHandler(this.названияToolStripMenuItem_Click);
            // 
            // ключевыеСловаToolStripMenuItem
            // 
            this.ключевыеСловаToolStripMenuItem.Name = "ключевыеСловаToolStripMenuItem";
            this.ключевыеСловаToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.ключевыеСловаToolStripMenuItem.Text = "Ключевые слова";
            this.ключевыеСловаToolStripMenuItem.Click += new System.EventHandler(this.ключевыеСловаToolStripMenuItem_Click);
            // 
            // аннотацииToolStripMenuItem
            // 
            this.аннотацииToolStripMenuItem.Name = "аннотацииToolStripMenuItem";
            this.аннотацииToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.аннотацииToolStripMenuItem.Text = "Аннотации";
            this.аннотацииToolStripMenuItem.Click += new System.EventHandler(this.аннотацииToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            this.фильтрыToolStripMenuItem.Click += new System.EventHandler(this.фильтрыToolStripMenuItem_Click);
            // 
            // lbCurrSelectedItem
            // 
            this.lbCurrSelectedItem.AutoSize = true;
            this.lbCurrSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrSelectedItem.Location = new System.Drawing.Point(343, 154);
            this.lbCurrSelectedItem.Name = "lbCurrSelectedItem";
            this.lbCurrSelectedItem.Size = new System.Drawing.Size(0, 29);
            this.lbCurrSelectedItem.TabIndex = 4;
            // 
            // btFirst
            // 
            this.btFirst.Location = new System.Drawing.Point(12, 65);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(126, 64);
            this.btFirst.TabIndex = 5;
            this.btFirst.Text = "Корпус первичных документов";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // btUnique
            // 
            this.btUnique.Location = new System.Drawing.Point(168, 65);
            this.btUnique.Name = "btUnique";
            this.btUnique.Size = new System.Drawing.Size(126, 64);
            this.btUnique.TabIndex = 6;
            this.btUnique.Text = "Корпус уникальных документов";
            this.btUnique.UseVisualStyleBackColor = true;
            this.btUnique.Click += new System.EventHandler(this.btUnique_Click);
            // 
            // btRelevance
            // 
            this.btRelevance.Location = new System.Drawing.Point(323, 65);
            this.btRelevance.Name = "btRelevance";
            this.btRelevance.Size = new System.Drawing.Size(126, 64);
            this.btRelevance.TabIndex = 7;
            this.btRelevance.Text = "Корпус релевантных документов";
            this.btRelevance.UseVisualStyleBackColor = true;
            this.btRelevance.Click += new System.EventHandler(this.btRelevance_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 28);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 24);
            this.toolStripMenuItem1.Text = "удалить";
            // 
            // pbLoadUniqueData
            // 
            this.pbLoadUniqueData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoadUniqueData.Location = new System.Drawing.Point(12, 750);
            this.pbLoadUniqueData.Name = "pbLoadUniqueData";
            this.pbLoadUniqueData.Size = new System.Drawing.Size(776, 23);
            this.pbLoadUniqueData.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 776);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1536, 25);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(163, 20);
            this.toolStripStatusLabel1.Text = "Last opened file name: ";
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(476, 67);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(222, 22);
            this.tbFind.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Поиск";
            // 
            // btNextFindedLibItem
            // 
            this.btNextFindedLibItem.Location = new System.Drawing.Point(749, 67);
            this.btNextFindedLibItem.Name = "btNextFindedLibItem";
            this.btNextFindedLibItem.Size = new System.Drawing.Size(39, 23);
            this.btNextFindedLibItem.TabIndex = 12;
            this.btNextFindedLibItem.Text = ">>";
            this.btNextFindedLibItem.UseVisualStyleBackColor = true;
            this.btNextFindedLibItem.Click += new System.EventHandler(this.btNextFindedLibItem_Click);
            // 
            // btPrevFindedLibItem
            // 
            this.btPrevFindedLibItem.Location = new System.Drawing.Point(704, 67);
            this.btPrevFindedLibItem.Name = "btPrevFindedLibItem";
            this.btPrevFindedLibItem.Size = new System.Drawing.Size(39, 23);
            this.btPrevFindedLibItem.TabIndex = 13;
            this.btPrevFindedLibItem.Text = "<<";
            this.btPrevFindedLibItem.UseVisualStyleBackColor = true;
            this.btPrevFindedLibItem.Click += new System.EventHandler(this.btPrevFindedLibItem_Click);
            // 
            // cbSearchCriterion
            // 
            this.cbSearchCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchCriterion.FormattingEnabled = true;
            this.cbSearchCriterion.Items.AddRange(new object[] {
            "По названию",
            "По аннотациям",
            "По авторам"});
            this.cbSearchCriterion.Location = new System.Drawing.Point(476, 99);
            this.cbSearchCriterion.Name = "cbSearchCriterion";
            this.cbSearchCriterion.Size = new System.Drawing.Size(222, 24);
            this.cbSearchCriterion.TabIndex = 14;
            this.cbSearchCriterion.SelectedIndexChanged += new System.EventHandler(this.cbSearchCriterion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Найдено";
            // 
            // labelFindedItemsCount
            // 
            this.labelFindedItemsCount.AutoSize = true;
            this.labelFindedItemsCount.Location = new System.Drawing.Point(794, 70);
            this.labelFindedItemsCount.Name = "labelFindedItemsCount";
            this.labelFindedItemsCount.Size = new System.Drawing.Size(0, 17);
            this.labelFindedItemsCount.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 801);
            this.Controls.Add(this.labelFindedItemsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSearchCriterion);
            this.Controls.Add(this.btPrevFindedLibItem);
            this.Controls.Add(this.btNextFindedLibItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbLoadUniqueData);
            this.Controls.Add(this.btRelevance);
            this.Controls.Add(this.btUnique);
            this.Controls.Add(this.btFirst);
            this.Controls.Add(this.lbCurrSelectedItem);
            this.Controls.Add(this.lvLibItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1554, 848);
            this.Name = "MainForm";
            this.Text = "BibReader";
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpData.PerformLayout();
            this.tpBib.ResumeLayout(false);
            this.tpStatistic.ResumeLayout(false);
            this.tabControlForStatistic.ResumeLayout(false);
            this.tpYearStat.ResumeLayout(false);
            this.tpSourses.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tpJournalStat.ResumeLayout(false);
            this.tpGeography.ResumeLayout(false);
            this.tpConf.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.TabPage tpBib;
        private System.Windows.Forms.RichTextBox rtbBib;
        private System.Windows.Forms.Label lbDoi;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbJournalName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbAuthors;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbSourse;
        private System.Windows.Forms.Label lbPublisher;
        private System.Windows.Forms.Label lbKeywords;
        private System.Windows.Forms.Label lbAbstract;
        private System.Windows.Forms.Label lbAffiliation;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.ListView lvLibItems;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbJournalName;
        private System.Windows.Forms.TextBox tbAbstract;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.TextBox tbSourсe;
        private System.Windows.Forms.TextBox tbKeywords;
        private System.Windows.Forms.TextBox tbAffiliation;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbDoi;
        private System.Windows.Forms.TextBox tbPages;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbPublisher;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.TabPage tpStatistic;
        private System.Windows.Forms.ListView lvYearStatistic;
        private System.Windows.Forms.Label lbCurrSelectedItem;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.Button btUnique;
        private System.Windows.Forms.Button btRelevance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ProgressBar pbLoadUniqueData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btNextFindedLibItem;
        private System.Windows.Forms.Button btPrevFindedLibItem;
        private System.Windows.Forms.ComboBox cbBibStyles;
        private System.Windows.Forms.Button btPrintBib;
        private System.Windows.Forms.ToolStripMenuItem классификацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem получитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem названияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ключевыеСловаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аннотацииToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlForStatistic;
        private System.Windows.Forms.TabPage tpYearStat;
        private System.Windows.Forms.TabPage tpSourses;
        private System.Windows.Forms.ListView lvSourceStatistic;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvTypeOfDoc;
        private System.Windows.Forms.ComboBox cbSearchCriterion;
        private System.Windows.Forms.Button btSaveStatistic;
        private System.Windows.Forms.TabPage tpJournalStat;
        private System.Windows.Forms.ListView lvJournalStat;
        private System.Windows.Forms.TabPage tpGeography;
        private System.Windows.Forms.ListView lvGeography;
        private System.Windows.Forms.TabPage tpConf;
        private System.Windows.Forms.ListView lvConferenceStat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFindedItemsCount;
        private System.Windows.Forms.Button btSaveBibRef;
        private System.Windows.Forms.ToolStripMenuItem корпусДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem библОписанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
    }
}

