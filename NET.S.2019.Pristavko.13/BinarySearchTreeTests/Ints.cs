namespace NET.S._2019.Pristavko._13.BinarySearchTreeTests
{
    using System;
    using System.Collections.Generic;

    public class Ints : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (Math.Log10(x) == Math.Log10(y))
            {
                return 0;
            }

            if (Math.Log10(x) > Math.Log10(y))
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
