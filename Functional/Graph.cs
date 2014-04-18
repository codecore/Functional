using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Functional.Implementation;
using Functional.Graph;
namespace Functional.Graph {
    public class Edge<C> {
        public long ID { get; private set; }
        public C Cost { get; set; }
        public bool Skip { get; set; }
        public long Start { get; private set; }
        public long Destination { get; private set; }
        public Edge(long start, long destination, C cost, long id) {
            this.Start = start; this.Destination = destination; this.Cost = cost; this.ID = id;
        }
    }

    public class BinaryNode<T> {
        public override string ToString() { return this.Value.ToString(); }
        public BinaryNode(T value) { this.Value = value; }
        public T Value { get; set; }
        private BinaryNode<T> left = null;
        public BinaryNode<T> Left { get { return this.left; } set { this.left = value; } }
        private BinaryNode<T> right = null;
        public BinaryNode<T> Right { get { return this.right; } set { this.right = value; } }
        private BinaryNode<T> parent = null;
        public BinaryNode<T> Parent { get { return this.parent; } set { this.parent = value; } }
    }
    public enum Order { pre_order, post_order, in_order, reverese_order }
    public class BinaryTree<T> {
        private static Func<BinaryNode<T>,bool> isRightChild = (node) => (null != node)?((null != node.Parent) ? (node == node.Parent.Right) : false):false;
        private static Func<BinaryNode<T>,bool> isLeftChild  = (node) => (null != node)?((null != node.Parent) ? (node == node.Parent.Left) : false):false;
        
        public static Func<int, int, int> compare_int = (left, right) => (left == right) ? 0 : (left < right) ? -1 : 1;
        public static BinaryNode<T> FindNext(BinaryNode<T> node, Order order) {
            if (order == Order.in_order) {
                if (null != node.Right) return leftMost(node.Right);
                if (isLeftChild(node)) return node.Parent;
                // must be a right node without a right child, or the root.
                // climb the parents until the root or until a left child.
                while ((null != node) && (!isLeftChild(node))) node = node.Parent;
                return (null != node) ? node.Parent : null;
            }
            return null;
        }
        private static BinaryNode<T> leftMost(BinaryNode<T> node) {
            BinaryNode<T> current = node;
            while (null != current.Left) current = current.Left;
            return current;
        }
        private static BinaryNode<T> rightMost(BinaryNode<T> node) {
            BinaryNode<T> current = node;
            while (null != current.Right) current = current.Right;
            return current;
        }
        public static BinaryNode<T> FindRecursive(BinaryNode<T> root, T value,Func<BinaryNode<T>,T> tx, Func<T,T,int> compare) {
            BinaryNode<T> current = root;
            if (null != current) {
                int cmp = compare(value, tx(current));
                if (0 != cmp) current = (cmp < 0) ? FindRecursive(current.Left, value, tx, compare) : FindRecursive(current.Right, value, tx, compare);
            }
            return current;
        }
        public static BinaryNode<T> FindIterate(BinaryNode<T> root, T value, Func<BinaryNode<T>,T> tx, Func<T,T,int> compare) {
            BinaryNode<T> current = root;
            bool found = false;
            while ((null != current) && (!found)) {
                int cmp = compare(value, tx(current));
                found = (0 == cmp);
                if (!found) current = (cmp < 0) ? current.Left : current.Right;
            }
            return current;
        }
        public static void InsertIterate(BinaryNode<T> parent, BinaryNode<T> new_item, Func<BinaryNode<T>,T> tx, Func<T,T,int> compare) {
            BinaryNode<T> current = parent;
            BinaryNode<T> prev = current;
            int cmp = 0;
            while (null != current) {
                cmp = compare(tx(current), tx(new_item));
                prev = current;
                current = (0 < cmp) ? current.Left : current.Right;
            }
            new_item.Parent = prev;
            if (0 < cmp) prev.Left = new_item; else prev.Right = new_item;
        }
        public static void InsertRecursive(BinaryNode<T> parent, BinaryNode<T> new_item, Func<BinaryNode<T>,T> tx, Func<T,T,int> compare) {
            if (0 < compare(tx(parent), tx(new_item))) {
                if (null == parent.Left) { 
                    parent.Left = new_item; 
                    new_item.Parent = parent;
                } else InsertRecursive(parent.Left, new_item, tx, compare);
            } else {
                if (null == parent.Right) { 
                    parent.Right = new_item; 
                    new_item.Parent = parent; 
                } else InsertRecursive(parent.Right, new_item, tx, compare);
            }
        }
        public static IEnumerable<T> InOrderRecursive(BinaryNode<T> root, Func<BinaryNode<T>,T> tx) {
            foreach(T t in C<BinaryNode<T>>.sequence_if_not_null<T>(InOrderRecursive, root.Left, tx)) yield return t;
            yield return tx(root);
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(InOrderRecursive, root.Right, tx)) yield return t;
        }
        public static IEnumerable<T> PreOrderRecursive(BinaryNode<T> root, Func<BinaryNode<T>,T> tx) {
            yield return tx(root);
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(PreOrderRecursive, root.Left, tx)) yield return t;
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(PreOrderRecursive, root.Right, tx)) yield return t;
        }
        public static IEnumerable<T> PostOrderRecursive(BinaryNode<T> root, Func<BinaryNode<T>,T> tx) {
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(PreOrderRecursive, root.Left, tx)) yield return t;
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(PreOrderRecursive, root.Right, tx)) yield return t;
            yield return tx(root);
        }
        public static IEnumerable<T> ReverseOrderRecursive(BinaryNode<T> root, Func<BinaryNode<T>, T> tx) {
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(ReverseOrderRecursive, root.Right, tx)) yield return t;
            yield return tx(root);
            foreach (T t in C<BinaryNode<T>>.sequence_if_not_null<T>(ReverseOrderRecursive, root.Left, tx)) yield return t;
        }
    }
}
