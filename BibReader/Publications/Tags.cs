using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Publications
{
    public class Tags
    {
        public static Dictionary<string, string> TagRework;
        public static Dictionary<string, string> TagValues;

        public static void NewTags()
        {
            TagRework = new Dictionary<string, string>
            {
                {"author", "authors"},
                {"Author", "authors"},
                {"title", "title"},
                {"Title", "title"},
                {"booktitle", "journal"},
                {"Booktitle", "journal"},
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
                {"Affiliation", "affiliation"},
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

            TagValues = new Dictionary<string, string>
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
}
