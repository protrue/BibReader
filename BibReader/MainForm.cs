using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BibReader.Corpuses;
using BibReader.Statistic;
using System.Drawing;
using System.Collections;
using BibReader.Saver;
using BibReader.ColumnSorting;
using BibReader.Readers;
using BibReader.Publications;
using BibReader.BibReference;
using BibReader.BibReference.TypesOfSourse;
using System.Reflection;

namespace BibReader
{
    public partial class MainForm : Form
    {
        // Сущности journalName и BookTitle разделить

        List<ListViewItem> deletedLibItems = new List<ListViewItem>();
        List<LibItem> libItems = new List<LibItem>();
        string lastOpenedFileName = string.Empty;
        int currIndex = -1;
        Finder.Finder finder = new Finder.Finder();

        private StreamReader[] GetStreamReaders()
        {
            using (var opd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Файлы bib|*.bib"
            })
            {
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    var streamReaders = new StreamReader[opd.FileNames.Length];
                    for (var i = 0; i < opd.FileNames.Length; i++)
                    {
                        var reader = new StreamReader(opd.FileNames[i]);
                        streamReaders[i] = reader;
                    }
                    lastOpenedFileName = opd.FileNames.Last();
                    return streamReaders;
                }
                return null;
            }
        }

        private void InitListViewItems()
        {
            lvLibItems.Columns.Add("Название");
            lvLibItems.Columns.Add("Авторы");
            lvLibItems.Columns[0].Width = lvLibItems.Width / 2;
            lvLibItems.Columns[1].Width = lvLibItems.Width / 2;
        }

        private void InitListViewEvent()
        {
            var lists = Controls.OfType<ListView>();
            var tps = tabControlForStatistic.TabPages;
            var listOfTables = new List<ListView>();
            foreach (TabPage tp in tps)
                listOfTables.Add(tp.Controls.OfType<ListView>().First());
            listOfTables.AddRange(lists);
            listOfTables.ForEach(listView => listView.ColumnClick += new ColumnClickEventHandler(
                (sender, e) => Sorting.SortingByColumn((ListView)sender, e.Column))
                );
        }

        private void InitTextBoxTextChangedEvent()
        {
            var textBoxes = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
            foreach (var tb in textBoxes)
                tb.TextChanged += TextBoxTextChanged;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            PropertyInfo info = null;
            if (lvLibItems.Items.Count != 0)
                info = ((LibItem)lvLibItems.SelectedItems[0].Tag).GetProperty(((TextBox)sender).Name);
            if (info != null)
                info.SetValue((LibItem)lvLibItems.SelectedItems[0].Tag, ((TextBox)sender).Text);
        }

        public MainForm()
        {
            InitializeComponent();
            InitListViewEvent();
            InitTextBoxTextChangedEvent();
            InitListViewItems();
            btFirst.Enabled = false;
            btUnique.Enabled = false;
            btRelevance.Enabled = false;
            cbBibStyles.SelectedIndex = 0;
            cbSearchCriterion.SelectedIndex = 0;
        }

        private void AddLibItemsInLvItems()
        {
            lvLibItems.Items.Clear();
            foreach (var item in Filters.Filter(libItems))
            {
                var lvItem = new ListViewItem(new string[]
                {
                    item.Title,
                    item.Authors,
                });

                lvItem.Tag = item;
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
            var unique = new Unique(lvLibItems.Items.Cast<ListViewItem>().Select(item => (LibItem)item.Tag).ToList());
            int i = 0;
            foreach (var item in unique.LibItemIndexesForDeleting)
            {
                deletedLibItems.Add(lvLibItems.Items[item - i]);
                lvLibItems.Items.RemoveAt(item - i);
                i++;
            }
            libItems = unique.UniqueLibItems;
            pbLoadUniqueData.Value = 100;
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

                if (!Relevance.isRelevance(pages, authors))
                {
                    deletedLibItems.Add(item);
                    item.Remove();
                    libItems.Remove((LibItem)item.Tag);
                }

                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void LoadLibItems()
        {
            lvLibItems.Items.Clear();
            currIndex = -1;
            deletedLibItems.Clear();
            AddLibItemsInLvItems();
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var item = (LibItem)((ListView)sender).SelectedItems[0].Tag;
                tbAbstract.Text = item.Abstract;
                tbAffiliation.Text = item.Affiliation;
                tbAuthors.Text = item.Authors;
                tbDoi.Text = item.Doi;
                tbJournalName.Text = item.JournalName != string.Empty
                    ? item.JournalName
                    : item.Booktitle;
                tbKeywords.Text = item.Keywords;
                tbNumber.Text = item.Number;
                tbPages.Text = item.Pages;
                tbPublisher.Text = item.Publisher;
                tbSourсe.Text = item.Sourсe;
                tbTitle.Text = item.Title;
                tbUrl.Text = item.Url;
                tbVolume.Text = item.Volume;
                tbYear.Text = item.Year;
                lbCurrSelectedItem.Text = $"{lvLibItems.SelectedIndices[0] + 1}/{lvLibItems.Items.Count}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var readers = GetStreamReaders();
            if (readers != null)
            {
                libItems.Clear();
                libItems.AddRange(univReader.Read(readers));
                LoadFilters();
                LoadLibItems();
                toolStripStatusLabel1.Text = "Last opened file name: " + lastOpenedFileName;
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
                добавитьToolStripMenuItem.Enabled = true;
                UpdateUI();
            }
        }

        private void LoadFilters()
        {
            UpdateStatistic();
            Filters.Clear();
            Filters.Conferences.AddRange(Stat.Conference.Keys.Select(key => key));
            Filters.Years.AddRange(Stat.Years.Keys.Select(key => key));
            Filters.Geography.AddRange(Stat.Geography.Keys.Select(key => key));
            Filters.Journals.AddRange(Stat.Journal.Keys.Select(key => key));
            Filters.Types.AddRange(Stat.Types.Keys.Select(key => key));
            Filters.Source.AddRange(Stat.Sources.Keys.Select(key => key));
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            if (reader != null)
            {
                libItems.AddRange(univReader.Read(reader));
                LoadFilters();
                AddLibItemsInLvItems();
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
                UpdateUI();
            }
        }

        private void MakeBibRef()
        {
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var libItem = (LibItem)item.Tag;
                //var parser = new AuthorsParser();
                //parser.Authors = libItem.Authors;
                Int32.TryParse(libItem.Volume, out int volume);
                Int32.TryParse(libItem.Number, out int number);
                Int32.TryParse(libItem.Year, out int year);
                var authors = AuthorsParser.ParseAuthors(libItem.Authors, libItem.Sourсe);
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
            lvLibItems.Items.AddRange(deletedLibItems.ToArray());
            deletedLibItems.Clear();
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
            libItems = lvLibItems.Items.Cast<ListViewItem>().Select(item => (LibItem)item.Tag).ToList();
            btUnique.Enabled = true;
            btFirst.Enabled = false;
            добавитьToolStripMenuItem.Enabled = true;
            UpdateUI();
        }

        private void btUnique_Click(object sender, EventArgs e)
        {
            UniqueTitles();
            btRelevance.Enabled = true;
            btUnique.Enabled = false;
            добавитьToolStripMenuItem.Enabled = false;
            UpdateUI();
        }

        private void btRelevance_Click(object sender, EventArgs e)
        {
            RelevanceData();
            btFirst.Enabled = true;
            btRelevance.Enabled = false;
            UpdateUI();
        }

        private void UpdateStatistic()
        {
            Stat.Corpus corpus = Stat.Corpus.First;
            if (btRelevance.Enabled)
                corpus = Stat.Corpus.Unique;
            if (btFirst.Enabled)
                corpus = Stat.Corpus.Relevance;

            Stat.CalculateStatistic(libItems, corpus);
            FormStatistic.LoadSourseStatistic(lvSourceStatistic);
            FormStatistic.LoadYearStatistic(lvYearStatistic);
            FormStatistic.LoadTypeStatistic(lvTypeOfDoc);
            FormStatistic.LoadJournalStatistic(lvJournalStat);
            FormStatistic.LoadGeographyStatistic(lvGeography);
            FormStatistic.LoadConferenceStatistic(lvConferenceStat);
        }

        private void UpdateUI()
        {
            UpdateStatistic();
            UpdateBibReference();
            SelectFstLibItem();
        }

        private void SelectFstLibItem()
        {
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
            {
                var textBoxes = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
                foreach (var tb in textBoxes)
                    tb.Text = string.Empty;
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";
            }
        }

        private void UpdateBibReference()
        {
            rtbBib.Text = string.Empty;
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
                if (lvLibItems.FocusedItem.Bounds.Contains(e.Location) == true)
                    contextMenuStrip1.Show(Cursor.Position);
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            lvLibItems.SelectedItems[0].Remove();
            SelectFstLibItem();
        }

        //private void tbTitle_TextChanged(object sender, EventArgs e)
        //{
        //    if (lvLibItems.Items.Count != 0) { 
        //    ((LibItem)lvLibItems.SelectedItems[0].Tag).Title = tbTitle.Text;
        //    lvLibItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
        //    }
        //}

        //private void tbAuthors_TextChanged(object sender, EventArgs e)
        //{
        //    if (lvLibItems.Items.Count != 0)
        //    {
        //        ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
        //        lvLibItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
        //    }
        //}

        private void btNextFindedLibItem_Click(object sender, EventArgs e)
        {
            switch (cbSearchCriterion.SelectedIndex)
            {
                case 0:
                    currIndex = finder.GetIndex(
                        Finder.Finder.MakeListOfIndexes(tbFind.Text, lvLibItems, 0),
                        Finder.Finder.Prev
                    );
                    break;
                case 1:
                    currIndex = finder.GetIndex(
                        Finder.Finder.MakeListOfIndexes(
                            tbFind.Text, 
                            lvLibItems.Items.Cast<ListViewItem>().Select(item => ((LibItem)item.Tag).Abstract).ToList()
                        ),
                        Finder.Finder.Prev
                    );
                    break;
                case 2:
                    currIndex = finder.GetIndex(
                        Finder.Finder.MakeListOfIndexes(tbFind.Text, lvLibItems, 1),
                        Finder.Finder.Prev
                    );
                    break;
            }
            Finder.Finder.SelectItem(lvLibItems, currIndex);
        }

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)
        {
            var indexesOfLibItems = new List<int>();
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
            labelFindedItemsCount.Text = indexesOfLibItems.Count.ToString();

            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                currIndex = 
                    currIndex <= indexesOfLibItems.First() || currIndex == -1
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
            string titles = string.Join("\r\n",
                libItems
                .Where(item => item.Title != string.Empty)
                .Select(item => item.Title)
                );
            var form = new ClassificationForm() { Info = titles };
            form.Show();
        }

        private void ключевыеСловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string keywords = string.Join("\r\n", 
                libItems
                .Where(item => item.Keywords != string.Empty)
                .Select(item => item.Keywords)
                );
            var form = new ClassificationForm() { Info = keywords };
            form.Show();
        }

        private void аннотацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string abstract_ = string.Join("\r\n", 
                libItems
                .Where(item => item.Abstract != string.Empty)
                .Select(item => item.Abstract)
                );
            var form = new ClassificationForm() { Info = abstract_ };
            form.Show();
        }

        private void cbSearchCriterion_SelectedIndexChanged(object sender, EventArgs e) => currIndex = -1;

        private void btSaveStatistic_Click(object sender, EventArgs e) => ExcelSaver.Save(GetStatisticListViews());

        private void btSaveBibRef_Click(object sender, EventArgs e) => DocSaver.Save(rtbBib);

        private void корпусДокументовToolStripMenuItem_Click(object sender, EventArgs e) => MyBibFormat.Save(libItems);

        private void библОписанияToolStripMenuItem_Click(object sender, EventArgs e) => DocSaver.Save(rtbBib);

        private void статистикуToolStripMenuItem_Click(object sender, EventArgs e) => ExcelSaver.Save(GetStatisticListViews());

        private List<ListView> GetStatisticListViews()
        {
            var listOfTables = new List<ListView>();
            foreach (TabPage tp in tabControlForStatistic.TabPages)
                listOfTables.Add(tp.Controls.OfType<ListView>().First());
            return listOfTables;
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FiltersForm()
            {
                Geography = Stat.Geography.Keys.ToList(),
                Sources = Stat.Sources.Keys.ToList(),
                Types = Stat.Types.Keys.ToList(),
                Journals = Stat.Journal.Keys.ToList(),
                Years = Stat.Years.Keys.ToList(),
                Conference = Stat.Conference.Keys.ToList()
            })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadLibItems();
                }
            }
        }
    }
}
