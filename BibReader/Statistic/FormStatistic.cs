using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Statistic
{
    class FormStatistic
    {
        Stat statistic = new Stat();

        public void LoadSourseStatistic(ListView lvLibItems, ListView lvSourceStatistic, Button btFirst, Button btUnique, Button btRelevance)
        {
            lvSourceStatistic.Clear();
            if (btUnique.Enabled)
            {
                statistic.DictOfSourses = new Dictionary<string, int>();
                statistic.DictOfSoursesUnique = new Dictionary<string, int>();
                statistic.DictOfSoursesRelevance = new Dictionary<string, int>();
            }
            statistic.DictOfYears = new Dictionary<string, int>();
            statistic.DictOfTypes = new Dictionary<string, int>();
            statistic.DictOfJournal = new Dictionary<string, int>();
            statistic.DictOfConference = new Dictionary<string, int>();
            statistic.DictOfGeography = new Dictionary<string, int>();

            foreach (ListViewItem item in lvLibItems.Items)
            {
                statistic.SetYearStatistic((LibItem)item.Tag);
                statistic.SetTypesStatistic((LibItem)item.Tag);
                if (btUnique.Enabled)
                    statistic.SetSourseStatictic((LibItem)item.Tag);
                if (btRelevance.Enabled)
                    statistic.SetSourseUniqueStatictic((LibItem)item.Tag);
                if (btFirst.Enabled)
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
            lvSourceStatistic.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfSourses.Sum(i => i.Value).ToString(),
                statistic.DictOfSoursesUnique.Sum(i => i.Value).ToString(),
                statistic.DictOfSoursesRelevance.Sum(i => i.Value).ToString()
            }));
        }

        public void LoadYearStatistic(ListView lvYearStatistic)
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
            lvYearStatistic.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfYears.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadTypeStatistic(ListView lvTypeOfDoc)
        {
            lvTypeOfDoc.Clear();
            lvTypeOfDoc.Columns.Add("Тип документа");
            lvTypeOfDoc.Columns.Add("Количество");
            lvTypeOfDoc.Columns[0].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Columns[1].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Items.AddRange(statistic.DictOfTypes.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
            lvTypeOfDoc.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfTypes.Sum(i => i.Value).ToString(),
            }));

        }

        public void LoadJournalStatistic(ListView lvJournalStat)
        {
            lvJournalStat.Clear();
            lvJournalStat.Columns.Add("Название журнала");
            lvJournalStat.Columns.Add("Количество");
            lvJournalStat.Columns[0].Width = lvJournalStat.Width / 2;
            lvJournalStat.Columns[1].Width = lvJournalStat.Width / 2;
            lvJournalStat.Items.AddRange(statistic.DictOfJournal.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
            lvJournalStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfJournal.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadConferenceStatistic(ListView lvConferenceStat)
        {
            lvConferenceStat.Clear();
            lvConferenceStat.Columns.Add("Название конференции");
            lvConferenceStat.Columns.Add("Количество");
            lvConferenceStat.Columns[0].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Columns[1].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Items.AddRange(statistic.DictOfConference.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
            lvConferenceStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfConference.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadGeographyStatistic(ListView lvGeography)
        {

            lvGeography.Clear();
            lvGeography.Columns.Add("Страна");
            lvGeography.Columns.Add("Количество");
            lvGeography.Columns[0].Width = lvGeography.Width / 2;
            lvGeography.Columns[1].Width = lvGeography.Width / 2;
            lvGeography.Items.AddRange(statistic.DictOfGeography.OrderBy(i => i.Key).
                Select(item => new ListViewItem(new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() })).ToArray());
            lvGeography.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                statistic.DictOfGeography.Sum(i => i.Value).ToString(),
            }));
        }
    }
}
