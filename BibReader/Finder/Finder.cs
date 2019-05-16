using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.Finder
{
    class Finder
    {
        int CurrentIndex = -1;

        public static List<int> MakeListOfIndexes(string findedText, ListView listView, int columnNumber)
        {
            return
                listView.Items.Cast<ListViewItem>()
                .Where(
                    item =>
                    item.SubItems[columnNumber].Text.ToLower().IndexOf(findedText.ToLower()) >= 0
                )
                .Select(item => item.Index)
                .ToList();
        }

        public static List<int> MakeListOfIndexes(string findedText, List<string> list)
        {
            return
                list
                .Where(
                    item =>
                    item.ToLower().IndexOf(findedText.ToLower()) >= 0
                )
                .Select((item, index) => index)
                .ToList();
        }

        public int GetIndex(List<int> indexes, Func<List<int>, int, int> func)
        {
            return
                CurrentIndex = 
                indexes.Count > 0
                ? func(indexes, CurrentIndex)
                : -1;
        }

        public static int Prev(List<int> indexes, int currentIndex) =>
            currentIndex <= indexes.First() || currentIndex == -1
            ? indexes.Last()
            : indexes.Last(x => x < currentIndex);

        public static int Next(List<int> indexes, int currentIndex) =>
            currentIndex >= indexes.Last() || currentIndex == -1
            ? indexes.First()
            : indexes.First(x => x > currentIndex);

        public static void SelectItem(ListView listView, int currentIndex)
        {
            if (currentIndex != -1)
            {
                listView.Select();
                foreach (ListViewItem item in listView.SelectedItems)
                    item.Selected = false;
                listView.Items[currentIndex].Selected = true;
                listView.EnsureVisible(currentIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
        }
    }
}
