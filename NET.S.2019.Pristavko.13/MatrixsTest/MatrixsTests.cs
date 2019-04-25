namespace NET.S._2019.Pristavko._13.MatrixsTest
{
    using NET.S._2019.Pristavko._13.Matrixs;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    class MatrixsTests
    {
        [Test]
        public void OperationAdd()
        {
            int[,] matrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            Square<int> square = new Square<int>(matrix);
            Symmetrical<int> symmetrical = new Symmetrical<int>(matrix);

            int[] expected = new int[]
            {
                 6, 10, 8,
                 10, 12, 16,
                 8, 16, 14
            };

            var result = square.Add(symmetrical);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void OperationAddArgumentNullException()
        {
            int[,] param = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            Square<int> square = new Square<int>(param);
            Symmetrical<int> symmetrical = null;

            Assert.Throws<ArgumentNullException>(
                () => square.Add(symmetrical));
        }

        [Test]
        public void OperationDifferenceSize()
        {
            int[,] param = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            int[,] paramSquare = new int[,]
            {
                { 3, 5 },
                { 5, 6 }
            };

            Square<int> square = new Square<int>(paramSquare);
            Symmetrical<int> symmetrical = new Symmetrical<int>(param);

            Assert.Throws<ArgumentException>(
                () => square.Add(symmetrical));
        }
    }
}
