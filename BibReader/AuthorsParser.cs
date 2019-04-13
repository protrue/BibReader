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
                    listOfAuthors = listOfAuthors.Select(author => author = 
                        string.Join(" ", 
                        author.Split(' ').Select((part, i) => 
                            part = i != 0 
                            ? string.Join(". ", part.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)) + "." 
                            : part)
                        )
                    ).ToArray();
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

        public string MakeAuthorsForAPA(string[] authors)
        {
            return string.Join("", authors.Select(author => string.Join(" ", author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                Select((part, index) => part = index == 0 ? part + "," : part[0] + ".")))
                                    .Select((author, i) => author +=
                                        i != authors.Length - 1 && i != authors.Length - 2
                                        ? ", "
                                        : i != authors.Length - 1 ? " & " : ""
                                    ).ToArray());
        }

        public string MakeAuthorsForHarvard(string[] authors)
        {
            return string.Join("", authors.Select(author => string.Join(" ", author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                Select((part, index) => part = index == 0 ? part + "," : part[0] + ".")))
                                    .Select((author, i) => author +=
                                        i != authors.Length - 1 && i != authors.Length - 2
                                        ? ", "
                                        : i != authors.Length - 1 ? " and " : ""
                                    ).ToArray());
        }

        public string MakeAuthorsForIEEE(string[] authors)
        {
            return string.Join("", authors.Select(author => author =
            author.IndexOf(" ") != -1 ?
                string.Join(" ", author.Substring(author.IndexOf(" ") + 1).
                Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                Select(init => init = init[0] + ".").ToArray()
                )
                + " " + author.Substring(0, author.IndexOf(" "))
                : author
                )
                .Select((author, i) => author +=
                    i != authors.Length - 1 && i != authors.Length - 2
                    ? ", "
                    : i != authors.Length - 1 ? (i==0 ? " and " : ", and ") : ""
                ).ToArray());
        }

        public string[] MakeAuthorsForGOST(string[] authors)
        {
            return authors.Select(author => string.Join(" ", author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).
                Select((part, index) => part = index == 0 ? part : part[0] + "."))).ToArray();
        }

    }
}
