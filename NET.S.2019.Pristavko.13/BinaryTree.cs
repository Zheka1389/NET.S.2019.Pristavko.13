namespace NET.S._2019.Pristavko._13
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary Search Tree
    /// </summary>
    public class BinaryTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree()
        {
            this.root = null;
            this.NumOfElements = 0;
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTree{T}"/> class.
        /// </summary>
        public BinaryTree(IComparer<T> comparer) : this() => this.comparer = comparer;

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int NumOfElements { get; private set; }

        #region Base Methods

        public bool Contains(T element) => Find(element, root) != null;

        /// <summary>
        /// Inserts the specified element.
        /// </summary>
        public void Insert(T element)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(element);
                this.NumOfElements++;
                return;
            }

            Insert(element, this.root);
        }

        /// <summary>
        /// Removes the specified element.
        /// </summary>
        public void Remove(T element)
        {
            if (this.root == null)
            {
                return;
            }

            Remove(element, this.root);
        }
        #endregion

        /// <summary>
        /// Pre order.
        /// </summary>
        public IEnumerable<T> PreOrder()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return this.PreOrder(this.root);
        }

        /// <summary>
        /// In order.
        /// </summary>
        public IEnumerable<T> InOrder()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return this.InOrder(this.root);
        }

        /// <summary>
        /// Post order.
        /// </summary>
        public IEnumerable<T> PostOrder()
        {
            if (ReferenceEquals(this.root, null))
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return this.PostOrder(this.root);
        }

        #region Private base methods
        private Node<T> Find(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (this.comparer.Compare(node.Value, element) == 0)
            {
                return node;
            }

            if (this.comparer.Compare(node.Value, element) > 0)
            {
                return this.Find(element, node.Left);
            }
            else
            {
                return this.Find(element, node.Right);
            }
        }

        private void Insert(T element, Node<T> node)
        {
            if (this.comparer.Compare(node.Value, element) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(element);
                    this.NumOfElements++;
                }
                else
                {
                    this.Insert(element, node.Left);
                }
            }

            if (this.comparer.Compare(node.Value, element) <= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(element);
                    this.NumOfElements++;
                }
                else
                {
                    this.Insert(element, node.Right);
                }
            }
        }

        private void Remove(T element, Node<T> node)
        {
            if (this.comparer.Compare(node.Value, element) > 0)
            {
                this.Remove(element, node.Left);
            }

            if (this.comparer.Compare(node.Value, element) < 0)
            {
                this.Remove(element, node.Right);
            }

            if (this.comparer.Compare(node.Value, element) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }

                if (node.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.NumOfElements--;
                    return;
                }

                if (node.Right == null)
                {
                    node = node.Left;
                    node.Left = null;
                    this.NumOfElements--;
                    return;
                }

                if (node.Right.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.NumOfElements--;
                    return;
                }
                else
                {
                    Node<T> theMostLeft = this.FindTheMostLeft(node.Right);
                    node.Value = theMostLeft.Value;
                    this.Remove(theMostLeft.Value);
                }
            }
        }

        private Node<T> FindTheMostLeft(Node<T> node)
        {
            if (node.Left != null)
            {
                this.FindTheMostLeft(node.Left);
            }

            return node;
        }

        #endregion

        #region Private Traverce methods

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var element in this.PreOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in this.PreOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.InOrder(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var element in this.InOrder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.PostOrder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in this.PostOrder(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Value;
        }

        public IEnumerator<T> GetEnumerator() => this.InOrder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.InOrder().GetEnumerator();
        #endregion   
    }
}
