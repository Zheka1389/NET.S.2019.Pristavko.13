namespace NET.S._2019.Pristavko._13.Matrixs
{
    using System;

    /// <summary>
    ///  Provides data for the events.
    /// </summary>
    public class MatrixEventArgs<T> : EventArgs
    {
        #region constructors

        public MatrixEventArgs(int i, int j, T oldValue, T newValue)
        {
            this.I = i;
            this.J = j;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        #endregion

        #region properies

        public int I { get; }

        public int J { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        #endregion
    }
}
