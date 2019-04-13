using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sparc.TagCloud;

namespace BibReader
{
    public partial class ClusterizationForm : Form
    {
        IEnumerable<TagCloudTag> words;
        WordCloud.WordCloud wordCloud;

        public string Info
        {
            get => tbInfo.Text;
            set => tbInfo.Text = value;
        }

        public ClusterizationForm()
        {
            InitializeComponent();
        }

        private void ClusterizationForm_Load(object sender, EventArgs e)
        {
            TagCloudAnalyzer tagCloudAnalyzer = new TagCloudAnalyzer();
            TagCloudSetting tagCloudSetting = new TagCloudSetting();
            TagCloudTag tagCloudTag = new TagCloudTag();

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

            words = new TagCloudAnalyzer().ComputeTagCloud(Info.Split(new string[] { "\r\n" }, StringSplitOptions.None));

            //Info = (string.Join(
            //    Environment.NewLine,
            //    words.Select(p => "[" + p.Count + "] \t" + p.Text).ToArray()));

            wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);
            var image = wordCloud.Draw(
                words.Select(word => word.Text).ToList(),
                words.Select(word => word.Count).ToList()
                );
            pictBox.Image = image;
        }

        private void LoadWordAndFreqs()
        {
            foreach(var word in words)
            {
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
                lvFreqs.Items.Remove(item);
            }
        }

        private void tbRedraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);

            var image = wordCloud.Draw(
                lvFreqs.Items.Cast<ListViewItem>().Select(item => item.SubItems[0].Text).ToList(),
                lvFreqs.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.SubItems[1].Text)).ToList()
                );
            pictBox.Image = image;
        }
    }
}
