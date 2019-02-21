using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BibReader.Blocks;
using BibReader.Statistic;
using BibReader.TypesOfSourse;

namespace BibReader
{
    public partial class MainForm : Form
    {
        //HashSet<string> currTitles = new HashSet<string>();
        Dictionary<string, int> currTitles = new Dictionary<string, int>();
        Stat statistic = new Stat();
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
                lastOpenedFileName = opd.FileNames.Last();
                return streamReaders;
            }
            return null;
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


        private void UniqueTitles()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;
            pbLoadUniqueData.Step = (int)step;

            foreach (ListViewItem item in lvLibItems.Items)
            {
                //var ed = 100;
                var title = ((LibItem)item.Tag).Title;
                if (WorkWithBlocks.isUnique(title, item.Index))
                {
                    statistic.AddLibItemsCountAfterFirstResearch();
                    item.SubItems[2].Text = "2";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                    if (WorkWithBlocks.ContainsKey(title))
                        WorkWithBlocks.FindImportantData(
                            (LibItem)lvLibItems.Items[WorkWithBlocks.IndexOfTitle(title)].Tag,
                            (LibItem)item.Tag
                            );
                }
                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            WorkWithBlocks.ClearDictionary();
            MessageBox.Show("Done");
            pbLoadUniqueData.Value = 0;
        }

     


        private void RelevanceData()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var pages = ((LibItem)item.Tag).Pages;
                var authors = ((LibItem)item.Tag).Authors;


                if (WorkWithBlocks.isRelevance(pages, authors))
                {
                    item.SubItems[2].Text = "3";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                }

                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            MessageBox.Show("Done");
            pbLoadUniqueData.Value = 0;
        }

        private void LoadLibItemsInLv(List<LibItem> libItems)
        {
            lvLibItems.Items.Clear();
            statistic = new Stat();
            WorkWithBlocks.ClearDictionary();
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
                case "tpBib":
                    foreach(ListViewItem item in lvLibItems.Items)
                    {
                        var libItem = (LibItem)item.Tag;
                        AuthorsParser parser = new AuthorsParser();
                        parser.Authors = libItem.Authors;
                        int a;
                        Int32.TryParse(libItem.Volume, out a);
                        if (((LibItem)item.Tag).Type == "inproceedings")
                        {
                            var book = new Book(parser.GetAuthors(4), libItem.Title, "libItem.location", libItem.Sourсe,
                                Convert.ToInt32(libItem.Year), a, libItem.Pages, "",
                                DateTime.Parse(DateTime.Now.ToShortDateString()));
                            book.MakeGOST(ref rtbBib);
                        }
                    }
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

            currIndex = indexesOfLibItems.First(x => x > currIndex);
            
            if (indexesOfLibItems.Count > 0 && currIndex == indexesOfLibItems.Last())
                currIndex = indexesOfLibItems.First();
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }

        }

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)

        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem libItem in lvLibItems.Items)
            {
                if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
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

            currIndex = indexesOfLibItems.Last(x => x < currIndex);
           
            if (indexesOfLibItems.Count > 0 && currIndex == indexesOfLibItems.First())
                currIndex = indexesOfLibItems.Last();
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }

        }
    }
}
