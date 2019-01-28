using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReaderLibrary
{
    public class LibItem
    {
        public string Authors { get; set; }
        public string Doi {get; set; }
        public string Year {get; set; }
        public string Booktitle {get; set; }
        public string Title { get; set; }
        public string JournalName {get; set; }
        public string Volume {get; set; }
        public string Pages {get; set; }
        public string Url {get; set; }
        public string Affiliation {get; set; }
        public string Abstract {get; set; }
        public string Keywords {get; set; }
        public string Publisher {get; set; }
        public string Sourсe {get; set; }
        public string Number {get; set; }

        public LibItem(string authors, string doi, string year, string booktitle, string title, string journalName, string volume, string pages, string url, string affiliation, string @abstract, string keywords, string publisher, string sourсe, string number)
        {
            Authors = authors;
            Doi = doi;
            Year = year;
            Booktitle = booktitle;
            Title = title;
            JournalName = journalName;
            Volume = volume;
            Pages = pages;
            Url = url;
            Affiliation = affiliation;
            Abstract = @abstract;
            Keywords = keywords;
            Publisher = publisher;
            Sourсe = sourсe;
            Number = number;
        }

        public LibItem(Dictionary<string, string> dict)
        {
            Authors = dict["authors"];
            Doi = dict["doi"];
            Year = dict["year"];
            Booktitle = dict["booktitle"];
            Title = dict["title"];
            JournalName = dict["journalName"];
            Volume = dict["volume"];
            Pages = dict["pages"];
            Url = dict["url"];
            Affiliation = dict["affiliation"];
            Abstract = dict["abstract"];
            Keywords = dict["keywords"];
            Publisher = dict["publisher"];
            Sourсe = dict["source"];
            Number = dict["number"];
        }

        public bool AbstractIsEmpty => Abstract == string.Empty ? true : false;
        public bool KeywordsIsEmpty => Keywords == string.Empty ? true : false;


    }
}
