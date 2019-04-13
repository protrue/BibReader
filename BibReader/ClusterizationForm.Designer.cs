namespace BibReader
{
    partial class ClusterizationForm
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
            this.lvFreqs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbRedraw = new System.Windows.Forms.Button();
            this.btDeleteItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpFreqs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.tabControl1.Controls.Add(this.tpText);
            this.tabControl1.Controls.Add(this.tpFreqs);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 505);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
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
            this.tpFreqs.Controls.Add(this.btDeleteItems);
            this.tpFreqs.Controls.Add(this.lvFreqs);
            this.tpFreqs.Location = new System.Drawing.Point(4, 25);
            this.tpFreqs.Name = "tpFreqs";
            this.tpFreqs.Padding = new System.Windows.Forms.Padding(3);
            this.tpFreqs.Size = new System.Drawing.Size(768, 476);
            this.tpFreqs.TabIndex = 1;
            this.tpFreqs.Text = "Частота";
            this.tpFreqs.UseVisualStyleBackColor = true;
            // 
            // lvFreqs
            // 
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
            // tbRedraw
            // 
            this.tbRedraw.Location = new System.Drawing.Point(794, 437);
            this.tbRedraw.Name = "tbRedraw";
            this.tbRedraw.Size = new System.Drawing.Size(120, 32);
            this.tbRedraw.TabIndex = 1;
            this.tbRedraw.Text = "Перерисовать";
            this.tbRedraw.UseVisualStyleBackColor = true;
            this.tbRedraw.Click += new System.EventHandler(this.tbRedraw_Click);
            // 
            // btDeleteItems
            // 
            this.btDeleteItems.Location = new System.Drawing.Point(7, 390);
            this.btDeleteItems.Name = "btDeleteItems";
            this.btDeleteItems.Size = new System.Drawing.Size(144, 28);
            this.btDeleteItems.TabIndex = 1;
            this.btDeleteItems.Text = "Удалить";
            this.btDeleteItems.UseVisualStyleBackColor = true;
            this.btDeleteItems.Click += new System.EventHandler(this.btDeleteItems_Click);
            // 
            // ClusterizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 530);
            this.Controls.Add(this.tbRedraw);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictBox);
            this.Name = "ClusterizationForm";
            this.Text = "Clusterization";
            this.Load += new System.EventHandler(this.ClusterizationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpText.ResumeLayout(false);
            this.tpText.PerformLayout();
            this.tpFreqs.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}