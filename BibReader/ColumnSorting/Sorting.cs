using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.ColumnSorting
{
    class Sorting
    {
        public static void SortingByColumn(ListView listView, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = listView.ListViewItemSorter as ListViewItemComparer;
            if (sorter == null)
            {
                sorter = new ListViewItemComparer(e.Column);
                int val;
                if (Int32.TryParse(listView.Items[0].SubItems[e.Column].Text, out val))
                    sorter.Numeric = true;
                else
                    sorter.Numeric = false;

                listView.ListViewItemSorter = sorter;
            }
            else
            {
                int val;
                if (Int32.TryParse(listView.Items[0].SubItems[e.Column].Text, out val))
                    sorter.Numeric = true;
                else
                    sorter.Numeric = false;
                sorter.Column = e.Column;
            }
            listView.Sort();
        }

        public class ListViewItemComparer : IComparer
        {
            public int Column { get; set; }

            public bool Numeric { get; set; }

            public ListViewItemComparer(int columnIndex)
            {
                Column = columnIndex;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                if (itemX == null && itemY == null)
                    return 0;
                else if (itemX == null)
                    return -1;
                else if (itemY == null)
                    return 1;

                if (itemX == itemY) return 0;

                if (Numeric)
                {
                    decimal itemXVal, itemYVal;

                    if (!Decimal.TryParse(itemX.SubItems[Column].Text, out itemXVal))
                    {
                        itemXVal = 0;
                    }
                    if (!Decimal.TryParse(itemY.SubItems[Column].Text, out itemYVal))
                    {
                        itemYVal = 0;
                    }

                    return Decimal.Compare(itemXVal, itemYVal);
                }
                else
                {
                    string itemXText = itemX.SubItems[Column].Text;
                    string itemYText = itemY.SubItems[Column].Text;

                    return String.Compare(itemXText, itemYText);
                }
            }
        }
    }
}
