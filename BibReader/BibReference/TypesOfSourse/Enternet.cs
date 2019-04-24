using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.BibReference.TypesOfSourse
{
   
    public class Enternet
    {
        string Hyperlink;
        string NameOfSite;
        string TitleOfArticle;
        int Year;
        DateTime Date;

        public Enternet(string hyperlink, string nameOfSite, string titleOfArticle, DateTime date, int year)
        {
            Hyperlink = hyperlink;
            NameOfSite = nameOfSite;
            TitleOfArticle = titleOfArticle;
            Date = date;
            Year = year;
        }

        public void MakeGOST(ref RichTextBox rtb)
        {
            const string Space = " ";
            const string Point = ".";
            const string PointSpace = ". ";
            const string DoublePointSpace = ": ";
            const string DoubleSlash = "// ";
            const string URL = "URL: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string DateRus = "дата обращения";
            string result = string.Empty;

            result += TitleOfArticle + Space + DoubleSlash;
            result += NameOfSite + PointSpace;
            result += Year + PointSpace;
            result += URL + Hyperlink + Space;
            result += Lparenthesis + DateRus + DoublePointSpace + Date.ToString("dd.MM.yyyy") + Rparenthesis + Point;
            rtb.Text = result;
        }

        public void MakeHarvard(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string Point = ".";
            const string PointSpace = ". ";
            const string Avaliable = "Avaliable at: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Lpar = "[";
            const string Rpar = "]";
            const string DateRus = "Accessed ";
            const string Online = "[ONLINE]";
            rtb.Text = string.Empty;

            rtb.Text += NameOfSite + PointSpace;
            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.Text += TitleOfArticle + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;

            rtb.SelectedText += Online + Space + Avaliable;
            rtb.SelectedText += Hyperlink + PointSpace;
            rtb.Text += Lpar + DateRus + Date.ToString("dd MMM yyyy") + Rpar + Point;
        }

        public void MakeAPA(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string Point = ".";
            const string PointSpace = ". ";
            const string Access = "Доступ ";
            const string CommaSpace = ", ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Retrieved = "Retrieved ";
            const string From = "from ";

            rtb.Text = string.Empty;
            //rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.Text += TitleOfArticle + Point + Space;          
            //rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;

            rtb.Text += Lparenthesis + Year + Rparenthesis + PointSpace;

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += NameOfSite;
            if (NameOfSite[NameOfSite.Length - 1] != '.')
                rtb.SelectedText += PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            
            rtb.SelectedText += Retrieved + Date.ToString("dd MMMM yyyy") + CommaSpace;
            rtb.SelectedText += From + Hyperlink;

        }      

        public void MakeI3E(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string PointSpace = ". ";
            const string Access = "Accessed: ";
            const string Avaliable = "Avaliable: ";
            const string CommaSpace = ", ";
            rtb.Text = string.Empty;

            rtb.Text += NameOfSite + CommaSpace;
            
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText += TitleOfArticle;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText += CommaSpace;
            rtb.SelectedText += Year + PointSpace;
            rtb.SelectedText += Avaliable + Hyperlink + PointSpace;
            rtb.SelectedText += Access + Date.ToString("MMM. dd, yyyy.");
            
        }
    }

}
