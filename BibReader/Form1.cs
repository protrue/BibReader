using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BibReaderLibrary;

namespace BibReader
{
    public partial class MainForm : Form
    {
        //HashSet<string> currTitles = new HashSet<string>();
        Dictionary<string, int> currTitles = new Dictionary<string, int>();
        Statistic statistic = new Statistic();
        List<ListViewItem> deletedNotUniqueItems = new List<ListViewItem>();
        string lastOpenedFileName = string.Empty;
        List<int> indexesOfLibItems;
        int currIndex = 0;

        public StreamReader[] GetStreamReaders()
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Multiselect = true;
            opd.Filter = "Файлы bib|*.bib";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                StreamReader[] streamReaders = new StreamReader[opd.FileNames.Length];
                for(var i =0;i<opd.FileNames.Length;i++)
                {
                    var reader = new StreamReader(opd.FileNames[i]);
                    streamReaders[i] = reader;
                }
                return streamReaders;
            }
            return null;
        }

        public static int EditDistance(string fstWord, string sndWord)
        {
            int fstWordLength = fstWord.Length, sndWordLength = sndWord.Length;
            int[,] ed = new int[fstWordLength, sndWordLength];

            ed[0, 0] = (fstWord[0] == sndWord[0]) ? 0 : 1;
            for (int i = 1; i < fstWordLength; i++)
            {
                ed[i, 0] = ed[i - 1, 0] + 1;
            }

            for (int j = 1; j < sndWordLength; j++)
            {
                ed[0, j] = ed[0, j - 1] + 1;
            }

            for (int j = 1; j < sndWordLength; j++)
            {
                for (int i = 1; i < fstWordLength; i++)
                {
                    if (fstWord[i] == sndWord[j])
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

            return ed[fstWordLength - 1, sndWordLength - 1];
        }

        private void InitListViewItems()
        {
            lvLibItems.Columns.Add("Название");
            lvLibItems.Columns.Add("Авторы");
            lvLibItems.Columns[0].Width = lvLibItems.Width / 2;
            lvLibItems.Columns[1].Width = lvLibItems.Width / 2;

        }

        public MainForm()
        {
            InitializeComponent();
            InitListViewItems();
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

        private void AddLibItemsInLvItems(List<LibItem> libItems)
        {
            foreach (var item in libItems)
            {
                statistic.AddLibItemsCount();

                var lvItem = new ListViewItem(new string[]
                {
                    item.Title,
                    item.Authors
                });

                lvItem.Tag = item;
                lvItem.SubItems.Add("1");
                lvLibItems.Items.Add(lvItem);
            }
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private int LevenshteinDistance(string word)
        {
            var minDistance = 10000;
            int ed;
            foreach (var title in currTitles.Keys)
            {
                if (title == "" || title == null)
                    ed = 10000;
                else
                    ed = EditDistance(word, title);
                if (ed < minDistance)
                    minDistance = ed;
            }
            return minDistance;
        }

        private void UniqueTitles()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;
            pbLoadUniqueData.Step = (int)step;

            foreach (ListViewItem item in lvLibItems.Items)
            {
                //var ed = 100;
                var title = Normalize(((LibItem)item.Tag).Title.ToLower());
                if (!currTitles.Keys.Contains(title) && LevenshteinDistance(title) > 5)
                {
                    currTitles.Add(title, item.Index);
                    statistic.AddLibItemsCountAfterFirstResearch();
                    item.SubItems[2].Text = "2";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                    FindImportantData((LibItem)lvLibItems.Items[currTitles[title]].Tag, (LibItem)item.Tag);
                }
                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            currTitles.Clear();
        }

        private void FindImportantData(LibItem savedItem, LibItem currItem)
        {
            AbstractComplement(savedItem, currItem);
            KeywordsComplement(savedItem, currItem);
        }

        private void KeywordsComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.KeywordsIsEmpty && !currItem.KeywordsIsEmpty)
                savedItem.Keywords = currItem.Keywords;
        }

        private void AbstractComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.AbstractIsEmpty && !currItem.AbstractIsEmpty)
                savedItem.Abstract = currItem.Abstract;

        }

        private bool isRelevancePages(string pages)
        {
            if (pages == "" || pages == string.Empty)
                return false;

            var pagesClone = "";
            for (int j = 0; j < pages.Length; j++)
                if (!char.IsLetter(pages[j]))
                    pagesClone += pages[j];
            pages = pagesClone;

            string pageBegin = "", pageEnd = "";
            int i = 0;
            while (i < pages.Length && char.IsDigit(pages[i]))
            { pageBegin += pages[i]; i++; }
            while (i < pages.Length && !char.IsDigit(pages[i]))
                i++;
            while (i < pages.Length)
            { pageEnd += pages[i]; i++; }

            try
            {
                if (pageEnd != "" && (Convert.ToInt32(pageEnd) - Convert.ToInt32(pageBegin)) > 3)
                    return true;
            }
            catch(Exception ex)
            {
                return true;
            }

            return false;
        }

        private void RelevanceData()
        {
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var pages = ((LibItem)item.Tag).Pages;
               
                if (isRelevancePages(pages) && ((LibItem)item.Tag).Authors != "")
                {
                    item.SubItems[2].Text = "3";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                }
            }
        }

        private void LoadLibItemsInLv(List<LibItem> libItems)
        {
            lvLibItems.Items.Clear();
            statistic = new Statistic();
            currTitles.Clear();
            currIndex = 0;
            AddLibItemsInLvItems(libItems);
        }

        private List<LibItem> GetListOfLibItemsFromLv()
        {
            var libItems = new List<LibItem>();
            foreach (ListViewItem item in lvLibItems.Items)
                libItems.Add((LibItem)item.Tag);
            return libItems;
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                tbAbstract.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Abstract;
                tbAffiliation.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Affiliation;
                tbAuthors.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors;
                tbDoi.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Doi;
                tbJournalName.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).JournalName;
                tbKeywords.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Keywords;
                tbNumber.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Number;
                tbPages.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Pages;
                tbPublisher.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Publisher;
                tbSourсe.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Sourсe;
                tbTitle.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Title;
                tbUrl.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Url;
                tbVolume.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Volume;
                tbYear.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Year;
                lbCurrSelectedItem.Text = $"{lvLibItems.SelectedIndices[0] + 1}/{lvLibItems.Items.Count}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            var listOfItems = univReader.Read(reader);
            ClearDataBeforeLoad();
            LoadLibItemsInLv(listOfItems);
            toolStripStatusLabel1.Text = "Last opened file name: " + lastOpenedFileName;
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
                    var libItems = GetListOfLibItemsFromLv();
                    bibFormat.Write(libItems, filePath);
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            var listOfItems = univReader.Read(reader);
            AddLibItemsInLvItems(listOfItems);
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
                    foreach (ListViewItem item in lvLibItems.Items)
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
                    foreach (ListViewItem item in lvLibItems.Items)
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
            foreach(var item in deletedNotUniqueItems)
            {
                lvLibItems.Items.Add(item);
            }
            deletedNotUniqueItems.Clear();
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
        }

        private void btUnique_Click(object sender, EventArgs e)
        {
            pbLoadUniqueData.Value = 0;
            UniqueTitles();
            foreach(var item in deletedNotUniqueItems)
            {
                if (item.SubItems[2].Text == "2")
                {
                    lvLibItems.Items.Add(item);
                }
            }
            deletedNotUniqueItems = deletedNotUniqueItems.Where(item => item.SubItems[2].Text != "2").ToList();
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private void btRelevance_Click(object sender, EventArgs e)
        {
            RelevanceData();
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private void lvItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvLibItems.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            lvLibItems.SelectedItems[0].Remove();
            ClearDataBeforeLoad();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Title = tbTitle.Text;
            lvLibItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
        }

        private void tbAbstract_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Abstract = tbAbstract.Text;
        }

        private void tbJournalName_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).JournalName = tbJournalName.Text;
        }

        private void tbYear_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Year = tbYear.Text;
        }

        private void tbVolume_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Volume = tbVolume.Text;
        }

        private void tbPublisher_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Publisher = tbPublisher.Text;
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Number = tbNumber.Text;
        }

        private void tbPages_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Pages = tbPages.Text;
        }

        private void tbDoi_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Doi = tbDoi.Text;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Url = tbUrl.Text;
        }

        private void tbAffiliation_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Affiliation = tbAffiliation.Text;
        }

        private void tbKeywords_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Keywords = tbKeywords.Text;
        }

        private void tbSourсe_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Sourсe = tbSourсe.Text;
        }

        private void tbAuthors_TextChanged(object sender, EventArgs e)
        {
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
            lvLibItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            //lvLibItems.Items[40].Selected = true;
        }

        private void btNextFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem libItem in lvLibItems.Items)
            {
                if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower())>=0)
                    indexesOfLibItems.Add(libItem.Index);
            }
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                lvLibItems.EnsureVisible(indexesOfLibItems[0]);
                // currIndex = indexesOfLibItems[0];
                lvLibItems.Items[currIndex].Selected = true;
            }
            else
                MessageBox.Show("Элементы не найдены!");
            foreach (var index in indexesOfLibItems)
            {
                if (index > currIndex)
                {
                    currIndex = index;
                    break;
                }
            }
            if (indexesOfLibItems.Count > 0 && currIndex == indexesOfLibItems.Last())
                currIndex = indexesOfLibItems.First();
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }

        }
    }
}
