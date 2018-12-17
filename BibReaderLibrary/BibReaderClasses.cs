using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReaderLibrary
{
    public class MyDictinaries
    {
        public Dictionary<string, string> dict;
        public Dictionary<string, string> mainDict;
        public void Init()
        {
            dict = new Dictionary<string, string>
            {
                {"author", "authors"},
                {"Author", "authors"},
                {"title", "title"},
                {"Title", "title"},
                {"journal", "journalName"},
                {"Journal", "journalName"},
                {"year", "year"},
                {"Year", "year"},
                {"volume", "volume"},
                {"Volume", "volume"},
                {"pages", "pages"},
                {"Pages", "pages"},
                {"number", "number"},
                {"Number", "number"},
                {"doi", "doi"},
                {"DOI", "doi"},
                {"url", "url"},
                {"affiliation", "affiliation"},
                {"abstract", "abstract"},
                {"Abstract", "abstract"},
                {"keywords", "keywords"},
                {"Keywords", "keywords"},
                {"author_keywords", "keywords"},
                {"publisher", "publisher"},
                {"Publisher", "publisher"},
                {"source", "source"},
            };
            mainDict = new Dictionary<string, string>
            {
                { "authors", ""},
                { "title", ""},
                { "booktitle", ""},
                { "journalName", ""},
                { "year", ""},
                { "volume", ""},
                { "pages", ""},
                { "doi", ""},
                { "url", ""},
                { "affiliation", ""},
                { "abstract", ""},
                { "keywords", ""},
                { "publisher", ""},
                { "source", ""},
                { "number", ""},

            };
    }
}
    
    public class ScopusBibReader
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();

        public void Reader(StreamReader reader)
        {
            const int ItemsCount = 23;
            var template = @".+={(.+)},";
            var regex = new Regex(template);
            string[] line = new string[ItemsCount];
            var str = reader.ReadLine();
            var lin = str.Substring("@ARTICLE{".Length, str.Length - "@ARTICLE{".Length - 1);
            str = reader.ReadLine();
            string[] authors = str.Substring("author".Length, str.Length - "author".Length - 2).Split(',');
            for (int i = 0; i < ItemsCount; i++)
            {
                line[i] = reader.ReadLine();
                var value = regex.Match(line[i], 0).Groups[1].Value;
                if (i == 4 && line[i].Substring(0, 6) != "number")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                if (i == 7 && line[i].Substring(0, "art_number".Length) != "art_number")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                if (i == 18 && line[i].Substring(0, "coden".Length) != "coden")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                switch (i)
                {
                    case 0:
                        var title = value;
                        break;
                    case 1:
                        var journal = value;
                        break;
                    case 2:
                        var year = value;
                        break;
                    case 3:
                        var volume = value;
                        break;
                    case 4:
                        var number = value;///////////////
                        break;
                    case 5:
                        var pages = value;
                        break;
                    case 6:
                        var doi = value;
                        break;
                    case 7:
                        var art_number = value;////////////////
                        break;
                    case 8:
                        var note = value;
                        break;
                    case 9:
                        var url = value;
                        break;
                    case 10:
                        var affiliation = value;
                        break;
                    case 11:
                        var abstract_ = value;
                        break;
                    case 12:
                        var author_keywords = value;
                        break;
                    case 13:
                        var keywords = value;
                        break;
                    case 14:
                        var references = value;
                        break;
                    case 15:
                        var correspondence_address1 = value;
                        break;
                    case 16:
                        var publisher = value;
                        break;
                    case 17:
                        var issn = value;
                        break;
                    case 18:
                        var coden = value;////////////
                        break;
                    case 19:
                        var language = value;
                        break;
                    case 20:
                        var abbrev_source_title = value;
                        break;
                    case 21:
                        var document_type = value;
                        break;
                    case 22:
                        var source = value;
                        break;
                }
            }
            reader.ReadLine();
            reader.ReadLine();
        }

        public string TestReader2(StreamReader reader)
        {
            // pubmed_id={30311064}, перед language
            // chemicals_cas после keywords

            const int ItemsCount = 28;
            var template = @".+={(.+)},";
            var regex = new Regex(template);
            string[] line = new string[ItemsCount];
            string str;
            int i = -2;
            while ((str = reader.ReadLine()) != "}")
            {
                string lin;
                string[] authors;
                if (i == -2)
                    lin = str.Substring("@ARTICLE{".Length, str.Length - "@ARTICLE{".Length - 1);
                else if (i == -1)
                    authors = str.Substring("author".Length, str.Length - "author".Length - 2).Split(',');
                else {
                    line[i] = str;
                    if (i == 4 && line[i].Substring(0, 6) != "number")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 5 && line[i].Substring(0, 5) != "pages")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 6 && line[i].Substring(0, 3) != "doi")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 7 && line[i].Substring(0, "art_number".Length) != "art_number")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 11 && line[i].Substring(0, "abstract".Length) != "abstract")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 12 && line[i].Substring(0, "author_k".Length) != "author_k")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 13 && line[i].Substring(0, "keywords".Length) != "keywords")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 14 && line[i].Substring(0, "chemical".Length) == "chemical")
                    {
                        line[i] = "";
                        i--;
                    }
                    if (i == 15 && line[i].Substring(0, "corres".Length) != "corres")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    
                    if (i == 18 && line[i].Substring(0, "coden".Length) != "coden")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 19 && line[i].Substring(0, "pubmed_id".Length) != "pubmed_id")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                    if (i == 21 && line[i].Substring(0, "abbrev".Length) != "abbrev")
                    {
                        line[i + 1] = line[i];
                        line[i] = "";
                        i++;
                    }
                }
                i++;
            }
            reader.ReadLine();// еще пробел

            if (line[i - 2] == "document_type={Article},")
                for (i = 0; i < 24; i++)
                {
                    var value = regex.Match(line[i], 0).Groups[1].Value;

                    switch (i)
                    {
                        case 0:
                            var title = value;
                            break;
                        case 1:
                            var journal = value;
                            break;
                        case 2:
                            var year = value;
                            break;
                        case 3:
                            var volume = value;
                            break;
                        case 4:
                            var number = value;///////////////
                            break;
                        case 5:
                            var pages = value;///////////
                            break;
                        case 6:
                            var doi = value;////////////
                            break;
                        case 7:
                            var art_number = value;////////////////
                            break;
                        case 8:
                            var note = value;
                            break;
                        case 9:
                            var url = value;
                            break;
                        case 10:
                            var affiliation = value;
                            break;
                        case 11:
                            var abstract_ = value;///////////////////
                            break;
                        case 12:
                            var author_keywords = value;//////////////
                            break;
                        case 13:
                            var keywords = value;////////////////////
                            break;
                        case 14:
                            var references = value;
                            break;
                        case 15:
                            var correspondence_address1 = value;/////////////
                            break;
                        case 16:
                            var publisher = value;
                            break;
                        case 17:
                            var issn = value;
                            break;
                        case 18:
                            var coden = value;////////////
                            break;
                        case 19:
                            var pubmed_id = value;///////////
                            break;
                        case 20:
                            var language = value;
                            break;
                        case 21:
                            var abbrev_source_title = value;//////////////
                            break;
                        case 22:
                            var document_type = value;
                            break;
                        case 23:
                            var source = value;
                            break;
                    }
                }
            else
                return "source={Scopus},";


            return line[23];
        }


    }

    public class ScienceDirectBibReader
    {
        public void Reader(StreamReader reader)
        {
            const int ItemsCount = 12;
            var template = @".+=""(.+)"",";
            var regex = new Regex(template);
            string[] line = new string[ItemsCount];
            var str = reader.ReadLine();
            var lin = str.Substring("@ARTICLE{".Length, str.Length - "@ARTICLE{".Length - 1);

            for (int i = 0; i < ItemsCount; i++)
            {
                line[i] = reader.ReadLine();
                var value = regex.Match(line[i], 0).Groups[1].Value;
                if (i == 2 && line[i].Substring(0, 6) != "volume")
                {
                    line[i + 3] = line[i];
                    line[i] = "";
                    line[i + 1] = "";
                    line[i + 2] = "";
                    i += 3;
                }
                if (i == 3 && line[i].Substring(0, 6) != "number")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                switch (i)
                {
                    case 0:
                        var title = value;
                        break;
                    case 1:
                        var journal = value;
                        break;
                    case 2:
                        var volume = value;
                        break;
                    case 3:
                        var number = value;
                        break;
                    case 4:
                        var pages = value;
                        break;
                    case 5:
                        var year = value;
                        break;
                    case 6:
                        var issn = value;
                        break;
                    case 7:
                        var doi = value;
                        break;
                    case 8:
                        var url = value;
                        break;
                    case 9:
                        var author = value;
                        break;
                    case 10:
                        var keywords = value;
                        break;
                    case 11:
                        var abstract_ = value;
                        break;
                }
            }
            reader.ReadLine();

        }
    }

    public class WebOfScienceBibReader
    {
        public void Reader(StreamReader reader)
        {
            const int itemsCount = 33;
            // inproceedings обработать отдельно
            var template = @".+={(.+)},";
            var regex = new Regex(template);
            string[] line = new string[itemsCount];
            var str = reader.ReadLine();
            if (str.Substring(0, "@ARTICLE{ ".Length) != "@ARTICLE{ ")
            {
                while (str != "")
                    str = reader.ReadLine();
                Reader(reader);
            }
            var lin = str.Substring("@ARTICLE{ ".Length, str.Length - "@ARTICLE{ ".Length - 1);
            str = reader.ReadLine();
            var author = regex.Match(str).Groups[1].Value;
            template = @".+={{(.+)}},";
            for (int i = 0; i < itemsCount; i++)
            {
                line[i] = reader.ReadLine();
                var value = regex.Match(line[i]).Groups[1].Value;

                while (line[i].Substring(line[i].Length - 4, 3) != "}},")
                    line[i] += reader.ReadLine();
                if (i == 4 && line[i].Substring(0, 6) != "number")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                if (i == 17 && line[i].Substring(0, "Keywords-Plus".Length) != "Keywords-Plus")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                if (i == 21 && line[i].Substring(0, "ORCID-Numbers".Length) != "ORCID-Numbers")
                {
                    line[i + 1] = line[i];
                    line[i] = "";
                    i++;
                }
                if (i == 22 && line[i].Substring(0, "Funding-Acknowledgement".Length) != "Funding-Acknowledgement")
                {
                    line[i + 2] = line[i];
                    line[i] = "";
                    line[i + 1] = "";
                    i += 2;
                }
                switch (i)
                {
                    case 0:
                        var title = value;
                        break;
                    // только в журнале 
                    case 1:
                        var journal = value;
                        break;
                    case 2:
                        var year = value;
                        break;
                    case 3:
                        var volume = value;
                        break;
                    case 4:
                        var number = value;
                        break;
                    case 5:
                        var pages = value;
                        break;
                    // только в журнале
                    case 6:
                        var month = value;
                        break;
                    case 7:
                        var abstract_ = value;
                        break;
                    case 8:
                        var publisher = value;
                        break;
                    case 9:
                        var address = value;
                        break;
                    case 10:
                        var type = value;
                        break;
                    case 11:
                        var language = value;
                        break;
                    case 12:
                        var affiliation = value;
                        break;
                    case 13:
                        var doi = value;
                        break;
                    case 14:
                        var issn = value;
                        break;
                    case 15:
                        var eissn = value;
                        break;
                    // в inproceedings
                    //case 16:
                    //    var isbn = value;
                    //    break;
                    case 16:
                        var keywords = value;
                        break;
                    case 17:
                        var keywords_plus = value;/////////////////
                        break;
                    case 18:
                        var research_areas = value;
                        break;
                    case 19:
                        var webOfScience_categories = value;
                        break;
                    case 20:
                        var author_email = value;
                        break;
                    case 21:
                        var orcid_numbers = value; ////////////////
                        break;
                    case 22:
                        var funding_acknowledgement = value;//////////////
                        break;
                    case 23:
                        var funding_text = value;///////////////
                        break;
                    case 24:
                        var cited_references = value;
                        break;
                    case 25:
                        var number_of_cited_references = value;
                        break;
                    case 26:
                        var times_cited = value;
                        break;
                    case 27:
                        var usage_count_last_180_days = value;
                        break;
                    case 28:
                        var usage_count_since_2013 = value;
                        break;
                    // только в журнале
                    case 29:
                        var journal_ISO = value;////////////////////////
                        break;
                    case 30:
                        var doc_delivery_number = value;
                        break;
                    case 31:
                        var unique_ID = value;
                        break;
                    case 32:
                        var DA = value;
                        break;
                }
            }
            reader.ReadLine();
            reader.ReadLine();

        }
    }

    public class ReadAllHeaders
    {
        public Dictionary<string, string> Reader(StreamReader reader)
        {
            var answer = new Dictionary<string, string>();
            var template = @"([^=\s]+)\s?=\s?""?({{?)?([^{}""]+)(}}?)?""?,";
            var regex = new Regex(template);
            string str="", currstr;
            const string endStr = "\",";
            while (!reader.EndOfStream)
            {
                while ((currstr = reader.ReadLine()) != "}")
                {
                    if (currstr.Length != 0)
                    {
                        if (currstr[0] != '@')
                            str += currstr;

                        if (currstr.Substring(currstr.Length - 2, 2) == "}," || currstr.Substring(currstr.Length - 2, 2) == endStr)
                        //    continue;
                        //else
                        {
                            var key = regex.Match(str, 0).Groups[1].Value;
                            var value = regex.Match(str, 0).Groups[3].Value;
                            
                            if (!answer.ContainsKey(key))
                                answer.Add(key, value);
                            str = "";
                        }
                    }
                }
                reader.ReadLine();// еще пробел
            }
                return answer;
        }

    }

    public class UniversalBibReader
    {
        private string WhereFrom(string str)
        {
            switch(str.Substring(0, "title".Length))
            {
                case " titl":
                    return "ACMDL";
                case "title":
                    return (str[5] != ' ') ? "Scopus" : "Science direct";
                case "Title":
                    return "Web of science";
            }
            return "";
        }

        public List<LibItem> Read(StreamReader reader)
        {
            var Items = new List<LibItem>();
            var template = @"([^=\s]+)\s?=\s?""?({{?)?([^{}""]+)(}}?)?""?,";
            var regex = new Regex(template);
            string str = "", currstr="";
            const string endStr = "\",";
            while ((currstr = reader.ReadLine()) != null && currstr[0] != '@')
                currstr = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                MyDictinaries s = new MyDictinaries();
                s.Init();
                while ((currstr = reader.ReadLine())[currstr.Length-1] != '}')
                {
                    if (currstr != null && currstr != "")
                    {
                        if (currstr[0] != '@')
                            str += currstr;

                        if (currstr.Length >= 2 && currstr.Substring(currstr.Length - 2, 2) == "}," ||
                            currstr.Length >= 2 && currstr.Substring(currstr.Length - 2, 2) == endStr ||
                            currstr.Length >= "abstract = ".Length + 1 && currstr.Substring(0, "abstract = ".Length + 1) == "abstract = \"")
                        {
                            var key = regex.Match(str, 0).Groups[1].Value;
                            var value = regex.Match(str, 0).Groups[3].Value;
                            if (s.dict.ContainsKey(key))
                                s.mainDict[s.dict[key]] = value;
                            if (key == "title" || key == "Title")
                                s.mainDict["source"] = WhereFrom(str);
                            str = "";
                        }
                    }
                }
                reader.ReadLine();
                var newItem = new LibItem(s.mainDict);
                Items.Add(newItem);
            }
            return Items;
        }
    }
}
