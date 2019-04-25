namespace NET.S._2019.Pristavko._13.BinarySearchTreeTests
{
    using System.Collections.Generic;

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
