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
        Tags tags = new Tags();

        private string FindSource(string str)
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

        private void FindSource(string key, string value, string tagString)
        {
            if (key == "title" || key == "Title" || key == "source")
            {
                value = PretreatTitle(value);
                if (tags.TagValues["source"] == "")
                    tags.TagValues["source"] = FindSource(tagString);
                if (key == "source")
                    tags.TagValues["source"] = value;
            }
        }

        private string PretreatTitle(string title)
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
            return FindOriginalTitle(title);
        }

        private string FindOriginalTitle(string title)
        {
            var template = @".*\[(.+)\].*";
            var regex = new Regex(template);

            var value = regex.Match(title).Groups[1].Value;
            if (value != "")
            {
                tags.TagValues["originalTitle"] = value;
                var index = title.IndexOf(value);
                title = title.Remove(index - 1, value.Length + 2);
            }
            return title;
        }

        private bool IsScienceDirectEnd(string str) =>
            (str.Length >= "abstract = ".Length + 1 && str.Substring(0, "abstract = ".Length + 1) == "abstract = \"");

        private void FixScienceDirect(string str)
        {
            var template = @"(.+?)\s=\s""(.+?)""";
            var regex = new Regex(template);
           
            var key = regex.Match(str).Groups[1].Value;
            var value = regex.Match(str).Groups[2].Value;
            if (tags.TagRework.ContainsKey(key) && tags.TagValues.ContainsKey(tags.TagRework[key]))
                tags.TagValues[tags.TagRework[key]] = value;
        }

        private void SetTypeOfLibItem(string str)
        {
            var index = str.IndexOf('{');
            tags.TagValues["type"] = tags.TagRework[str.Substring(1, index - 1).ToLower()];
        }

        private bool IsEndOfTag(string currstr) =>
            currstr.Length >= 3 &&
            (currstr.Substring(currstr.Length - 2, 2) == "}," ||
            currstr.Substring(currstr.Length - 3, 3) == "}, " ||
            currstr.Substring(currstr.Length - 2, 2) == "\",");

        private bool IsEndOfLibItem(string currstr) => 
            currstr.Length > 2 && currstr != "}" 
            && currstr.Substring(currstr.Length - 2, 2) != ",}";

        private List<LibItem> GetLibItems(StreamReader reader)
        {
            List<LibItem> Items = new List<LibItem>();
            var template = @"\s?(.+?)\s?=\s?(""|{{|{)(.+?)(""|}}|}),";
            var regex = new Regex(template);
            string tagString = "", newLine = "";
            tags = new Tags();

            if (reader == null)
                return Items;
            newLine = reader.ReadLine();
            while (newLine == null || newLine == "" || newLine[0] != '@')
            {
                if (newLine == null)
                    return Items;
                newLine = reader.ReadLine();
            }
            SetTypeOfLibItem(newLine);
            while (!reader.EndOfStream)
            {
                newLine = reader.ReadLine();
                while (newLine == "" || IsEndOfLibItem(newLine))
                {
                    if (newLine != "")
                    {
                        if (newLine[0] != '@')
                            tagString += newLine;
                        else
                            SetTypeOfLibItem(newLine);

                        if (IsEndOfTag(newLine))
                        {
                            var key = regex.Match(tagString).Groups[1].Value;
                            var value = regex.Match(tagString).Groups[3].Value;
                            FindSource(key, value, tagString);
                            if (tags.TagRework.ContainsKey(key))
                                tags.TagValues[tags.TagRework[key]] = value;
                            tagString = "";
                        }
                    }
                    newLine = reader.ReadLine();
                    if (newLine == null)
                        break;
                }
                if (tagString != string.Empty)
                    FixScienceDirect(tagString);
                if (newLine == null)
                    break;
                tagString = string.Empty;
                var newItem = new LibItem(tags.TagValues);
                Items.Add(newItem);
                tags = new Tags();
            }
            reader.Close();
            return Items;
        }

        public List<LibItem> Read(StreamReader[] readers)
        {
            var Items = new List<LibItem>();
            if (readers != null)
                foreach (var reader in readers)
                    Items.AddRange(GetLibItems(reader));
            return Items;
        }
    }
}
