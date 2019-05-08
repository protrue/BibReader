using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibReader.Saver;
using Sparc.TagCloud;

namespace BibReader
{
    public partial class ClassificationForm : Form
    {
        List<int> indexesOfLibItems;
        int currIndex = -1;

        List<string> BlackList = new List<string>();
        IEnumerable<TagCloudTag> words;
        WordCloud.WordCloud wordCloud;

        TagCloudAnalyzer tagCloudAnalyzer = new TagCloudAnalyzer();
        TagCloudSetting tagCloudSetting = new TagCloudSetting();
        TagCloudTag tagCloudTag = new TagCloudTag();

        public string Info
        {
            get => tbInfo.Text;
            set => tbInfo.Text = value;
        }

        public ClassificationForm()
        {
            InitializeComponent();
        }

        private void ClusterizationForm_Load(object sender, EventArgs e)
        {
            //tagCloudTag.Category = 1;
            //tagCloudTag.Count = 100;
            //tagCloudTag.Text = "wow";

            //tagCloudSetting.Lemmatizer = new LemmaSharp.Lemmatizer();
            //tagCloudSetting.MaxCloudSize = 1000;
            //tagCloudSetting.NumCategories = 2;
            //var stop = tagCloudSetting.StopWords;
            //var regex = tagCloudSetting.WordFinder;

            //var tags = tagCloudAnalyzer.ComputeTagCloud(IEnumerable<string> phrases);
            //tags.Shuffle();

            tagCloudSetting.MaxCloudSize = 10;
            tagCloudAnalyzer = new TagCloudAnalyzer(tagCloudSetting);
            words = tagCloudAnalyzer.ComputeTagCloud(Info.Split(new string[] { "\r\n" }, StringSplitOptions.None));

            //Info = (string.Join(
            //    Environment.NewLine,
            //    words.Select(p => "[" + p.Count + "] \t" + p.Text).ToArray()));

            wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);
            var image = wordCloud.Draw(
                words.Select(word => word.Text).ToList(),
                words.Select(word => word.Count).ToList()
                );
            pictBox.Image = image;

            numericUpDown1.Value = tagCloudSetting.MaxCloudSize;

            var regex = tagCloudSetting.WordFinder;
            var stopWords = tagCloudSetting.StopWords;
            var lemmatizer = tagCloudSetting.Lemmatizer;
        }

        private void LoadWordAndFreqs()
        {
            lvFreqs.Items.Clear();
            foreach(var word in words)
            {
                if (!BlackList.Contains(word.Text))
                lvFreqs.Items.Add(
                    new ListViewItem(new string[] {
                        word.Text,
                        word.Count.ToString()
                    })
                    );
            }
            lvFreqs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvFreqs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch(e.TabPage.Name)
            {
                case "tpText":
                    
                    break;

                case "tpFreqs":
                    LoadWordAndFreqs();
                    break;
            }
        }

        private void btDeleteItems_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvFreqs.SelectedItems)
            {
                BlackList.Add(item.SubItems[0].Text);
                lvFreqs.Items.Remove(item);
            }
            tagCloudSetting.MaxCloudSize = (int)numericUpDown1.Value + BlackList.Count;
            tagCloudAnalyzer = new TagCloudAnalyzer(tagCloudSetting);
            words = tagCloudAnalyzer.ComputeTagCloud(Info.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            LoadWordAndFreqs();
        }

        private void tbRedraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            if (checkBox1.Checked)
                wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height, false, Color.Black);
            else
                wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);

            Image image;
            if(checkBoxFreq.Checked)
                image = wordCloud.Draw(
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => item.SubItems[0].Text + "(" + item.SubItems[1].Text + ")").ToList(),
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.SubItems[1].Text)).ToList()
                );
            else
                image = wordCloud.Draw(
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => item.SubItems[0].Text).ToList(),
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.SubItems[1].Text)).ToList()
                );
            pictBox.Image = image;
        }

        private void btSaveImage_Click(object sender, EventArgs e)
        {
            using (FileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "bmp(*.bmp) | *.bmp | jpeg(*.jpeg) | *.jpeg | png(*.png) | *.png | tiff(*.tiff) | *.tiff";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                    pictBox.Image.Save(fileDialog.FileName);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tagCloudSetting.MaxCloudSize = (int)numericUpDown1.Value + BlackList.Count;
            tagCloudAnalyzer = new TagCloudAnalyzer(tagCloudSetting);
            words = tagCloudAnalyzer.ComputeTagCloud(Info.Split(new string[] { "\r\n" }, StringSplitOptions.None));

            LoadWordAndFreqs();
            // Draw();
        }

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem freqs in lvFreqs.Items)
            {
                if (freqs.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                    indexesOfLibItems.Add(freqs.Index);
            }
            if (indexesOfLibItems.Count > 0)
            {
                lvFreqs.Select();
                currIndex = currIndex <= indexesOfLibItems.First() || currIndex == -1
                    ? indexesOfLibItems.Last()
                    : indexesOfLibItems.Last(x => x < currIndex);
                foreach (ListViewItem item in lvFreqs.SelectedItems)
                    item.Selected = false;
                lvFreqs.Items[currIndex].Selected = true;
                lvFreqs.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
        }

        private void btNextFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem freqs in lvFreqs.Items)
            {
                if (freqs.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                    indexesOfLibItems.Add(freqs.Index);
            }
            if (indexesOfLibItems.Count > 0)
            {
                lvFreqs.Select();
                // currIndex = indexesOfLibItems[0];
                currIndex = currIndex >= indexesOfLibItems.Last() || currIndex == -1
                    ? indexesOfLibItems.First()
                    : indexesOfLibItems.First(x => x > currIndex);
                foreach (ListViewItem item in lvFreqs.SelectedItems)
                    item.Selected = false;
                lvFreqs.Items[currIndex].Selected = true;
                lvFreqs.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height, false, Color.Black);
            else
                wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);

        }

        private void tbSaveFreqsInExcel_Click(object sender, EventArgs e)
        {
            ExcelSaver.Save(new List<ListView>() { lvFreqs });
        }
    }
}
