using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.TypesOfSourse
{
    public class Journal
    {
        protected string Name;
        protected string[] Authors;
        protected string Publisher;
        protected string Pages;
        protected int Year;
        protected int Number;
        protected int Vol;
        string Link;
        DateTime Date;

        public Journal(string[] authors, string name, string publisher, string pages, int year, int number, int vol, string link, DateTime date)
        {
            Authors = authors.ToArray();
            Name = name;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Number = number;
            Vol = vol;
            Link = link;
            Date = date;
        }

        public void MakeGOST(ref RichTextBox rtb)
        {
            const string Space = " ";
            const string PointSpace = ". ";
            const string DoublePointSpace = ": ";
            const string Page = " с.";
            const string IntPages = "C. ";
            const string DoubleSlash = "// ";
            const string URL = "URL: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string DateRus = "дата обращения";
            const string Point = ".";
            const string Num = "№ ";
            const string Volume = "T. ";
            const string Commaspace = ", ";
            string result = string.Empty;


            result += string.Join(", ", Authors);
            result += Space;
            result += Name + Space;
            result += DoubleSlash + Publisher + PointSpace;
            result += Year + PointSpace;
            if (Vol != 0)
                result += Volume + Vol + Commaspace;
            result += Num + Number + PointSpace;
            result += IntPages + Pages + Point;
            if (Link != "")
                result += Space + URL + Link + Space + Lparenthesis + DateRus + DoublePointSpace + Date.ToString("dd.MM.yyyy") + Rparenthesis + Point;
            rtb.Text += result + "\n\n";
        }

        public void MakeHarvard(ref RichTextBox rtb)
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
            const string Avaliable = "Avaliable at: ";
            const string Lpar = "[";
            const string Rpar = "]";
            const string DateRus = "Accessed ";
            rtb.Text = string.Empty;

            MakeAuthorsForHarvard(Authors);
            rtb.Text += string.Join(" и ", Authors);
            rtb.Text += Space;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.Text += Name + PointSpace;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Publisher + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;

            // Том нужно добавить и все просмотреть заного
            if (Vol != 0 && Number != 0)
                rtb.SelectedText += Vol + Lparenthesis + Number + Rparenthesis + CommaSpace;
            else
                if (Vol != 0 && Number == 0)
                rtb.SelectedText += Vol + CommaSpace;
            else
                rtb.SelectedText += Number + CommaSpace;

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
                rtb.SelectedText += Space + Avaliable + Link + Space + Lpar + DateRus + Date.ToString("dd MMM yyyy") + Rpar + Point;


        }

        public void MakeAPA(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string PointSpace = ". ";
            const string Point = ".";
            const string Page = " с.";
            const string CommaSpace = ", ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Retrieved = "Retrieved ";
            const string From = "from ";
            rtb.Text = string.Empty;

            MakeAuthorsForAPA(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += Space;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.Text += Name + PointSpace;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Publisher + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;

            // Том нужно добавить и все просмотреть заного
            if (Vol != 0 && Number != 0)
                rtb.SelectedText += Vol + Lparenthesis + Number + Rparenthesis + CommaSpace;
            else
                if (Vol != 0 && Number == 0)
                rtb.SelectedText += Vol + CommaSpace;
            else
                rtb.SelectedText += Number + CommaSpace;

            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}

            rtb.SelectedText += Pages + Point;
            if (Link != "")
                rtb.SelectedText += Space + Retrieved + Date.ToString("dd MMMM yyyy") + CommaSpace + From + Link;

        }

        public void MakeI3E(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Space = " ";
            const string Access = "Accessed on: ";
            const string Available = "Available: ";
            string vol = "";
            rtb.Text = string.Empty;


            MakeAuthorsForIEEE(Authors);
            rtb.Text += string.Join("", Authors);
            rtb.Text += CommaSpace;


            rtb.Text += "\"" + Name + "\"" + CommaSpace;


            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Publisher + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            //if (Vol == 0)
            //{
            //    var form = new fAdd() { Text = "Добавьте том" };
            //    if (form.ShowDialog() == DialogResult.OK)
            //        Vol = Convert.ToInt32(form.Add);
            //    else
            //        MessageBox.Show("Вы не добавили том, ссылка будет не верна!");
            //}
            rtb.SelectedText += "vol. " + Vol + CommaSpace;
            rtb.SelectedText += "no. " + Number + CommaSpace;
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

            rtb.SelectedText += Pages + CommaSpace;

            rtb.SelectedText += Year + Point;
            if (Link != "")
                rtb.SelectedText += Space + Available + Link + Point + Space + Access + Date.ToString("MMM. dd, yyyy.");
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
