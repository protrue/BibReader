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
            List<string> list1 = new List<string>() { "bool", "rofl", "lol" };
            List<int> list2 = new List<int>() { 2, 50, 1 };
            
            WordCloud.WordCloud wordCloud = new WordCloud.WordCloud(100, 100);
            var draw = wordCloud.Draw(list1, list2);
            pictBox.Image = draw;

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

            var words = new TagCloudAnalyzer().ComputeTagCloud(Info.Split(new string[] { "\r\n" }, StringSplitOptions.None));

            //Info = (string.Join(
            //    Environment.NewLine,
            //    words.Select(p => "[" + p.Count + "] \t" + p.Text).ToArray()));

            list1 = new List<string>(); list1.AddRange(words.Select(w => w.Text).ToArray());
            list2 = new List<int>(); list2.AddRange(words.Select(w => w.Count).ToArray());

            wordCloud = new WordCloud.WordCloud(pictBox.Width, pictBox.Height);
            draw = wordCloud.Draw(list1, list2);
            pictBox.Image = draw;

            // Console.ReadLine();

        }
    }
}
