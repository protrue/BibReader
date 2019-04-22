using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Statistic
{
    public class Stat
    {
        int libItemCountFirst = 0;
        public int libItemCountAfterFirstResearch { get; private set; } = 0;
        public Dictionary<string, int> DictOfSourses { get; set; }
        public Dictionary<string, int> DictOfSoursesUnique { get; set; }
        public Dictionary<string, int> DictOfSoursesRelevance { get; set; }
        public Dictionary<string, int> DictOfYears { get; set; }
        public Dictionary<string, int> DictOfTypes { get; set; }
        public Dictionary<string, int> DictOfJournal { get; set; }
        public Dictionary<string, int> DictOfConference { get; set; }
        public Dictionary<string, int> DictOfGeography { get; set; }

        public void SetGeographyStatistic(LibItem libItem)
        {
            if (libItem.Affiliation != string.Empty)
            {
                var affs = libItem.Affiliation.Split(';').ToList();
                foreach (var aff in affs)
                {
                    var infoArray = aff.Split(',');

                    if (DictOfGeography.ContainsKey(infoArray.Last()))
                        DictOfGeography[infoArray.Last()]++;
                    else
                        DictOfGeography.Add(infoArray.Last(), 1);
                }
            }
        }

        public void SetYearStatistic(LibItem libItem)
        {
            if (DictOfYears.ContainsKey(libItem.Year))
                DictOfYears[libItem.Year]++;
            else
                DictOfYears.Add(libItem.Year, 1);
        }

        public void SetJournalStatistic(LibItem libItem)
        {
            if (libItem.Type == "journal" && libItem.JournalName != string.Empty)
            if (DictOfJournal.ContainsKey(libItem.JournalName))
                DictOfJournal[libItem.JournalName]++;
            else
                DictOfJournal.Add(libItem.JournalName, 1);
        }

        public void SetConferenceStatistic(LibItem libItem)
        {
            if (libItem.Type == "conference")
            {
                var title = libItem.Booktitle == string.Empty ? libItem.JournalName : libItem.Booktitle;
                if (DictOfConference.ContainsKey(title))
                    DictOfConference[title]++;
                else
                    DictOfConference.Add(title, 1);
            }
        }

        public void SetSourseStatictic(LibItem libItem)
        {
            if (DictOfSourses.ContainsKey(libItem.Sourсe))
                DictOfSourses[libItem.Sourсe]++;
            else
                DictOfSourses.Add(libItem.Sourсe, 1);
        }

        public void SetSourseUniqueStatictic(LibItem libItem)
        {
            if (DictOfSoursesUnique.ContainsKey(libItem.Sourсe))
                DictOfSoursesUnique[libItem.Sourсe]++;
            else
                DictOfSoursesUnique.Add(libItem.Sourсe, 1);
        }

        public void SetSourseRelevanceStatictic(LibItem libItem)
        {
            if (DictOfSoursesRelevance.ContainsKey(libItem.Sourсe))
                DictOfSoursesRelevance[libItem.Sourсe]++;
            else
                DictOfSoursesRelevance.Add(libItem.Sourсe, 1);
        }

        public void SetTypesStatistic(LibItem libItem)
        {
            if (DictOfTypes.ContainsKey(libItem.Type))
                DictOfTypes[libItem.Type]++;
            else
                DictOfTypes.Add(libItem.Type, 1);
        }

        public void AddLibItemsCount() => libItemCountFirst++;

        public void AddLibItemsCountAfterFirstResearch() => libItemCountAfterFirstResearch++;

    }
}
