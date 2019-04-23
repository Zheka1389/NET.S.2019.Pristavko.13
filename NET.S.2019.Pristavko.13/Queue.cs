namespace NET.S._2019.Pristavko._13
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Queue<T> : IEnumerable<T>
    {
        private List<T> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.list = new List<T>();
        }

        public Queue(IEnumerable<T> collection)
        {
            this.list = collection.ToList();
        }

        /// <summary>
        /// Enqueues the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Enqueue(T element)
        {
            this.list.Add(element);
        }

        /// <summary>
        /// Dequeues the specified element.
        /// </summary>
        /// <exception cref="InvalidOperationException">The queue is empty.</exception>
        public T Dequeue()
        {
            if (this.list.Count() == 0)
            {
                throw new Exception("The queue is empty. Can't dequeue from empty queue");
            }

            T value = this.list[0];
            this.list.Remove(value);
            return value;
        }

        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">The queue is empty.</exception>
        public T Peek()
        {
            if (this.list.Count() == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return this.list[0];
        }

        /// <summary>
        /// Clear collection.
        /// </summary>
        public void Clear()
        {
            this.list.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.list);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Enumerator
        /// </summary>
        public class Enumerator : IEnumerator<T>
        {
            private List<T> list;
            private int position = -1;

            public Enumerator(List<T> list)
            {
                this.list = list;
            }

            public T Current
            {
                get
                {
                    if (this.position == -1 || this.position >= this.list.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.list[this.position];
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (this.position < this.list.Count - 1)
                {
                    this.position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}
