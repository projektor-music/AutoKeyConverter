using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoKeyConverter
{
    class ListViewSorter : System.Collections.IComparer
    {
        public int Column = 0;
        public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            int fl1 = int.Parse(new String(l1.SubItems[Column].Text.TakeWhile(Char.IsDigit).ToArray()));
            int fl2 = int.Parse(new String(l2.SubItems[Column].Text.TakeWhile(Char.IsDigit).ToArray()));

            if (Order == SortOrder.Ascending)
            {
                return fl1.CompareTo(fl2);
            }
            else
            {
                return fl2.CompareTo(fl1);
            } 
        }
    }
}
