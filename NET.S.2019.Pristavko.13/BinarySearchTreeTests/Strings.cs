using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._13.BinarySearchTreeTests
{
    public class Strings : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return 0;
            }

            if (x.Length > y.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
