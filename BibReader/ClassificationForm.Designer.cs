namespace BibReader
{
    partial class ClassificationForm
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
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpText = new System.Windows.Forms.TabPage();
            this.tpFreqs = new System.Windows.Forms.TabPage();
            this.tbSaveFreqsInExcel = new System.Windows.Forms.Button();
            this.btDeleteItems = new System.Windows.Forms.Button();
            this.lvFreqs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPrevFindedLibItem = new System.Windows.Forms.Button();
            this.btNextFindedLibItem = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.tbRedraw = new System.Windows.Forms.Button();
            this.btSaveImage = new System.Windows.Forms.Button();
            this.nudWordsCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxImageIsBlack = new System.Windows.Forms.CheckBox();
            this.checkBoxFreq = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpFreqs.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWordsCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.Location = new System.Drawing.Point(6, 6);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(756, 464);
            this.tbInfo.TabIndex = 0;
            // 
            // pictBox
            // 
            this.pictBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictBox.Location = new System.Drawing.Point(794, 13);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(650, 418);
            this.pictBox.TabIndex = 1;
            this.pictBox.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpText);
            this.tabControl1.Controls.Add(this.tpFreqs);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 505);
            this.tabControl1.TabIndex = 2;
            // 
            // tpText
            // 
            this.tpText.Controls.Add(this.tbInfo);
            this.tpText.Location = new System.Drawing.Point(4, 25);
            this.tpText.Name = "tpText";
            this.tpText.Padding = new System.Windows.Forms.Padding(3);
            this.tpText.Size = new System.Drawing.Size(768, 476);
            this.tpText.TabIndex = 0;
            this.tpText.Text = "Текст";
            this.tpText.UseVisualStyleBackColor = true;
            // 
            // tpFreqs
            // 
            this.tpFreqs.Controls.Add(this.tbSaveFreqsInExcel);
            this.tpFreqs.Controls.Add(this.btDeleteItems);
            this.tpFreqs.Controls.Add(this.lvFreqs);
            this.tpFreqs.Controls.Add(this.groupBox1);
            this.tpFreqs.Location = new System.Drawing.Point(4, 25);
            this.tpFreqs.Name = "tpFreqs";
            this.tpFreqs.Padding = new System.Windows.Forms.Padding(3);
            this.tpFreqs.Size = new System.Drawing.Size(768, 476);
            this.tpFreqs.TabIndex = 1;
            this.tpFreqs.Text = "Частота";
            this.tpFreqs.UseVisualStyleBackColor = true;
            // 
            // tbSaveFreqsInExcel
            // 
            this.tbSaveFreqsInExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSaveFreqsInExcel.Location = new System.Drawing.Point(7, 428);
            this.tbSaveFreqsInExcel.Name = "tbSaveFreqsInExcel";
            this.tbSaveFreqsInExcel.Size = new System.Drawing.Size(144, 42);
            this.tbSaveFreqsInExcel.TabIndex = 19;
            this.tbSaveFreqsInExcel.Text = "Сохранить в Excel";
            this.tbSaveFreqsInExcel.UseVisualStyleBackColor = true;
            this.tbSaveFreqsInExcel.Click += new System.EventHandler(this.tbSaveFreqsInExcel_Click);
            // 
            // btDeleteItems
            // 
            this.btDeleteItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeleteItems.Location = new System.Drawing.Point(7, 390);
            this.btDeleteItems.Name = "btDeleteItems";
            this.btDeleteItems.Size = new System.Drawing.Size(144, 28);
            this.btDeleteItems.TabIndex = 1;
            this.btDeleteItems.Text = "Удалить";
            this.btDeleteItems.UseVisualStyleBackColor = true;
            this.btDeleteItems.Click += new System.EventHandler(this.btDeleteItems_Click);
            // 
            // lvFreqs
            // 
            this.lvFreqs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFreqs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvFreqs.FullRowSelect = true;
            this.lvFreqs.Location = new System.Drawing.Point(7, 7);
            this.lvFreqs.Name = "lvFreqs";
            this.lvFreqs.Size = new System.Drawing.Size(755, 376);
            this.lvFreqs.TabIndex = 0;
            this.lvFreqs.UseCompatibleStateImageBehavior = false;
            this.lvFreqs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Слово";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Количество";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 106;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btPrevFindedLibItem);
            this.groupBox1.Controls.Add(this.btNextFindedLibItem);
            this.groupBox1.Controls.Add(this.tbFind);
            this.groupBox1.Location = new System.Drawing.Point(430, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 63);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // btPrevFindedLibItem
            // 
            this.btPrevFindedLibItem.Location = new System.Drawing.Point(242, 21);
            this.btPrevFindedLibItem.Name = "btPrevFindedLibItem";
            this.btPrevFindedLibItem.Size = new System.Drawing.Size(39, 23);
            this.btPrevFindedLibItem.TabIndex = 17;
            this.btPrevFindedLibItem.Text = "<<";
            this.btPrevFindedLibItem.UseVisualStyleBackColor = true;
            this.btPrevFindedLibItem.Click += new System.EventHandler(this.btPrevFindedLibItem_Click);
            // 
            // btNextFindedLibItem
            // 
            this.btNextFindedLibItem.Location = new System.Drawing.Point(287, 21);
            this.btNextFindedLibItem.Name = "btNextFindedLibItem";
            this.btNextFindedLibItem.Size = new System.Drawing.Size(39, 23);
            this.btNextFindedLibItem.TabIndex = 16;
            this.btNextFindedLibItem.Text = ">>";
            this.btNextFindedLibItem.UseVisualStyleBackColor = true;
            this.btNextFindedLibItem.Click += new System.EventHandler(this.btNextFindedLibItem_Click);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(14, 21);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(222, 22);
            this.tbFind.TabIndex = 14;
            // 
            // tbRedraw
            // 
            this.tbRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRedraw.Location = new System.Drawing.Point(794, 437);
            this.tbRedraw.Name = "tbRedraw";
            this.tbRedraw.Size = new System.Drawing.Size(120, 32);
            this.tbRedraw.TabIndex = 1;
            this.tbRedraw.Text = "Перерисовать";
            this.tbRedraw.UseVisualStyleBackColor = true;
            this.tbRedraw.Click += new System.EventHandler(this.tbRedraw_Click);
            // 
            // btSaveImage
            // 
            this.btSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveImage.Location = new System.Drawing.Point(794, 475);
            this.btSaveImage.Name = "btSaveImage";
            this.btSaveImage.Size = new System.Drawing.Size(120, 43);
            this.btSaveImage.TabIndex = 3;
            this.btSaveImage.Text = "Сохранить картинку";
            this.btSaveImage.UseVisualStyleBackColor = true;
            this.btSaveImage.Click += new System.EventHandler(this.btSaveImage_Click);
            // 
            // nudWordsCount
            // 
            this.nudWordsCount.Location = new System.Drawing.Point(6, 25);
            this.nudWordsCount.Name = "nudWordsCount";
            this.nudWordsCount.Size = new System.Drawing.Size(135, 22);
            this.nudWordsCount.TabIndex = 4;
            this.nudWordsCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxImageIsBlack);
            this.groupBox2.Controls.Add(this.nudWordsCount);
            this.groupBox2.Location = new System.Drawing.Point(938, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 81);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Количество слов";
            // 
            // checkBoxImageIsBlack
            // 
            this.checkBoxImageIsBlack.AutoSize = true;
            this.checkBoxImageIsBlack.Location = new System.Drawing.Point(6, 54);
            this.checkBoxImageIsBlack.Name = "checkBoxImageIsBlack";
            this.checkBoxImageIsBlack.Size = new System.Drawing.Size(119, 21);
            this.checkBoxImageIsBlack.TabIndex = 5;
            this.checkBoxImageIsBlack.Text = "Черно-белый";
            this.checkBoxImageIsBlack.UseVisualStyleBackColor = true;
            // 
            // checkBoxFreq
            // 
            this.checkBoxFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFreq.AutoSize = true;
            this.checkBoxFreq.Location = new System.Drawing.Point(1139, 447);
            this.checkBoxFreq.Name = "checkBoxFreq";
            this.checkBoxFreq.Size = new System.Drawing.Size(131, 21);
            this.checkBoxFreq.TabIndex = 6;
            this.checkBoxFreq.Text = "Слово+частота";
            this.checkBoxFreq.UseVisualStyleBackColor = true;
            // 
            // ClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 530);
            this.Controls.Add(this.checkBoxFreq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btSaveImage);
            this.Controls.Add(this.tbRedraw);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictBox);
            this.MinimumSize = new System.Drawing.Size(1473, 577);
            this.Name = "ClassificationForm";
            this.Text = "Classification";
            this.Load += new System.EventHandler(this.ClusterizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpText.ResumeLayout(false);
            this.tpText.PerformLayout();
            this.tpFreqs.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWordsCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpText;
        private System.Windows.Forms.TabPage tpFreqs;
        private System.Windows.Forms.ListView lvFreqs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btDeleteItems;
        private System.Windows.Forms.Button tbRedraw;
        private System.Windows.Forms.Button btSaveImage;
        private System.Windows.Forms.NumericUpDown nudWordsCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btPrevFindedLibItem;
        private System.Windows.Forms.Button btNextFindedLibItem;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxImageIsBlack;
        private System.Windows.Forms.Button tbSaveFreqsInExcel;
        private System.Windows.Forms.CheckBox checkBoxFreq;
    }
}