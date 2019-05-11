using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Corpuses
{
    class Relevance
    {
        public static bool isRelevance(string pages, string authors) => isRelevancePages(pages) && authors != "";

        private static bool isRelevancePages(string pages)
        {
            if (pages == "" || pages == string.Empty)
                return false;

            var pagesClone = "";
            for (int j = 0; j < pages.Length; j++)
                if (!char.IsLetter(pages[j]))
                    pagesClone += pages[j];
            pages = pagesClone;

            string pageBegin = "", pageEnd = "";
            int i = 0;
            while (i < pages.Length && char.IsDigit(pages[i]))
            { pageBegin += pages[i]; i++; }
            while (i < pages.Length && !char.IsDigit(pages[i]))
                i++;
            while (i < pages.Length)
            { pageEnd += pages[i]; i++; }

            int intPageBegin;
            Int32.TryParse(pageBegin, out intPageBegin);
            int intPageEnd;
            Int32.TryParse(pageEnd, out intPageEnd);

            return intPageEnd - intPageBegin > 3 ? true : false;
        }
    }
}
