using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using BibReaderLibrary;

namespace BibReader
{
    public partial class Form1 : Form
    {
        HashSet<string> currTitles = new HashSet<string>();
        Statistic statistic = new Statistic();


        public StreamReader Read()
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Файлы bib|*.bib";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                var stream = opd.OpenFile();
                StreamReader reader = new StreamReader(stream);
                return reader;
            }
            return null;
        }

        public static int EditDistance(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[,] ed = new int[m, n];

            ed[0,0] = (s[0] == t[0]) ? 0 : 1;
            for (int i = 1; i < m; i++)
            {
                ed[i, 0] = ed[i - 1, 0] + 1;
            }

            for (int j = 1; j < n; j++)
            {
                ed[0, j] = ed[0, j - 1] + 1;
            }

            for (int j = 1; j < n; j++)
            {
                for (int i = 1; i < m; i++)
                {
                    if (s[i] == t[j])
                    {
                        // Операция не требуется
                        ed[i, j] = ed[i - 1, j - 1];
                    }
                    else
                    {
                        // Минимум между удалением, вставкой и заменой
                        ed[i, j] = Math.Min(ed[i - 1, j] + 1,
                            Math.Min(ed[i, j - 1] + 1, ed[i - 1, j - 1] + 1));
                    }
                }
            }

            return ed[m - 1, n - 1];
        }

        private void InitListView()
        {
            lvItems.Columns.Add("Название");
            lvItems.Columns.Add("Авторы");
        }

        public Form1()
        {
            InitializeComponent();
            InitListView();
            var scopusBibReader = new ScopusBibReader();
            var webOfScienceReder = new WebOfScienceBibReader();
            var scienceDirectBibReader = new ScienceDirectBibReader();
            var readAll = new ReadAllHeaders();

        }

        private void AddLibItemsInLv(List<LibItem> libItems, bool useLev)
        {
            foreach (var item in libItems)
            {
                statistic.AddLibItemsCount();
                var ed = 0;
                if (useLev)
                    ed = EditDistance("", "");
                if (!currTitles.Contains(item.Title.ToLower()) && ed < 5)
                {
                    statistic.AddLibItemsCountAfterFirstResearch();
                    var i = new ListViewItem(new string[]
                    {
                        item.Title,
                        item.Authors
                    });
                    i.Tag = item;
                    lvItems.Items.Add(i);
                    currTitles.Add(item.Title.ToLower());
                }
            }
        }

        private void LoadLibItemsInLv(List<LibItem> libItems)
        {
            lvItems.Items.Clear();
            statistic = new Statistic();
            currTitles.Clear();
            AddLibItemsInLv(libItems, false);
        }

        private List<LibItem> GetLibItemsFromLv()
        {
            var libItems = new List<LibItem>();
            foreach(ListViewItem item in lvItems.Items)
                libItems.Add((LibItem)item.Tag);
            return libItems;
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                tbAbstract.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Abstract;
                tbAffiliation.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Affiliation;
                tbAuthors.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Authors;
                tbDoi.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Doi;
                tbJournalName.Text = ((LibItem)lvItems.SelectedItems[0].Tag).JournalName;
                tbKeywords.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Keywords;
                tbNumber.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Number;
                tbPages.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Pages;
                tbPublisher.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Publisher;
                tbSourсe.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Sourсe;
                tbTitle.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Title;
                tbUrl.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Url;
                tbVolume.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Volume;
                tbYear.Text = ((LibItem)lvItems.SelectedItems[0].Tag).Year;
                lbCurrSelectedItem.Text = $"{lvItems.SelectedIndices[0]}/{statistic.libItemCountAfterFirstResearch}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = Read();
            var listOfItems = univReader.Read(reader);
            reader.Close();
            LoadLibItemsInLv(listOfItems);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFile = new SaveFileDialog())
            {
                //MessageBox.Show(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib"));
                saveFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib");
                saveFile.Filter = "Файлы bib|*.bib";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    MyBibFormat bibFormat = new MyBibFormat();
                    var libItems = GetLibItemsFromLv();
                    bibFormat.Write(libItems, filePath);
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = Read();
            var listOfItems = univReader.Read(reader);
            reader.Close();
            AddLibItemsInLv(listOfItems, false);

        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            lvYearStatistic.Clear();
            var listOfLibItems = new List<LibItem>();
            statistic.dictOfYears = new Dictionary<string, int>();
            foreach (ListViewItem item in lvItems.Items)
                statistic.SetYearStatistic((LibItem)item.Tag);
            lvYearStatistic.Columns.Add("Год");
            lvYearStatistic.Columns.Add("Количество");
            lvYearStatistic.Items.AddRange(statistic.dictOfYears.OrderBy(i => i.Key).Select(i => new ListViewItem(new string[] { i.Key, i.Value.ToString() })).ToArray());
            
        }
    }
}
