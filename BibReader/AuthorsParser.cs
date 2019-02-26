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
                    LastNameIsFirst(listOfAuthors);
                    break;

                case "ScienceDirect":
                    LastNameIsLast(listOfAuthors);
                    break;

                case "IEEE":
                    LastNameIsLast(listOfAuthors);
                    break;

                case "WebOfScience":
                    LastNameIsFirst(listOfAuthors);
                    break;

                case "ACMDL":
                    LastNameIsFirst(listOfAuthors);
                    break;
            }

            return listOfAuthors;
        }

        private string[] LastNameIsFirst(string[] Authors)
        {
            return null;
        }

        private string[] LastNameIsLast(string[] Authors)
        {
            for (int i = 0; i < Authors.Length; i++)
            {
                var indexOfStartLastName = Authors[i].LastIndexOf(' ');
                var FirstName = Authors[i].Substring(0, indexOfStartLastName);
                var LastName = Authors[i].Substring(indexOfStartLastName + 1);
                Authors[i] = string.Join(" ", LastName, FirstName);
            }
            return null;
        }
    }
}
