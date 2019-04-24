using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReader.Readers
{
    public class UniversalBibReader
    {
        Tags myDictinaries = new Tags();

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
                myDictinaries.TagValues["originalTitle"] = value;
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
            if (myDictinaries.TagRework.ContainsKey(key) && myDictinaries.TagValues.ContainsKey(myDictinaries.TagRework[key]))
                myDictinaries.TagValues[myDictinaries.TagRework[key]] = value;
        }

        private void SetTypeOfLibItem(string str)
        {
            var index = str.IndexOf('{');
            myDictinaries.TagValues["type"] = myDictinaries.TagRework[str.Substring(1, index - 1).ToLower()];
        }

        private List<LibItem> ReadFile(StreamReader reader, List<LibItem> Items)
        {
            var template = @"\s?(.+?)\s?=\s?(""|{{|{)(.+?)(""|}}|}),";
            var regex = new Regex(template);
            string str = "", currstr = "";
            const string endStr = "\",";
            myDictinaries = new Tags();
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
                                if (myDictinaries.TagValues["source"] == "")
                                    myDictinaries.TagValues["source"] = WhereFrom(str);
                                if (key == "source")
                                    myDictinaries.TagValues["source"] = value;
                            }
                            if (myDictinaries.TagRework.ContainsKey(key))
                                myDictinaries.TagValues[myDictinaries.TagRework[key]] = value;
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
                var newItem = new LibItem(myDictinaries.TagValues);
                Items.Add(newItem);
                myDictinaries = new Tags();
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
