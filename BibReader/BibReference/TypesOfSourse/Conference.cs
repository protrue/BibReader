using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.BibReference.TypesOfSourse
{
    public class Conference
    {
        string Town;
        string NameOfConf;
        string[] Authors;
        string Report;
        string Publisher;
        string Pages;
        int Year;

        public Conference(string[] authors, string report, string publisher, string pages, int year, string town, string nameOfConf)
        {
            Authors = authors.ToArray();
            Report = report;
            Publisher = publisher;
            Pages = pages;
            Year = year;
            Town = town;
            NameOfConf = nameOfConf;
        }

        public void MakeGOST(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string PointSpace = ". ";
            const string Point = ".";
            const string Spase = " ";
            const string DoublePointSpace = ": ";
            const string Page = "p. ";
            const string PPage = "C. ";
            const string CommaSpace = ", ";
            const string DoubleSlash = " // ";
            var result = string.Empty;

            AuthorsParser authorsParser = new AuthorsParser();
            Authors = authorsParser.MakeAuthorsForGOST(Authors);
            result += string.Join(", ", Authors) + Spase;

            result += Report + PointSpace;
            result += NameOfConf + PointSpace;
            if (Town != string.Empty)
                result += Town + DoublePointSpace;
            if (Publisher != string.Empty)
                result += Publisher + CommaSpace;

            result += Year + PointSpace;
            result += PPage + Pages + Point;
            rtb.Text += result + "\n\n";
        }

        public void MakeHarvard(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string PointSpace = ". ";
            const string Point = ".";
            const string Space = " ";
            const string DoublePointSpace = ": ";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string In = "In: ";


            //MakeAuthorsForHarvard(Authors);
            //rtb.Text += string.Join(" и ", Authors);
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForHarvard(Authors);
            rtb.SelectedText = Space;

            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.SelectedText = Report + PointSpace;
            rtb.SelectedText = In;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = NameOfConf + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;


            rtb.SelectedText = Town + DoublePointSpace;
            rtb.SelectedText = Publisher + CommaSpace;
            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText = Page + Pages + Point + "\n\n";
            else
                rtb.SelectedText = PPage + Pages + Point + "\n\n";
        }

        public void MakeAPA(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string PointSpace = ". ";
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string DoublePoint = ": ";
            const string In = "In ";

            //MakeAuthorsForAPA(Authors);
            //rtb.Text += string.Join("", Authors);
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForAPA(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.SelectedText = Report + PointSpace + In;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = NameOfConf + Space;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;

            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText = Lparenthesis + Page;
            else
                rtb.SelectedText = Lparenthesis + PPage;
            rtb.SelectedText = Pages + Rparenthesis + PointSpace;
            if (Town != string.Empty)
                rtb.SelectedText = Town + DoublePoint;
            rtb.SelectedText = Publisher + Point + "\n\n";

        }

        public void MakeIEEE(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Space = " ";
            const string Comma = ",";
            const string In = "in ";


            //MakeAuthorsForIEEE(Authors);
            //rtb.Text += string.Join("", Authors);
            //rtb.Text += CommaSpace;
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForIEEE(Authors) + CommaSpace;

            rtb.SelectedText = "\"" + Report + Comma + "\"" + Space + In;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = NameOfConf + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            if (Town != string.Empty)
                rtb.SelectedText = Town + CommaSpace;
            rtb.SelectedText = Year + CommaSpace;

            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText = Page + Pages + Point + "\n\n";
            else
                rtb.SelectedText = PPage + Pages + Point + "\n\n";

        }

    }

}
