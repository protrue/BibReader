using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReaderLibrary
{
    public class Statistic
    {
        int libItemCountFirst = 0;
        int libItemCountAfterFirstResearch = 0;
        public Dictionary<string, int> dictOfSourses { get; set; }
        public Dictionary<string, int> dictOfYears { get; set; }
        public Dictionary<string, int> dictOfjournal { get; set; }

        public void SetYearStatistic(LibItem libItem)
        {
            if (dictOfYears.ContainsKey(libItem.Year))
                dictOfYears[libItem.Year]++;
            else
                dictOfYears.Add(libItem.Year, 0);
        }

        public void AddLibItemsCount()
        {
            libItemCountFirst++;
        }

        public void AddLibItemsCountAfterFirstResearch()
        {
            libItemCountAfterFirstResearch++;
        }

        public int LibItemsAfterFirstResearch => libItemCountAfterFirstResearch;
        
    }
}
