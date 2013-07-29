using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace ProcesyTest
{
    public class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int col, SortOrder order)
        {
            this.col = col;
            this.order = order;
        }

        public int Compare(object x, object y)
        {

            int returnValue = -1;

            try
            {
                DateTime firstDate = DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                DateTime secondDate = DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                returnValue = DateTime.Compare(firstDate, secondDate);
            }
            //argumenty nie sa data, obsluguejemy jak zwykle stringi
            catch
            {
                returnValue = String.Compare(((ListViewItem)x).SubItems[col].Text,
                    ((ListViewItem)y).SubItems[col].Text);
            }

            if (order == SortOrder.Descending)
                returnValue *= -1;

            return returnValue;
        }
    }
}
