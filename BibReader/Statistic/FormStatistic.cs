using BibReader.Publications;
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
        public void LoadSourseStatistic(ListView lvSourceStatistic)
        {
            lvSourceStatistic.Clear();
            lvSourceStatistic.Columns.Add("Источник");
            lvSourceStatistic.Columns.Add("Первичных");
            lvSourceStatistic.Columns.Add("Уникальных");
            lvSourceStatistic.Columns.Add("Релевантных");
            lvSourceStatistic.Columns[0].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[1].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[2].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Columns[3].Width = lvSourceStatistic.Width / 4;
            lvSourceStatistic.Items.AddRange(
                Stat.Sourses.OrderBy(i => i.Key).
                Select(i => new ListViewItem(
                    new string[] {
                        (i.Key == "") ? "Неизв источник" : i.Key,
                        i.Value.ToString(),
                        Stat.SoursesUnique[i.Key].ToString(),
                        Stat.SoursesRelevance[i.Key].ToString()
                    })
                )
                .ToArray()
            );
            lvSourceStatistic.Items.Add(new ListViewItem(
                new string[] {
                    "ИТОГО",
                    Stat.Sourses.Sum(i => i.Value).ToString(),
                    Stat.SoursesUnique.Sum(i => i.Value).ToString(),
                    Stat.SoursesRelevance.Sum(i => i.Value).ToString()
                }
            ));
        }

        public void LoadYearStatistic(ListView lvYearStatistic)
        {
            lvYearStatistic.Clear();
            lvYearStatistic.Columns.Add("Год");
            lvYearStatistic.Columns.Add("Количество");
            lvYearStatistic.Columns[0].Width = lvYearStatistic.Width / 2;
            lvYearStatistic.Columns[1].Width = lvYearStatistic.Width / 2;
            lvYearStatistic.Items.AddRange(
                Stat.Years.OrderBy(i => i.Key).
                Select(i => new ListViewItem(
                    new string[] { (i.Key == "") ? "Без года" : i.Key, i.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvYearStatistic.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Years.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadTypeStatistic(ListView lvTypeOfDoc)
        {
            lvTypeOfDoc.Clear();
            lvTypeOfDoc.Columns.Add("Тип документа");
            lvTypeOfDoc.Columns.Add("Количество");
            lvTypeOfDoc.Columns[0].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Columns[1].Width = lvTypeOfDoc.Width / 2;
            lvTypeOfDoc.Items.AddRange(
                Stat.Types.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvTypeOfDoc.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Types.Sum(i => i.Value).ToString(),
            }));

        }

        public void LoadJournalStatistic(ListView lvJournalStat)
        {
            lvJournalStat.Clear();
            lvJournalStat.Columns.Add("Название журнала");
            lvJournalStat.Columns.Add("Количество");
            lvJournalStat.Columns[0].Width = lvJournalStat.Width / 2;
            lvJournalStat.Columns[1].Width = lvJournalStat.Width / 2;
            lvJournalStat.Items.AddRange(
                Stat.Journal.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvJournalStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Journal.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadConferenceStatistic(ListView lvConferenceStat)
        {
            lvConferenceStat.Clear();
            lvConferenceStat.Columns.Add("Название конференции");
            lvConferenceStat.Columns.Add("Количество");
            lvConferenceStat.Columns[0].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Columns[1].Width = lvConferenceStat.Width / 2;
            lvConferenceStat.Items.AddRange(
                Stat.Conference.OrderBy(i => i.Key)
                .Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvConferenceStat.Items.Add(new ListViewItem(new string[] { "ИТОГО",
                Stat.Conference.Sum(i => i.Value).ToString(),
            }));
        }

        public void LoadGeographyStatistic(ListView lvGeography)
        {

            lvGeography.Clear();
            lvGeography.Columns.Add("Страна");
            lvGeography.Columns.Add("Количество");
            lvGeography.Columns[0].Width = lvGeography.Width / 2;
            lvGeography.Columns[1].Width = lvGeography.Width / 2;
            lvGeography.Items.AddRange(
                Stat.Geography.OrderBy(i => i.Key).
                Select(item => new ListViewItem(
                    new string[] { item.Key == "" ? "Неизвестный тип" : item.Key, item.Value.ToString() }
                    )
                )
                .ToArray()
            );
            lvGeography.Items.Add(new ListViewItem(
                new string[] { "ИТОГО",
                Stat.Geography.Sum(i => i.Value).ToString(),
            }));
        }
    }
}
