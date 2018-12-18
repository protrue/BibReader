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
            if (reader == null)
                return Items;
            while ((currstr = reader.ReadLine()) != null && currstr!="" && currstr[0] != '@')
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
            reader.Close();
            return Items;
        }
    }
}
