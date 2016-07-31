using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree<T> : ICollection<T>,IEquatable<BinaryTree<T>>
    {
        private class Node<T>
        {
            public T Value{ get; set;}
            public Node<T> Left{ get; set;}
            public Node<T> Right{  get; set;}
            public Node(T value)
            {
                Value = value;
            }
        }
        private Node<T> root;
        private IComparer<T> comparer;
        public IComparer<T> Comparer
        {
            private get { return comparer; }
            set {
                comparer = value;
                try
                {
                    comparer.Compare(default(T), default(T));
                }
                catch (NullReferenceException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                ReTree();
            }
        }
        public BinaryTree() : this(Comparer<T>.Default){}
        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default){}
        public BinaryTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer,   null)) this.comparer = Comparer<T>.Default;
            this.comparer = comparer;
            try
            {
                comparer.Compare(default(T), default(T));
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }          
        }
        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            AddRange(collection);
        }
        /// <summary>
        /// Get MinValue
        /// </summary>
        public T MinValue => SomeValue((t) => t.Left);
        /// <summary>
        /// Get MaxValue
        /// </summary>
        public T MaxValue => SomeValue((t) => t.Right);

        private T SomeValue(Func<Node<T>,Node<T>> fun)
        {
            if (ReferenceEquals(root,null)) throw new InvalidOperationException();
            Node<T> current = root;
            while (fun(current) != null)
                current = fun(current);
            return current.Value;
        }

        /// <summary>
        /// Add collection to tree
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        /// <summary>
        /// Get number of elements
        /// </summary>
        public int Count
        {
            get;
            private set;
        }
        /// <summary>
        /// Add Item to tree
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var node = new Node<T>(item);

            if (root == null)
                root = node;
            else
            {
                Node<T> current = root;
                Node<T> parent = null;

                while (current != null)
                {
                    parent = current;
                    if (comparer.Compare(item, current.Value) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                if (comparer.Compare(item, parent.Value) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }
        /// <summary>
        /// Remove item from tree
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (root == null)
                return false;

            Node<T> current = root;
            Node<T> parent = null;

            int result;
            do
            {
                result = comparer.Compare(item, current.Value);
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null)
                    return false;
            }
            while (result != 0);

            if (current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == root)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;

                if (current == root)
                    root = min;
                else
                {
                    result = comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = min;
                    else
                        parent.Right = min;
                }
            }
            --Count;
            return true;
        }
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        /// <summary>
        /// copy tree to array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException();
            foreach (var value in this)
                array[arrayIndex++] = value;
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// check 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            var current = root;
            while (current != null)
            {
                var result = comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                if (result < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return false;
        }
        #region enumerable
        private Queue<Node<T>> queue;
        private void PreOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                queue.Enqueue(traver);
                PreOrderTravers(traver.Left);
                PreOrderTravers(traver.Right);
            }
        }
        private void InOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                InOrderTravers(traver.Left);
                queue.Enqueue(traver);
                InOrderTravers(traver.Right);
            }
        }
        private void PostOrderTravers(Node<T> traver)
        {
            if (traver != null)
            {
                PostOrderTravers(traver.Left);
                PostOrderTravers(traver.Right);
                queue.Enqueue(traver);
            }  
        public IEnumerable<T> Inorder() => Order(InOrderTravers);
        public IEnumerable<T> Preorder() => Order(PreOrderTravers);
        public IEnumerable<T> Postorder() => Order(PostOrderTravers);
        private IEnumerable<T> Order(Action<Node<T>> fun)
        {
            queue = new Queue<Node<T>>();
            fun(root);
            while (queue.Count > 0)
            { 
                 yield return queue.Dequeue().Value;
            }
        }
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
        #endregion enumerable

        public bool Equals(BinaryTree<T> other) => this.Equals(other);
        private void ReTree()
        {
            List<T> elements = new List<T>();
            foreach (var item in Preorder())
            {
                elements.Add(item);
            }
            root = null;
            AddRange(elements);
        }
    }
}
