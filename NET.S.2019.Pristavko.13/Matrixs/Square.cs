namespace NET.S._2019.Pristavko._13.Matrixs
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Provides the methods to work with square matrix.
    /// </summary>
    public class Square<T> : IEnumerable<T>
    {
        #region fields

        private T[,] container;
        private int size;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Square(int size)
        {
            this.SetSize(size);
            this.container = new T[this.GetSize(), this.GetSize()];
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Square(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Must be square matrix.");
            }

            this.SetSize(array.GetLength(0));
            this.container = array;
        }

        #endregion

        #region properties

        public event EventHandler<MatrixEventArgs<T>> ChangeValue;

        protected T[,] Container { get => this.container; set => this.container = value; }
        /// <summary>
        /// The indexer.
        /// </summary>
        public virtual T this[int i, int j]
        {
            get
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.container[i, j];
            }

            set
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                this.container[i, j] = value;
            }
        }

        /// <summary>
        /// Size of the matrix.
        /// </summary>
        public int GetSize()
        {
            return this.size;
        }      
 
        /// <summary>
        /// Returns an enumerator that iterates through matrix.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.container.GetLength(0); i++)
            {
                for (int j = 0; j < this.container.GetLength(1); j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.container.GetEnumerator();

        /// <summary>
        /// Size of the matrix.
        /// </summary>
        protected void SetSize(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be greater than 0.");
            }

            this.size = value;
        }     

        #endregion

        #region public methods

        protected virtual void OnChangeValue(MatrixEventArgs<T> eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }

            this.ChangeValue?.Invoke(this, eventArgs);
        }

        #endregion

        #region private methods

        protected bool VerifyIndex(int i, int j) => i < this.GetSize() && j < this.GetSize();

        #endregion
    }
}
