using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

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


        public static void RefreshProcessesListView(ListView listView, Watcher watcher)
        {
            listView.Items.Clear();

            foreach (ProcessToWatch p in watcher.Processes)
            {
                ListViewItem t = new ListViewItem(p.ToString());
                t.Text = p.ToString();
                t.Name = p.ToString();
                listView.Items.Add(t);   
            }
        }

        public static void ChceckAllListViewItems(ListView listView, bool state)
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                listView.Items[i].Checked = state;
            }
        }

        public static void SelectAllListView(ListView listView, bool state)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Selected = state;
            }
        }

        public static void ListViewCheckOneClick(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                if (listView.SelectedItems[0].Checked == true)
                    listView.SelectedItems[0].Checked = false;
                else
                    listView.SelectedItems[0].Checked = true;

            }
        }

        public static void RemoveCheckListViewItems(ListView listView)
        {
            while (listView.CheckedIndices.Count > 0)
            {
                listView.Items.RemoveAt(listView.CheckedIndices[0]);
            }
        }

        public static string About()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            StringBuilder str = new StringBuilder();
            str.Append(assembly.GetName().Name);
            str.AppendLine();
            str.AppendFormat("Version: {0}", assembly.GetName().Version.ToString());
            str.AppendLine();
            str.AppendFormat("Author: {0}", "Michal Dardas");

            return str.ToString();
        }
    }




}
