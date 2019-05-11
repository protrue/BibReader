using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Statistic
{
    public class Stat
    {
        public static Dictionary<string, int> Sourses            { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> SoursesUnique      { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> SoursesRelevance   { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Years              { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Types              { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Journal            { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Conference         { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Geography          { get; private set; } = new Dictionary<string, int>();

        public enum Corpus
        {
            First,
            Unique,
            Relevance
        }

        public static void CalculateStatistic(List<LibItem> libItems, Corpus corpus)
        {
            if (corpus == Corpus.First)
            {
                Sourses = new Dictionary<string, int>();
                SoursesUnique = new Dictionary<string, int>();
                SoursesRelevance = new Dictionary<string, int>();
            }
            Years = new Dictionary<string, int>();
            Types = new Dictionary<string, int>();
            Journal = new Dictionary<string, int>();
            Conference = new Dictionary<string, int>();
            Geography = new Dictionary<string, int>();

            foreach (var item in libItems)
            {
                SetYearStatistic(item);
                SetTypesStatistic(item);
                if (corpus == Corpus.First)
                    SetSourseStatictic(item);
                if (corpus == Corpus.Unique)
                    SetSourseUniqueStatictic(item);
                if (corpus == Corpus.Relevance)
                    SetSourseRelevanceStatictic(item);
                SetJournalStatistic(item);
                SetConferenceStatistic(item);
                SetGeographyStatistic(item);
            }
        }


        private static void SetGeographyStatistic(LibItem libItem)
        {
            if (libItem.Affiliation != string.Empty)
            {
                var affs = libItem.Affiliation.Split(';').ToList();
                foreach (var aff in affs)
                {
                    var infoArray = aff.Split(',');

                    if (Geography.ContainsKey(infoArray.Last()))
                        Geography[infoArray.Last()]++;
                    else
                        Geography.Add(infoArray.Last(), 1);
                }
            }
        }

        private static void SetYearStatistic(LibItem libItem)
        {
            if (Years.ContainsKey(libItem.Year))
                Years[libItem.Year]++;
            else
                Years.Add(libItem.Year, 1);
        }

        private static void SetJournalStatistic(LibItem libItem)
        {
            if (libItem.Type == "journal" && libItem.JournalName != string.Empty)
            if (Journal.ContainsKey(libItem.JournalName))
                Journal[libItem.JournalName]++;
            else
                Journal.Add(libItem.JournalName, 1);
        }

        private static void SetConferenceStatistic(LibItem libItem)
        {
            if (libItem.Type == "conference")
            {
                var title = libItem.Booktitle == string.Empty ? libItem.JournalName : libItem.Booktitle;
                if (Conference.ContainsKey(title))
                    Conference[title]++;
                else
                    Conference.Add(title, 1);
            }
        }

        private static void SetSourseStatictic(LibItem libItem)
        {
            if (Sourses.ContainsKey(libItem.Sourсe))
                Sourses[libItem.Sourсe]++;
            else
            {
                Sourses.Add(libItem.Sourсe, 1);
                SoursesUnique.Add(libItem.Sourсe, 0);
                SoursesRelevance.Add(libItem.Sourсe, 0);
            }
        }

        private static void SetSourseUniqueStatictic(LibItem libItem)
        {
            if (SoursesUnique.ContainsKey(libItem.Sourсe))
                SoursesUnique[libItem.Sourсe]++;
            else
                SoursesUnique.Add(libItem.Sourсe, 1);
        }

        private static void SetSourseRelevanceStatictic(LibItem libItem)
        {
            if (SoursesRelevance.ContainsKey(libItem.Sourсe))
                SoursesRelevance[libItem.Sourсe]++;
            else
                SoursesRelevance.Add(libItem.Sourсe, 1);
        }

        private static void SetTypesStatistic(LibItem libItem)
        {
            if (Types.ContainsKey(libItem.Type))
                Types[libItem.Type]++;
            else
                Types.Add(libItem.Type, 1);
        }
    }
}
