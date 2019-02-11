using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.TypesOfSourse
{
    public class Book
    {
        string Name;
        string[] Authors;
        string Town;
        string Publisher;
        string Pages;
        string Link;
        DateTime Date;
        int Vol;
        int Year;

        public Book(string[] authors, string name, string town, string publisher, int year, int vol, string pages, string link, DateTime date)
        {
            Authors = authors.ToArray();
            Name = name;
            Town = town;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Vol = vol;
            Link = link;
            Date = date;
        }

        public void MakeAuthorsForHarvard(string[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                int ind = authors[i].IndexOf(' ');
                authors[i] = authors[i].Insert(ind, ",");

                if (i != authors.Length - 2 && i != authors.Length - 1)
                    authors[i] = authors[i] + ", ";
                else if (authors.Length - 2 == i)
                    authors[i] += " и ";
            }
        }

        public void MakeAuthorsForAPA(string[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                int ind = authors[i].IndexOf(' ');
                authors[i] = authors[i].Insert(ind, ",");
                //string Initial = authors[i].SkipWhile((x, y) => x != ' ').ToString();
                //authors[i]= authors[i].TakeWhile((x, y) => x != ' ').ToString();

                if (i != authors.Length - 2 && i != authors.Length - 1)
                    authors[i] = authors[i] + ", ";
                else if (authors.Length - 2 == i)
                    authors[i] += " & ";
            }
        }

        public void MakeAuthorsForIEEE(string[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                int ind = authors[i].IndexOf(' ');
                authors[i] = authors[i].Substring(0, ind).Insert(0, authors[i].Substring(ind + 1));
                for (int j = 0; j < authors[i].Length; j++)
                {
                    if (authors[i][j] == '.')
                        authors[i] = authors[i].Insert(j + 1, " ");
                }
                if (i != authors.Length - 2 && i != authors.Length - 1)
                    authors[i] = authors[i] + ", ";
                else if (authors.Length - 2 == i)
                    authors[i] += ", & ";
            }
        }

        public void MakeGOST(ref RichTextBox rtb)
        {
            const string Space = " ";
            const string PointSpace = ". ";
            const string DoublePointSpace = ": ";
            const string Page = " с.";
            const string IntPages = "C. ";
            const string CommaSpace = ", ";
            const string Slash = " / ";
            const string DoubleSlash = "// ";
            const string URL = "URL: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string DateRus = "дата обращения";
            const string Point = ".";
            string result = string.Empty;
            int flag;
            if (Authors.Length < 4)
            {
                result += string.Join(", ", Authors);
                result += Space;
                result += Name + PointSpace;
            }
            else
            {
                //result += Name + Slash;
                for (int i = 0; i < 2; i++)
                    result += Authors[i] + CommaSpace;
                result += Authors[2] + " [и др.]";
                result += PointSpace;
                result += Name + PointSpace;

            }
            result += Town;
            result += DoublePointSpace + Publisher + CommaSpace;
            result += Year + Point;
            if (Vol > 0)
                result += " т. " + Vol + Point;
            if (Pages != "0" && Pages != "")
                result += Space + Pages + Page;
            if (Link != "")
                result += Space + URL + Link + Space + Lparenthesis + DateRus + DoublePointSpace + Date.ToString("dd.MM.yyyy") + Rparenthesis + Point;
            rtb.Text = result;
        }

        public void MakeHarvard(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string PointSpace = ". ";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Avaliable = "Avaliable at: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Lpar = "[";
            const string Rpar = "]";
            const string DateRus = "Accesed ";
            const string Point = ".";
            const string DoublePoint = ":";
            rtb.Text = string.Empty;


            MakeAuthorsForHarvard(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += Space;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += Name + PointSpace;
            //if (Vol > 0)
            //    rtb.SelectedText += Vol + Point; 
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText += Town + DoublePoint + Space;
            rtb.SelectedText = Publisher + CommaSpace;
            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}
            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText += Page;
            else
                rtb.SelectedText += PPage;
            rtb.SelectedText += Pages + Point;

            if (Link != "")
                rtb.SelectedText += Space + Avaliable + Link + Space + Lpar + DateRus + Space + Date.ToString("dd MMM yyyy") + Rpar + Point;


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
            const string Access = "Доступ ";
            const string Retrieved = "Retrieved ";
            const string From = "from ";
            const string DoublePoint = ": ";
            rtb.Text = string.Empty;

            MakeAuthorsForAPA(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += Space;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += Name + Space;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}
            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText += Lparenthesis + Page;
            else
                rtb.SelectedText += Lparenthesis + PPage;
            rtb.SelectedText += Pages + Rparenthesis + PointSpace;

            rtb.SelectedText += Town + DoublePoint;
            rtb.SelectedText = Publisher + Point;

            //if (Vol > 0)
            //    rtb.SelectedText += "т. " + Vol + Point;


            if (Link != "")
                rtb.SelectedText += Space + Retrieved + Date.ToString("dd MMMM yyyy") + CommaSpace + From + Link;

        }

        public void MakeI3E(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string DoublePointSpace = ": ";
            const string PointSpace = ". ";
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Access = "Accessed on: ";
            const string Available = "Available: ";

            rtb.Text = string.Empty;
            //var form = new fAdd() { Text = "Добавьте название страны" };
            string Country = "";
            //if (form.ShowDialog() == DialogResult.OK)
            //    Country = form.Add;
            //else
            //    MessageBox.Show("Вы не добавили страну, ссылка будет не верна!");
            MakeAuthorsForIEEE(Authors);
            if (Authors.Length < 6)
            {
                rtb.Text += string.Join("", Authors);
                rtb.Text += CommaSpace;
            }
            else
            {
                rtb.Text += Authors[0] + " et al." + CommaSpace;
            }

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += Name + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText += Town + CommaSpace;
            rtb.SelectedText += Country + DoublePointSpace;
            rtb.SelectedText = Publisher + CommaSpace;
            rtb.SelectedText += Year;
            //if (Vol > 0)
            //    rtb.SelectedText += "т. " + Vol + PointSpace;
            if (Pages != "")
            {
                rtb.SelectedText += CommaSpace;
                int a = 0;
                if (Int32.TryParse(Pages, out a))
                    rtb.SelectedText += Page;
                else
                    rtb.SelectedText += PPage;

                rtb.SelectedText += Pages + Point;
            }
            else
                rtb.SelectedText += Point;
            if (Link != "")
                rtb.SelectedText += Space + Available + Link + Point + Space + Access + Date.ToString("MMM. dd, yyyy.");
        }
    }

}
