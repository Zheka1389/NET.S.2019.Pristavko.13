namespace NET.S._2019.Pristavko._13.Matrixs
{
    using System;

    public static class Operation
    {
        public static Square<T> Add<T>(this Square<T> first, Square<T> second)
        {
            if (first is null || second is null)
            {
                throw new ArgumentNullException("Matrix can not be null");
            }

            if (first.GetSize() != second.GetSize())
            {
                throw new ArgumentException("matrix must be the same size.");
            }

            Square<T> newMatrix = new Square<T>(first.GetSize());

            for (int i = 0; i < second.GetSize(); i++)
            {
                for (int j = 0; j < second.GetSize(); j++)
                {
                    newMatrix[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                }
            }

            return newMatrix;
        }
    }
}
