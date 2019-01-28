using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BibReader
{
    public class MyBibFormat
    {
        public void Write(List<LibItem> libItems, string path)
        {
            using (var writer = new StreamWriter(path, false))
            {
                foreach (var item in libItems)
                {
                    writer.WriteLine("@{");
                    writer.WriteLine("author={" + item.Authors + "},");
                    writer.WriteLine("abstruct={" + item.Abstract + "},");
                    writer.WriteLine("affiliation={" + item.Affiliation + "},");
                    writer.WriteLine("booktitle={" + item.Booktitle + "},");
                    writer.WriteLine("doi={" + item.Doi + "},");
                    writer.WriteLine("journal={" + item.JournalName + "},");
                    writer.WriteLine("keywords={" + item.Keywords + "},");
                    writer.WriteLine("number={" + item.Number + "},");
                    writer.WriteLine("pages={" + item.Pages + "},");
                    writer.WriteLine("publisher={" + item.Publisher + "},");
                    writer.WriteLine("sourсe={" + item.Sourсe + "},");
                    writer.WriteLine("title={" + item.Title + "},");
                    writer.WriteLine("url={" + item.Url + "},");
                    writer.WriteLine("volume={" + item.Volume + "},");
                    writer.WriteLine("year={" + item.Year + "},");
                    writer.WriteLine("}");
                    writer.WriteLine();
                }
            }
        }


    }
}
