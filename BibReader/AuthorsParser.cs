using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader
{
    public enum Sourse
    {
        Scopus,
        ScienceDirect,
        IEEE,
        WebOfScience,
        ACMDL
    }

    class AuthorsParser
    {
        public string Authors { get; set; }

        public string[] GetAuthors(string sourse)
        {
            var listOfAuthors = Authors.Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries);
            
            switch(sourse)
            {
                case "Scopus":
                    LastNameIsFirst(ref listOfAuthors);
                    break;

                case "Science Direct":
                    LastNameIsLast(ref listOfAuthors);
                    break;

                case "IEEE":
                    LastNameIsLast(ref listOfAuthors);
                    break;

                case "Web of Science":
                    LastNameIsFirst(ref listOfAuthors);
                    break;

                case "ACM DL":
                    LastNameIsFirst(ref listOfAuthors);
                    break;
            }

            return listOfAuthors;
        }

        private void LastNameIsFirst(ref string[] Authors)
        {
            for (int i = 0; i < Authors.Length; i++)
            {
                while (Authors[i].Contains(','))
                    Authors[i] = Authors[i].Remove(Authors[i].IndexOf(','), 1);
            }

        }

        private void LastNameIsLast(ref string[] Authors)
        {
            for (int i = 0; i < Authors.Length; i++)
            {
                while (Authors[i].Contains(','))
                    Authors[i] = Authors[i].Remove(Authors[i].IndexOf(','), 1);
                var indexOfStartLastName = Authors[i].LastIndexOf(' ');
                var FirstName = Authors[i].Substring(0, indexOfStartLastName);
                var LastName = Authors[i].Substring(indexOfStartLastName + 1);
                Authors[i] = string.Join(" ", LastName, FirstName);
            }
        }
    }
}
