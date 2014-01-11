using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Functional.Implementation;
using Functional.Graph;
namespace Functional.Graph {
    public class Edge<C> : IEdge<C> {
        public long ID { get; private set; }
        public C Cost { get; set; }
        public bool Skip { get; set; }
        public long Start { get; private set; }
        public long Destination { get; private set; }
        public Edge(long start, long destination, C cost, long id) {
            this.Start = start; this.Destination = destination; this.Cost = cost; this.ID = id;
        }
    }
    public class Node<T> : INode<T> {
        public long ID { get; private set; }
        public T Name { get; private set; }
        public bool Visited { get; set; }
        public Node(T t, long id) { this.Name = t; this.Visited = false; this.ID = id; }
    }
    public class BNode<T> : IBNode<T> {
        public long ID { get; private set; }
        public T Name { get; private set; }
        public bool Visited { get; set; }
        public IBNode<T> Left { get; set; }
        public IBNode<T> Right { get; set; }
        public IBNode<T> Duplicate { get; set; }
        public BNode(T t, long id) { this.Name = t; this.Visited = false; this.ID = id; }
    }
    public static class Graph {
        private static long _current_node = 0; // a GUID for nodes
        private static long _current_edge = 0; // a GUID for edges

        /// <summary>
        /// Get a list of all the edges created so far
        /// </summary>
        /// <returns>a sequence of all the edges</returns>
        public static IEdge<C> CreateEdge<C>(long start, long destination, C cost) {
            IEdge<C> edge = new Edge<C>(start, destination, cost, _current_edge);
            _current_edge++;
            return edge;
        }
        /// <summary>
        /// Creates a node
        /// </summary>
        /// <returns>an object that implements INode</returns>
        public static INode<T> CreateNode<T>(T t) { 
            INode<T> node = new Node<T>(t,_current_node);
            _current_node++; // beware of long overflow
            return node;
        }

        

        //public static IBNode<T> BinarySearch<T>()
        public static T BinarySearch<T>(IList<T> lst, Func<T, T, int> compare, T item) where T : class {
            T result = null;
            if (lst.Count > 0) {
                int left = 0;
                int right = lst.Count - 1;
                int index = (left + right) >> 1;
                T current = lst[index];
                int cmp = compare(current, item);
                while ((0 != cmp) && (left != right)) {
                    if (cmp < 0) left = index + 1; else if (cmp > 0) right = index - 1;
                    index = ((left + right) >> 1);
                    current = lst[index];
                    cmp = compare(current, item);
                }
                result = (0 == cmp) ? current : null;
            }
            return result;
        }
    }
    public static class Tree {
        private static long _current_bnode = 0;
        /// <summary>
        /// Creates a node
        /// </summary>
        /// <returns>an object that implements INode</returns>
        public static IBNode<T> CreateBNode<T>(T t) {
            IBNode<T> bnode = new BNode<T>(t, _current_bnode);
            _current_bnode++; // beware of long overflow
            return bnode;
        }
        public static void InsertBNode<T>(IBNode<T> parent, IBNode<T> child, Func<T, T, int> compare) {
            IBNode<T> current = parent;
            int cmp = compare(current.Name, child.Name);
            if (0 == cmp) {
                child.Duplicate = current.Duplicate;
                current.Duplicate = child;
            } else if (cmp < 0) {
                if (null == current.Right) current.Right = child;
                else InsertBNode<T>(current.Right, child, compare);
            } else {
                if (null == current.Left) current.Left = child;
                else InsertBNode<T>(current.Left, child, compare);
            }
        }
        public static T BinarySearch<T>(IBNode<T> root, Func<T, T, int> compare, T item) where T : class {
            T result = null;
            IBNode<T> current = root;
            int cmp = compare(current.Name, item);
            while ((null != current) && (0 != cmp)) {
                current = (cmp < 0) ? current.Right : current.Left;
                cmp = (null != current) ? compare(current.Name, item) : 0;
            }
            result = (null != current) ? current.Name : null;
            return result;
        }
    }
}
