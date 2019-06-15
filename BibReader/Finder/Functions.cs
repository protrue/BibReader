using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Finder
{
    class Functions
    {
        public static int Prev(List<int> indexes, int currentIndex) =>
            currentIndex <= indexes.First() || currentIndex == -1
            ? indexes.Last()
            : indexes.Last(x => x < currentIndex);

        public static int Next(List<int> indexes, int currentIndex) =>
            currentIndex >= indexes.Last() || currentIndex == -1
            ? indexes.First()
            : indexes.First(x => x > currentIndex);
    }
}
