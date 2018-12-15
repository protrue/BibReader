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

        //public string Authors { get => Authors; set => Authors = value; }
        //public string Doi { get => Doi; private set => Doi = value; }
        //public string Year { get => Year; private set => Year = value; }
        //public string Booktitle { get => Booktitle; private set => Booktitle = value; }
        //public string JournalName { get => JournalName; private set => JournalName = value; }
        //public string Volume { get => Volume; private set => Volume = value; }
        //public string Pages { get => Pages; private set => Pages = value; }
        //public string Url { get => Url; private set => Url = value; }
        //public string Affiliation { get => Affiliation; private set => Affiliation = value; }
        //public string Abstract { get => Abstract; private set => Abstract = value; }
        //public string Keywords { get => Keywords; private set => Keywords = value; }
        //public string Publisher { get => Publisher; private set => Publisher = value; }
        //public string Sourse { get => Sourse; private set => Sourse = value; }
        //public string Number { get => Number; private set => Number = value; }
    }
}
