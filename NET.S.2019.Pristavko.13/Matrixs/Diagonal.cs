

namespace NET.S._2019.Pristavko._13.Matrixs
{
    using System;

    /// <summary>
    /// Provides methods to work with the dioganal matrix.
    /// </summary>
    public class Diagonal<T> : Square<T>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Diagonal(int size)
            : base(size)
        {
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

                if (!this.IsDioganal(i, j))
                {
                    throw new IndexOutOfRangeException("indexs must be on main dioganal.");
                }

                this.OnChangeValue(new MatrixEventArgs<T>(i, j, this.Container[i, j], value));
                this.Container[i, j] = value;
            }
        }

        #endregion

        #region private methods

        private bool IsDioganal(int i, int j) => i == j;

        #endregion
    }
}
