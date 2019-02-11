using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.TypesOfSourse
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
            rtb.Text = string.Empty;

            rtb.Text += string.Join(", ", Authors) + Spase;

            rtb.Text += Report + DoubleSlash;
            rtb.Text += NameOfConf + PointSpace;
            rtb.Text += Town + DoublePointSpace;
            rtb.Text += Publisher + CommaSpace;
            rtb.Text += Year + PointSpace;

            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}

            rtb.Text += PPage + Pages + Point;
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
            rtb.Text = string.Empty;


            MakeAuthorsForHarvard(Authors);
            rtb.Text += string.Join(" и ", Authors);
            rtb.Text += Space;

            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.Text += Report + PointSpace;
            rtb.Text += In;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = NameOfConf + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;


            rtb.SelectedText += Town + DoublePointSpace;
            rtb.SelectedText += Publisher + CommaSpace;
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
                rtb.SelectedText += Page + Pages + Point;
            else
                rtb.SelectedText += PPage + Pages + Point;
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
            rtb.Text = string.Empty;

            MakeAuthorsForAPA(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += Space;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.Text += Report + PointSpace + In;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += NameOfConf + Space;
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

        }

        public void MakeI3E(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string In = "in ";
            rtb.Text = string.Empty;


            MakeAuthorsForIEEE(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += CommaSpace;

            rtb.Text += "\"" + Report + "\"" + CommaSpace + In;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = NameOfConf + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            //var formTown = new fAdd() { Text = "Добавьте город, в котором проходила конференция" };

            //if (formTown.ShowDialog() == DialogResult.OK)
            //    Town = formTown.Add;
            //else
            //    MessageBox.Show("Вы не добавили город, ссылка будет не верна!");
            rtb.SelectedText += Town + CommaSpace;
            rtb.SelectedText += Year + CommaSpace;


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
                rtb.SelectedText += Page + Pages + Point;
            else
                rtb.SelectedText += PPage + Pages + Point;

        }

        public void MakeAuthorsForHarvard(string[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                int ind = authors[i].IndexOf(' ');
                authors[i] = authors[i].Insert(ind, ",");
                //string Initial = authors[i].SkipWhile((x, y) => x != ' ').ToString();
                //authors[i]= authors[i].TakeWhile((x, y) => x != ' ').ToString();
            }
        }

        public void MakeAuthorsForAPA(string[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                int ind = authors[i].IndexOf(' ');
                authors[i] = authors[i].Insert(ind, ",");
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
    }

}
