using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReader
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
                {"booktitle", "booktitle"},
                {"Booktitle", "booktitle"},
                {"journal", "journal"},
                {"Journal", "journal"},
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
                {"address", "address"},
                {"Address", "address"},
                {"inproceedings", "conference"},
                {"INPROCEEDINGS", "conference"},
                {"article", "journal"},
                {"ARTICLE", "journal"},
                {"conference", "conference"},
                {"incollection", "book"},
                {"book", "book"},
                {"inbook", "book"},
            };
            mainDict = new Dictionary<string, string>
            {
                { "authors", ""},
                { "title", ""},
                { "booktitle", ""},
                { "journal", ""},
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
                { "originalTitle", ""},
                { "type", "" },
                { "address", "" }
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
        MyDictinaries myDictinaries = new MyDictinaries();


        private string WhereFrom(string str)
        {
            switch(str.Substring(0, "title".Length))
            {
                case " titl":
                    return "ACM DL";
                case "title":
                    return (str[5] != ' ') ? "IEEE" : "Science Direct";
                case "Title":
                    return "Web of Science";
            }
            return "";
        }

        private string pretreatmentTitle(string title)
        {
            string[] codesForRemove = new string[] {
                @"\&\#38;",
                "amp;#x2014;",
                "{''}"
            };

            foreach (var code in codesForRemove)
            {
                if (title.Contains(code))
                {
                    var index = title.IndexOf(code);
                    title = title.Remove(index, code.Length);
                    if (code == "{''}")
                        title = title.Insert(index, "”");
                }
            }

            title = FindOriginalTitle(title);

            return title;
        }

        private string FindOriginalTitle(string title)
        {
            var template = @".*\[(.+)\].*";
            var regex = new Regex(template);

            var value = regex.Match(title).Groups[1].Value;
            if (value != "")
            {
                myDictinaries.mainDict["originalTitle"] = value;
                var index = title.IndexOf(value);
                title = title.Remove(index - 1, value.Length + 2);
            }

            return title;
        }

        private bool isScienceDirectEnd(string str) => 
            (str.Length >= "abstract = ".Length + 1 && str.Substring(0, "abstract = ".Length + 1) == "abstract = \"")
            ? true 
            : false;

        private void ScienceDirectFix(string str)
        {
            var template = @"(.+?)\s=\s""(.+?)""";
            var regex = new Regex(template);
           
            var key = regex.Match(str).Groups[1].Value;
            var value = regex.Match(str).Groups[2].Value;
            if (myDictinaries.dict.ContainsKey(key) && myDictinaries.mainDict.ContainsKey(myDictinaries.dict[key]))
                myDictinaries.mainDict[myDictinaries.dict[key]] = value;
        }

        private void SetTypeOfLibItem(string str)
        {
            var index = str.IndexOf('{');
            myDictinaries.mainDict["type"] = myDictinaries.dict[str.Substring(1, index - 1).ToLower()];
        }

        private List<LibItem> ReadFile(StreamReader reader, List<LibItem> Items)
        {
            var template = @"\s?(.+?)\s?=\s?(""|{{|{)(.+?)(""|}}|}),";
            var regex = new Regex(template);
            string str = "", currstr = "";
            const string endStr = "\",";
            myDictinaries = new MyDictinaries();
            myDictinaries.Init();

            if (reader == null)
                return Items;
            currstr = reader.ReadLine();
            while (currstr == null || currstr == "" || currstr[0] != '@')
            {
                if (currstr == null)
                    return Items;
                currstr = reader.ReadLine();
            }
            SetTypeOfLibItem(currstr);
            while (!reader.EndOfStream)
            {
               
                currstr = reader.ReadLine();
                while (currstr == "" || currstr != "}" && (currstr.Length > 2 && currstr.Substring(currstr.Length - 2, 2) != ",}"))
                {
                    if (currstr != "")
                    {
                        if (currstr[0] != '@')
                            str += currstr;
                        else
                            SetTypeOfLibItem(currstr);

                        if (currstr.Length >= 3 && (currstr.Substring(currstr.Length - 2, 2) == "}," ||
                            currstr.Substring(currstr.Length - 3, 3) == "}, " ||
                            currstr.Substring(currstr.Length - 2, 2) == endStr))
                        {
                            var key = regex.Match(str).Groups[1].Value;
                            var value = regex.Match(str).Groups[3].Value;
                            if (key == "title" || key == "Title" || key == "source")
                            {
                                value = pretreatmentTitle(value);
                                if (myDictinaries.mainDict["source"] == "")
                                    myDictinaries.mainDict["source"] = WhereFrom(str);
                                if (key == "source")
                                    myDictinaries.mainDict["source"] = value;
                            }
                            if (myDictinaries.dict.ContainsKey(key))
                                myDictinaries.mainDict[myDictinaries.dict[key]] = value;
                            str = "";
                        }
                    }
                    currstr = reader.ReadLine();
                    if (currstr == null)
                        break;
                }
                if (str != string.Empty)
                    ScienceDirectFix(str);
                if (currstr == null)
                    break;
                str = string.Empty;
                var newItem = new LibItem(myDictinaries.mainDict);
                Items.Add(newItem);
                myDictinaries = new MyDictinaries();
                myDictinaries.Init();
            }
            reader.Close();
            return Items;

        }

        public List<LibItem> Read(StreamReader[] readers)
        {
            var Items = new List<LibItem>();
            if (readers != null)
                foreach (var reader in readers)
                    Items = ReadFile(reader, Items);
            return Items;
        }
    }
}
