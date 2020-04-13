using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkCity.Tiles
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
    }
}
