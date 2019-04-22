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
        public Dictionary<string, int> DictOfYears { get; set; }
        public Dictionary<string, int> DictOfTypes { get; set; }
        public Dictionary<string, int> DictOfjournal { get; set; }

        public void SetYearStatistic(LibItem libItem)
        {
            if (DictOfYears.ContainsKey(libItem.Year))
                DictOfYears[libItem.Year]++;
            else
                DictOfYears.Add(libItem.Year, 1);
        }

        public void SetSourseStatictic(LibItem libItem)
        {
            if (DictOfSourses.ContainsKey(libItem.Sourсe))
                DictOfSourses[libItem.Sourсe]++;
            else
                DictOfSourses.Add(libItem.Sourсe, 1);
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
