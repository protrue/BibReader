using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader
{
    public partial class ClusterizationForm : Form
    {
        public string Info
        {
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
            
            WordCloud.WordCloud wordCloud = new WordCloud.WordCloud(50, 425);
            list2.Sort();
            var draw = wordCloud.Draw(list1, list2);
            pictureBox1.Image = draw;
        }
    }
}
