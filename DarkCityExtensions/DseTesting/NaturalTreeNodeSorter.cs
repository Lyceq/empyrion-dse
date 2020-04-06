using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DseTesting
{
    class NaturalTreeNodeSorter : IComparer
    {
        public NaturalTreeNodeSorter() { }

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string psz1, string psz2);

        public int Compare(object x, object y)
        {
            return StrCmpLogicalW(((TreeNode)x).Text, ((TreeNode)y).Text);
        }

        //public int Compare(object x, object y)
        //{
        //    TreeNode n1 = x as TreeNode;
        //    TreeNode n2 = y as TreeNode;

        //    string s1 = Regex.Replace(n1.Text, @"\d+", m => m.Value.PadLeft(50, '0'));
        //    string s2 = Regex.Replace(n2.Text, @"\d+", m => m.Value.PadLeft(50, '0'));

        //    return string.Compare(s1, s2, StringComparison.CurrentCultureIgnoreCase);
        //}
    }
}
