namespace BibReader
{
    partial class FiltersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlForStatistic = new System.Windows.Forms.TabControl();
            this.tpYearStat = new System.Windows.Forms.TabPage();
            this.lvYearStat = new System.Windows.Forms.ListView();
            this.tpSourses = new System.Windows.Forms.TabPage();
            this.lvSourceStat = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvTypeStat = new System.Windows.Forms.ListView();
            this.tpJournalStat = new System.Windows.Forms.TabPage();
            this.lvJournalStat = new System.Windows.Forms.ListView();
            this.tpGeography = new System.Windows.Forms.TabPage();
            this.lvGeographyStat = new System.Windows.Forms.ListView();
            this.tpConf = new System.Windows.Forms.TabPage();
            this.lvConferenceStat = new System.Windows.Forms.ListView();
            this.btOk = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.tabControlForStatistic.SuspendLayout();
            this.tpYearStat.SuspendLayout();
            this.tpSourses.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpJournalStat.SuspendLayout();
            this.tpGeography.SuspendLayout();
            this.tpConf.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlForStatistic
            // 
            this.tabControlForStatistic.Controls.Add(this.tpYearStat);
            this.tabControlForStatistic.Controls.Add(this.tpSourses);
            this.tabControlForStatistic.Controls.Add(this.tabPage1);
            this.tabControlForStatistic.Controls.Add(this.tpJournalStat);
            this.tabControlForStatistic.Controls.Add(this.tpGeography);
            this.tabControlForStatistic.Controls.Add(this.tpConf);
            this.tabControlForStatistic.Location = new System.Drawing.Point(12, 12);
            this.tabControlForStatistic.Name = "tabControlForStatistic";
            this.tabControlForStatistic.SelectedIndex = 0;
            this.tabControlForStatistic.Size = new System.Drawing.Size(510, 427);
            this.tabControlForStatistic.TabIndex = 2;
            // 
            // tpYearStat
            // 
            this.tpYearStat.Controls.Add(this.lvYearStat);
            this.tpYearStat.Location = new System.Drawing.Point(4, 25);
            this.tpYearStat.Name = "tpYearStat";
            this.tpYearStat.Padding = new System.Windows.Forms.Padding(3);
            this.tpYearStat.Size = new System.Drawing.Size(502, 398);
            this.tpYearStat.TabIndex = 0;
            this.tpYearStat.Text = "Годы";
            this.tpYearStat.UseVisualStyleBackColor = true;
            // 
            // lvYearStat
            // 
            this.lvYearStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvYearStat.Location = new System.Drawing.Point(6, 6);
            this.lvYearStat.Name = "lvYearStat";
            this.lvYearStat.Size = new System.Drawing.Size(490, 386);
            this.lvYearStat.TabIndex = 0;
            this.lvYearStat.UseCompatibleStateImageBehavior = false;
            this.lvYearStat.View = System.Windows.Forms.View.Details;
            // 
            // tpSourses
            // 
            this.tpSourses.Controls.Add(this.lvSourceStat);
            this.tpSourses.Location = new System.Drawing.Point(4, 25);
            this.tpSourses.Name = "tpSourses";
            this.tpSourses.Padding = new System.Windows.Forms.Padding(3);
            this.tpSourses.Size = new System.Drawing.Size(502, 398);
            this.tpSourses.TabIndex = 1;
            this.tpSourses.Text = "Источники";
            this.tpSourses.UseVisualStyleBackColor = true;
            // 
            // lvSourceStat
            // 
            this.lvSourceStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSourceStat.Location = new System.Drawing.Point(6, 6);
            this.lvSourceStat.Name = "lvSourceStat";
            this.lvSourceStat.Size = new System.Drawing.Size(490, 386);
            this.lvSourceStat.TabIndex = 1;
            this.lvSourceStat.UseCompatibleStateImageBehavior = false;
            this.lvSourceStat.View = System.Windows.Forms.View.Details;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvTypeStat);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(502, 398);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Тип документа";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvTypeStat
            // 
            this.lvTypeStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTypeStat.Location = new System.Drawing.Point(6, 6);
            this.lvTypeStat.Name = "lvTypeStat";
            this.lvTypeStat.Size = new System.Drawing.Size(490, 386);
            this.lvTypeStat.TabIndex = 0;
            this.lvTypeStat.UseCompatibleStateImageBehavior = false;
            this.lvTypeStat.View = System.Windows.Forms.View.Details;
            // 
            // tpJournalStat
            // 
            this.tpJournalStat.Controls.Add(this.lvJournalStat);
            this.tpJournalStat.Location = new System.Drawing.Point(4, 25);
            this.tpJournalStat.Name = "tpJournalStat";
            this.tpJournalStat.Padding = new System.Windows.Forms.Padding(3);
            this.tpJournalStat.Size = new System.Drawing.Size(502, 398);
            this.tpJournalStat.TabIndex = 3;
            this.tpJournalStat.Text = "Журналы";
            this.tpJournalStat.UseVisualStyleBackColor = true;
            // 
            // lvJournalStat
            // 
            this.lvJournalStat.Location = new System.Drawing.Point(7, 4);
            this.lvJournalStat.Name = "lvJournalStat";
            this.lvJournalStat.Size = new System.Drawing.Size(489, 388);
            this.lvJournalStat.TabIndex = 0;
            this.lvJournalStat.UseCompatibleStateImageBehavior = false;
            this.lvJournalStat.View = System.Windows.Forms.View.Details;
            // 
            // tpGeography
            // 
            this.tpGeography.Controls.Add(this.lvGeographyStat);
            this.tpGeography.Location = new System.Drawing.Point(4, 25);
            this.tpGeography.Name = "tpGeography";
            this.tpGeography.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeography.Size = new System.Drawing.Size(502, 398);
            this.tpGeography.TabIndex = 4;
            this.tpGeography.Text = "География";
            this.tpGeography.UseVisualStyleBackColor = true;
            // 
            // lvGeographyStat
            // 
            this.lvGeographyStat.Location = new System.Drawing.Point(7, 7);
            this.lvGeographyStat.Name = "lvGeographyStat";
            this.lvGeographyStat.Size = new System.Drawing.Size(489, 385);
            this.lvGeographyStat.TabIndex = 0;
            this.lvGeographyStat.UseCompatibleStateImageBehavior = false;
            this.lvGeographyStat.View = System.Windows.Forms.View.Details;
            // 
            // tpConf
            // 
            this.tpConf.Controls.Add(this.lvConferenceStat);
            this.tpConf.Location = new System.Drawing.Point(4, 25);
            this.tpConf.Name = "tpConf";
            this.tpConf.Padding = new System.Windows.Forms.Padding(3);
            this.tpConf.Size = new System.Drawing.Size(502, 398);
            this.tpConf.TabIndex = 5;
            this.tpConf.Text = "Конференции";
            this.tpConf.UseVisualStyleBackColor = true;
            // 
            // lvConferenceStat
            // 
            this.lvConferenceStat.Location = new System.Drawing.Point(7, 7);
            this.lvConferenceStat.Name = "lvConferenceStat";
            this.lvConferenceStat.Size = new System.Drawing.Size(489, 385);
            this.lvConferenceStat.TabIndex = 0;
            this.lvConferenceStat.UseCompatibleStateImageBehavior = false;
            this.lvConferenceStat.View = System.Windows.Forms.View.Details;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(12, 446);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(93, 38);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(418, 446);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(94, 38);
            this.BtCancel.TabIndex = 4;
            this.BtCancel.Text = "Отмена";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 492);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tabControlForStatistic);
            this.Name = "FiltersForm";
            this.Text = "FiltersForm";
            this.Load += new System.EventHandler(this.FiltersForm_Load);
            this.tabControlForStatistic.ResumeLayout(false);
            this.tpYearStat.ResumeLayout(false);
            this.tpSourses.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tpJournalStat.ResumeLayout(false);
            this.tpGeography.ResumeLayout(false);
            this.tpConf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlForStatistic;
        private System.Windows.Forms.TabPage tpYearStat;
        private System.Windows.Forms.ListView lvYearStat;
        private System.Windows.Forms.TabPage tpSourses;
        private System.Windows.Forms.ListView lvSourceStat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvTypeStat;
        private System.Windows.Forms.TabPage tpJournalStat;
        private System.Windows.Forms.ListView lvJournalStat;
        private System.Windows.Forms.TabPage tpGeography;
        private System.Windows.Forms.ListView lvGeographyStat;
        private System.Windows.Forms.TabPage tpConf;
        private System.Windows.Forms.ListView lvConferenceStat;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button BtCancel;
    }
}