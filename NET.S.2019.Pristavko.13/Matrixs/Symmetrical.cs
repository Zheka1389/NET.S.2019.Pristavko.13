namespace NET.S._2019.Pristavko._13.Matrixs
{
    using System;

    /// <summary>
    /// Provides methods to work with the symmetrical matrix.
    /// </summary>
    public class Symmetrical<T> : Square<T>
        where T : IComparable<T>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Symmetrical(int size)
                : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Symmetrical(T[,] matrix)
            : base(matrix)
        {
            if (!this.IsSymmetrical(matrix))
            {
                throw new ArgumentException($"{matrix} must be a symmetrical matrix.");
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// The indexer.
        /// </summary>
        public override T this[int i, int j]
        {
            get
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.Container[i, j];
            }

            set
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                this.OnChangeValue(new MatrixEventArgs<T>(i, j, this.Container[i, j], value));
                this.Container[i, j] = value;
                base[j, i] = value;
            }
        }

        #endregion

        #region private methods

        private bool IsSymmetrical(T[,] array)
        {
            for (int i = 0; i < this.Container.GetLength(0); i++)
            {
                for (int j = 0; j < this.Container.GetLength(1); j++)
                {
                    if (array[i, j].CompareTo(array[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
