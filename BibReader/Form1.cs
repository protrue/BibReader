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
    public partial class MainForm : Form
    {
        HashSet<string> currTitles = new HashSet<string>();
        Statistic statistic = new Statistic();
        List<ListViewItem> deletedItems = new List<ListViewItem>();

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

            ed[0, 0] = (s[0] == t[0]) ? 0 : 1;
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
            lvItems.Columns[0].Width = lvItems.Width / 2;
            lvItems.Columns[1].Width = lvItems.Width / 2;

        }

        public MainForm()
        {
            InitializeComponent();
            InitListView();
            var readAll = new ReadAllHeaders();

        }

        private string Normalize(string sentence)
        {
            var resultContainer = new StringBuilder(100);
            var lowerSentece = sentence.ToLower();
            foreach (var c in lowerSentece)
            {
                if (char.IsLetterOrDigit(c) || c == ' ')
                {
                    resultContainer.Append(c);
                }
            }

            return resultContainer.ToString();
        }

        private void AddLibItemsInLv(List<LibItem> libItems, bool useLev)
        {
            foreach (var item in libItems)
            {
                statistic.AddLibItemsCount();

                var i = new ListViewItem(new string[]
                {
                    item.Title,
                    item.Authors
                });
                i.Tag = item;
                i.SubItems.Add("1");
                lvItems.Items.Add(i);
            }
            lvItems.Sorting = SortOrder.Ascending;
            lvItems.Sort();
            if (lvItems.Items.Count != 0)
            {
                lvItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvItems.Items.Count}";
            }
        }

        private int LevenshteinDistance(string word)
        {
            var min = 10000;
            int ed;
            foreach (var item in currTitles)
            {
                if (item == "" || item == null)
                    ed = 10000;
                else
                    ed = EditDistance(word, item);
                if (ed < min)
                    min = ed;
            }
            return min;
        }

        private void Unique()
        {
            foreach(ListViewItem item in lvItems.Items)
            {
                //var ed = 100;
                var title = Normalize(((LibItem)item.Tag).Title.ToLower());
                if (!currTitles.Contains(title) && LevenshteinDistance(title) > 5)
                {
                    currTitles.Add(title);
                    statistic.AddLibItemsCountAfterFirstResearch();
                    item.SubItems[2].Text = "2";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedItems.Add(item);
                }
            }
            currTitles.Clear();
        }

        private void Relevance()
        {
            foreach (ListViewItem item in lvItems.Items)
            {
                var ed = 100;
                //var ed = EditDistance("", "");
                var pages = ((LibItem)item.Tag).Pages;
                if (pages == "" || pages == string.Empty)
                {
                    item.Remove();
                    deletedItems.Add(item);
                    continue;
                }
                var pagesClone = "";
                for (int j = 0; j < pages.Length; j++)
                    if (!char.IsLetter(pages[j]))
                        pagesClone += pages[j];
                pages = pagesClone;
                string p1="", p2="";
                int i = 0;
                while (i<pages.Length && char.IsDigit(pages[i]))
                { p1 += pages[i]; i++; }
                while (i < pages.Length && !char.IsDigit(pages[i]))
                    i++;
                while (i < pages.Length)
                { p2 += pages[i]; i++; }
                int pageCount;
                try
                {
                    if (p2 != "" && ((pageCount = Convert.ToInt32(p2) - Convert.ToInt32(p1)) > 3) && ((LibItem)item.Tag).Authors != "")
                    {
                        item.SubItems[2].Text = "3";
                    }
                    else
                    {
                        item.Remove();
                        item.SubItems[2].Text = "1";
                        deletedItems.Add(item);
                    }
                }
                catch(Exception ex)
                {
                    item.SubItems[2].Text = "3";
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
            foreach (ListViewItem item in lvItems.Items)
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
                lbCurrSelectedItem.Text = $"{lvItems.SelectedIndices[0] + 1}/{lvItems.Items.Count}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = Read();
            var listOfItems = univReader.Read(reader);
            ClearDataBeforeLoad();
            LoadLibItemsInLv(listOfItems);
            
        }

        private void ClearDataBeforeLoad()
        {
            lvSourceStatistic.Clear();
            lvYearStatistic.Clear();
            lbCurrSelectedItem.Text = "";
            var tbs = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
            foreach (var tb in tbs)
                tb.Text = string.Empty;
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
            var listOfLibItems = new List<LibItem>();
            switch (e.TabPage.Name)
            {

                case "tpYearStatistic":
                    lvYearStatistic.Clear();
                    listOfLibItems = new List<LibItem>();
                    statistic.dictOfYears = new Dictionary<string, int>();
                    foreach (ListViewItem item in lvItems.Items)
                        statistic.SetYearStatistic((LibItem)item.Tag);
                    lvYearStatistic.Columns.Add("Год");
                    lvYearStatistic.Columns.Add("Количество");
                    lvYearStatistic.Columns[0].Width = lvYearStatistic.Width / 2;
                    lvYearStatistic.Columns[1].Width = lvYearStatistic.Width / 2;
                    lvYearStatistic.Items.AddRange(statistic.dictOfYears.OrderBy(i => i.Key).Select(i => new ListViewItem(new string[] { (i.Key == "") ? "Без года" : i.Key, i.Value.ToString() })).ToArray());
                    break;
                case "tpSourceStatistic":
                    lvSourceStatistic.Clear();
                    listOfLibItems = new List<LibItem>();
                    statistic.dictOfSourses = new Dictionary<string, int>();
                    foreach (ListViewItem item in lvItems.Items)
                        statistic.SetSourseStatictic((LibItem)item.Tag);
                    lvSourceStatistic.Columns.Add("Источник");
                    lvSourceStatistic.Columns.Add("Количество");
                    lvSourceStatistic.Columns[0].Width = lvSourceStatistic.Width / 2;
                    lvSourceStatistic.Columns[1].Width = lvSourceStatistic.Width / 2;
                    lvSourceStatistic.Items.AddRange(statistic.dictOfSourses.OrderBy(i => i.Key).Select(i => new ListViewItem(new string[] { (i.Key == "") ? "Неизв источник" : i.Key, i.Value.ToString() })).ToArray());
                    break;
            }
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            // вернуть все на место
            foreach(var item in deletedItems)
            {
                lvItems.Items.Add(item);
            }
            deletedItems.Clear();
            lvItems.Sorting = SortOrder.Ascending;
            lvItems.Sort();
        }

        private void btUnique_Click(object sender, EventArgs e)
        {
            Unique();
            foreach(var item in deletedItems)
            {
                if (item.SubItems[2].Text == "2")
                {
                    lvItems.Items.Add(item);
                }
            }
            deletedItems = deletedItems.Where(item => item.SubItems[2].Text != "2").ToList();
            lvItems.Sorting = SortOrder.Ascending;
            lvItems.Sort();
            if (lvItems.Items.Count != 0)
            {
                lvItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvItems.Items.Count}";
            }
        }

        private void btRelevance_Click(object sender, EventArgs e)
        {
            Relevance();
            if (lvItems.Items.Count != 0)
            {
                lvItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvItems.Items.Count}";
            }
        }

        private void lvItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvItems.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            lvItems.SelectedItems[0].Remove();
            ClearDataBeforeLoad();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Title = tbTitle.Text;
            lvItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
        }

        private void tbAbstract_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Abstract = tbAbstract.Text;
        }

        private void tbJournalName_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).JournalName = tbJournalName.Text;
        }

        private void tbYear_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Year = tbYear.Text;
        }

        private void tbVolume_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Volume = tbVolume.Text;
        }

        private void tbPublisher_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Publisher = tbPublisher.Text;
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Number = tbNumber.Text;
        }

        private void tbPages_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Pages = tbPages.Text;
        }

        private void tbDoi_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Doi = tbDoi.Text;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Url = tbUrl.Text;
        }

        private void tbAffiliation_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Affiliation = tbAffiliation.Text;
        }

        private void tbKeywords_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Keywords = tbKeywords.Text;
        }

        private void tbSourсe_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Sourсe = tbSourсe.Text;
        }

        private void tbAuthors_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
            lvItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
        }
    }
}
