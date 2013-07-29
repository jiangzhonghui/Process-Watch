using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProcesyTest
{
    public static class Utility
    {
        public static void ListViewSort(ListView listView, ref int sortColumn, int column)
        {
            if (column != sortColumn)
            {
                sortColumn = column;
                listView.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listView.Sorting == SortOrder.Ascending)
                    listView.Sorting = SortOrder.Descending;
                else
                    listView.Sorting = SortOrder.Ascending;
            }

            //?
            // http://msdn.microsoft.com/en-us/library/ms996467.aspx

            listView.ListViewItemSorter = new ListViewItemComparer(column, listView.Sorting);

            listView.Sort();
        }
    }
}
