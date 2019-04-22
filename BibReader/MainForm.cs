using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BibReader.Corpuses;
using BibReader.Statistic;
using BibReader.TypesOfSourse;
using System.Drawing;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace BibReader
{
    public partial class MainForm : Form
    {
        //HashSet<string> currTitles = new HashSet<string>();
        //Dictionary<string, int> currTitles = new Dictionary<string, int>();
        Stat statistic = new Stat();
        List<ListViewItem> deletedNotUniqueItems = new List<ListViewItem>();
        string lastOpenedFileName = string.Empty;
        List<int> indexesOfLibItems;
        int currIndex = -1;

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
            btFirst.Enabled = false;
            btUnique.Enabled = false;
            btRelevance.Enabled = false;
            cbBibStyles.SelectedIndex = 0;
            cbSearchCriterion.SelectedIndex = 0;
            // TryToLoadText();
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
            Unique unique = new Unique();

            foreach (ListViewItem item in lvLibItems.Items)
            {
                //var ed = 100;
                var title = ((LibItem)item.Tag).Title;
                if (unique.isUnique(title, item.Index))
                {
                    statistic.AddLibItemsCountAfterFirstResearch();
                    item.SubItems[2].Text = "2";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                    if (unique.ContainsKey(title))
                        unique.FindImportantData(
                            (LibItem)lvLibItems.Items[unique.IndexOfTitle(title)].Tag,
                            (LibItem)item.Tag
                            );
                }
                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            //Unique.ClearDictionary();
            MessageBox.Show("Готово!");
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

                if (Relevance.isRelevance(pages, authors))
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
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void LoadLibItemsInLv(List<LibItem> libItems)
        {
            lvLibItems.Items.Clear();
            statistic = new Stat();
            //Unique.ClearDictionary();
            currIndex = -1;
            deletedNotUniqueItems.Clear();
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

            UpdateUI();

            if (reader != null)
            {
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
                добавитьToolStripMenuItem.Enabled = true;
            }
        }

        private void ClearDataBeforeLoad()
        {
            lvSourceStatistic.Clear();
            lvYearStatistic.Clear();
            lbCurrSelectedItem.Text = "";
            rtbBib.Clear();
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
            UpdateUI();

            if (reader != null)
            {
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            //switch (e.TabPage.Name)
            //{

            //    case "tpYearStatistic":
            //        LoadYearStatistic();
            //        break;
            //    case "tpSourceStatistic":
            //        LoadSourseStatistic();
            //        break;
            //    case "tpBib":
            //        rtbBib.Text = string.Empty;
            //        try
            //        {
            //            MakeBibRef();
            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //        break;
            //}
        }

        private void LoadSourseStatistic()
        {
            lvSourceStatistic.Clear();
            statistic.DictOfSourses = new Dictionary<string, int>();
            statistic.DictOfSoursesUnique = new Dictionary<string, int>();
            statistic.DictOfSoursesRelevance = new Dictionary<string, int>();
            statistic.DictOfYears = new Dictionary<string, int>();
            statistic.DictOfTypes = new Dictionary<string, int>();
            statistic.DictOfJournal = new Dictionary<string, int>();
            statistic.DictOfConference = new Dictionary<string, int>();
            statistic.DictOfGeography = new Dictionary<string, int>();

            foreach (ListViewItem item in lvLibItems.Items)
            {
                statistic.SetYearStatistic((LibItem)item.Tag);
                statistic.SetTypesStatistic((LibItem)item.Tag);
                statistic.SetSourseStatictic((LibItem)item.Tag);
                //if (item.SubItems[2].Text != "1")
                statistic.SetSourseUniqueStatictic((LibItem)item.Tag);
                //if (item.SubItems[2].Text == "3")
                statistic.SetSourseRelevanceStatictic((LibItem)item.Tag);
                statistic.SetJournalStatistic((LibItem)item.Tag);
                statistic.SetConferenceStatistic((LibItem)item.Tag);
                statistic.SetGeographyStatistic((LibItem)item.Tag);
            }

            lvSourceStatistic.Columns.Add("Источник");
            lvSourceStatistic.Columns.Add("Первичных");
            lvSourceStatistic.Columns.Add("Уникальных");
            lvSourceStatistic.Columns.Add("Релевантных");
            lvSourceStatistic.Columns[0].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[1].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[2].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[3].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Items.AddRange(statistic.DictOfSourses.OrderBy(i => i.Key).
                Select(i => new ListViewItem(new string[] { (i.Key == "") ? "Неизв источник" : i.Key, i.Value.ToString(),
                    statistic.DictOfSoursesUnique[i.Key].ToString(), statistic.DictOfSoursesRelevance[i.Key].ToString() })).ToArray());
        }

        private void LoadYearStatistic()
        {
            lvYearStatistic.Clear();
            //foreach (ListViewItem item in lvLibItems.Items)
            //    statistic.SetYearStatistic((LibItem)item.Tag);
            lvYearStatistic.Columns.Add("Год");
            lvYearStatistic.Columns.Add("Количество");
            lvYearStatistic.Columns[0].Width = lvYearStatistic.Width / 2;
            lvYearStatistic.Columns[1].Width = lvYearStatistic.Width / 2;
            lvYearStatistic.Items.AddRange(statistic.DictOfYears.OrderBy(i => i.Key).
                Select(i => new ListViewItem(new string[] { (i.Key == "") ? "Без года" : i.Key, i.Value.ToString() })).ToArray());
        }

        private void LoadTypeStatistic()
        {
            lvTypeOfDoc.Clear();
            lvTypeOfDoc.Columns.Add("Тип документа");
            lvTypeOfDoc.Columns.Add("Количество");
            lvTypeOfDoc.Columns[0].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Columns[1].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Items.AddRange(statistic.DictOfTypes.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
        }

        private void LoadJournalStatistic()
        {
            lvJournalStat.Clear();
            lvJournalStat.Columns.Add("Название журнала");
            lvJournalStat.Columns.Add("Количество");
            lvJournalStat.Columns[0].Width = lvJournalStat.Width / 2;
            lvJournalStat.Columns[1].Width = lvJournalStat.Width / 2;
            lvJournalStat.Items.AddRange(statistic.DictOfJournal.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
        }

        private void LoadConferenceStatistic()
        {
            lvConferenceStat.Clear();
            lvConferenceStat.Columns.Add("Название конференции");
            lvConferenceStat.Columns.Add("Количество");
            lvConferenceStat.Columns[0].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Columns[1].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Items.AddRange(statistic.DictOfConference.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
        }

        private void LoadGeographyStatistic()
        {
            
            lvGeography.Clear();
            lvGeography.Columns.Add("Страна");
            lvGeography.Columns.Add("Количество");
            lvGeography.Columns[0].Width = lvGeography.Width / 2;
            lvGeography.Columns[1].Width = lvGeography.Width / 2;
            lvGeography.Items.AddRange(statistic.DictOfGeography.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
        }

        private void MakeBibRef()
        {
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var libItem = (LibItem)item.Tag;
                AuthorsParser parser = new AuthorsParser();
                parser.Authors = libItem.Authors;
                int volume, number, year;
                Int32.TryParse(libItem.Volume, out volume);
                Int32.TryParse(libItem.Number, out number);
                Int32.TryParse(libItem.Year, out year);
                var authors = parser.GetAuthors(libItem.Sourсe);
                switch (((LibItem)item.Tag).Type)
                {
                    case "conference":
                        var conf = new Conference(authors, libItem.Title, libItem.Publisher, libItem.Pages,
                            year, libItem.Address, libItem.Booktitle);
                        if (cbBibStyles.Text == "APA")
                            conf.MakeAPA(ref rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            conf.MakeHarvard(ref rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            conf.MakeIEEE(ref rtbBib);
                        else
                            conf.MakeGOST(ref rtbBib);
                        break;

                    case "book":
                        {
                            var book = new Book(authors, libItem.Title, "libItem.Address", libItem.Publisher,
                                year, volume, libItem.Pages, "",
                                DateTime.Parse(DateTime.Now.ToShortDateString()));
                            if (cbBibStyles.Text == "APA")
                                book.MakeAPA(ref rtbBib);
                            else if (cbBibStyles.Text == "Harvard")
                                book.MakeHarvard(ref rtbBib);
                            else if (cbBibStyles.Text == "IEEE")
                                book.MakeIEEE(ref rtbBib);
                            else
                                book.MakeGOST(ref rtbBib);
                            break;
                        }
                    case "journal":
                        var journal = new Journal(authors, libItem.Title, libItem.JournalName, libItem.Pages,
                            year, number, volume,
                            "", DateTime.Parse(DateTime.Now.ToShortDateString()));
                        if (cbBibStyles.Text == "APA")
                            journal.MakeAPA(ref rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            journal.MakeHarvard(ref rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            journal.MakeIEEE(ref rtbBib);
                        else
                            journal.MakeGOST(ref rtbBib);
                        break;
                }
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
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";

            UpdateUI();

            btUnique.Enabled = true;
            btFirst.Enabled = false;
            добавитьToolStripMenuItem.Enabled = true;

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

            UpdateUI();

            btRelevance.Enabled = true;
            btUnique.Enabled = false;
            добавитьToolStripMenuItem.Enabled = false;
        }

        private void btRelevance_Click(object sender, EventArgs e)
        {
            RelevanceData();
            UpdateUI();

            btFirst.Enabled = true;
            btRelevance.Enabled = false;
        }

        private void UpdateUI()
        {
            LoadSourseStatistic();
            LoadYearStatistic();
            LoadTypeStatistic();
            LoadJournalStatistic();
            LoadGeographyStatistic();
            LoadConferenceStatistic();

            rtbBib.Text = string.Empty;
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
            {
                tbAbstract.Text = string.Empty;
                tbAffiliation.Text = string.Empty;
                tbAuthors.Text = string.Empty;
                tbDoi.Text = string.Empty;
                tbJournalName.Text = string.Empty;
                tbKeywords.Text = string.Empty;
                tbNumber.Text = string.Empty;
                tbPages.Text = string.Empty;
                tbPublisher.Text = string.Empty;
                tbSourсe.Text = string.Empty;
                tbTitle.Text = string.Empty;
                tbUrl.Text = string.Empty;
                tbVolume.Text = string.Empty;
                tbYear.Text = string.Empty;
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";
            }
            try
            {
                MakeBibRef();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
            if (lvLibItems.Items.Count > 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0) { 
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Title = tbTitle.Text;
            lvLibItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
            }
        }

        private void tbAbstract_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Abstract = tbAbstract.Text;
        }

        private void tbJournalName_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).JournalName = tbJournalName.Text;
        }

        private void tbYear_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Year = tbYear.Text;
        }

        private void tbVolume_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Volume = tbVolume.Text;
        }

        private void tbPublisher_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Publisher = tbPublisher.Text;
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Number = tbNumber.Text;
        }

        private void tbPages_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Pages = tbPages.Text;
        }

        private void tbDoi_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Doi = tbDoi.Text;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Url = tbUrl.Text;
        }

        private void tbAffiliation_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Affiliation = tbAffiliation.Text;
        }

        private void tbKeywords_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Keywords = tbKeywords.Text;
        }

        private void tbSourсe_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Sourсe = tbSourсe.Text;
        }

        private void tbAuthors_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
            {
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
                lvLibItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
            }
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
                switch (cbSearchCriterion.SelectedIndex)
                {
                    case 0:
                        if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 1:
                        if (((LibItem)libItem.Tag).Affiliation.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 2:
                        if (libItem.SubItems[1].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                }
            }
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                // currIndex = indexesOfLibItems[0];
                currIndex = currIndex >= indexesOfLibItems.Last() || currIndex == -1
                    ? indexesOfLibItems.First()
                    : indexesOfLibItems.First(x => x > currIndex);
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
            
           
        }

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem libItem in lvLibItems.Items)
            {
                switch (cbSearchCriterion.SelectedIndex)
                {
                    case 0:
                        if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 1:
                        if (((LibItem)libItem.Tag).Affiliation.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 2:
                        if (libItem.SubItems[1].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                }
            }
            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                currIndex = currIndex <= indexesOfLibItems.First() || currIndex == -1
                    ? indexesOfLibItems.Last() 
                    : indexesOfLibItems.Last(x => x < currIndex);
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");

        }

        private void btPrintBib_Click(object sender, EventArgs e)
        {
            rtbBib.Text = string.Empty;
            MakeBibRef();
        }

        private void названияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string titles = string.Empty;
            foreach(var libItem in libItems)
            {
                if (libItem.Title != string.Empty)
                titles += libItem.Title + "\r\n";
            }
            var form = new ClassificationForm() { Info = titles };
            form.Show();
        }

        private void ключевыеСловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string keywords = string.Empty;
            foreach (var libItem in libItems)
            {
                if (libItem.Keywords != string.Empty)
                    keywords += libItem.Keywords + "\r\n";
            }
            var form = new ClassificationForm() { Info = keywords };
            form.Show();
        }

        private void аннотацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string abstract_ = string.Empty;
            foreach (var libItem in libItems)
            {
                if (libItem.Abstract != string.Empty)
                abstract_ += libItem.Abstract + "\r\n";
            }
            var form = new ClassificationForm() { Info = abstract_ };
            form.Show();
        }

        private void cbSearchCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            currIndex = -1;
        }

        private void lvLibItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = lvLibItems.ListViewItemSorter as ListViewItemComparer;

            if (sorter == null)
            {
                sorter = new ListViewItemComparer(e.Column);
                lvLibItems.ListViewItemSorter = sorter;
            }
            else
            {
                sorter.Column = e.Column;
            }

            lvLibItems.Sort();       
        }

        public class ListViewItemComparer : IComparer
        {
            private int column;
            private bool numeric = false;

            public int Column
            {
                get { return column; }
                set { column = value; }
            }

            public bool Numeric
            {
                get { return numeric; }
                set { numeric = value; }
            }

            public ListViewItemComparer(int columnIndex)
            {
                Column = columnIndex;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                if (itemX == null && itemY == null)
                    return 0;
                else if (itemX == null)
                    return -1;
                else if (itemY == null)
                    return 1;

                if (itemX == itemY) return 0;

                if (Numeric)
                {
                    decimal itemXVal, itemYVal;

                    if (!Decimal.TryParse(itemX.SubItems[Column].Text, out itemXVal))
                    {
                        itemXVal = 0;
                    }
                    if (!Decimal.TryParse(itemY.SubItems[Column].Text, out itemYVal))
                    {
                        itemYVal = 0;
                    }

                    return Decimal.Compare(itemXVal, itemYVal);
                }
                else
                {
                    string itemXText = itemX.SubItems[Column].Text;
                    string itemYText = itemY.SubItems[Column].Text;

                    return String.Compare(itemXText, itemYText);
                }
            }
        }

        private void btSaveStatistic_Click(object sender, EventArgs e)
        {
            using (var saveFile = new SaveFileDialog())
            {
                //MessageBox.Show(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib"));
                saveFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib");
                saveFile.Filter = "Файлы xls|*.xls";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;

                    var app = new Excel.Application();
                    //app.Visible = true;
                    var wb = app.Workbooks.Add(1);
                    ToExcel(wb, lvJournalStat);
                    ToExcel(wb, lvConferenceStat);
                    wb.SaveAs(filePath);
                    wb.Close();
                }
            }
        }

        private void ToExcel(Excel.Workbook wb, ListView list)
        {

            wb.Worksheets.Add();
            var ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = list.Name;
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in list.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                i2++;
            }
            
        }
    }
}
