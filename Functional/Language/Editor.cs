using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    [Export(typeof(IEditor))]
    public class SimpleEditor : IEditor {
        public EditorKind Kind { get { return EditorKind.Simple; } }
        private DLList<ICodeDocument> codedocuments = new DLList<ICodeDocument>();
        public IEnumerable<ICodeDocument> CodeDocuments { get { return this.codedocuments; } }
    }


    public class DLNode<T> {
        public DLNode<T> Prev { get; set; }
        public DLNode<T> Next { get; set; }
        public T Item { get; set; }
        public int ID { get; set; }
        public DLNode(T item){ 
            this.Item = item;
            this.Prev = null;
            this.Next = null;
        }
        private DLNode(){}
    }
    public class DLList<T> : IEnumerable<T> where T :class {
        private static DLNode<T> avail = null;
        private static void Delete(DLNode<T> node) { node.Item = null;  node.Next = avail; avail = node; }
        private static DLNode<T> New(T item) {
            DLNode<T> result = null;
            if (null != avail) {
                result = avail;
                avail = avail.Next;
                result.Prev = null;
                result.Next = null;
                result.Item = item;
            } else result = new DLNode<T>(item);
            return result;
        }
        private static void freeMemory() {
            DLNode<T> current = avail;
            DLNode<T> next = avail;
            while (null != current) {
                next = current.Next;
                current.Item = null;
                current.Prev = null;
                current.Next = null;
                current = next;
            }
            avail = null;
        }
        public void FreeMemory() { freeMemory(); }
        public DLList() {
            this.myEnumerator = new DLListEnumerator<T>(this);
        }
        private class DLListEnumerator<M> : IEnumerator<M> where M : class {
            public void SetValid(DLNode<M> start) {
                this.root = start;
            }
            public void SetInvalid() {
                this.root = null;
                this.current = null;
            }
            private DLNode<M> root = null;
            private DLNode<M> current = null;
             object System.Collections.IEnumerator.Current  { get { return (null != this.current)?this.current.Item:null; } }
            public M Current { get { return (null != this.current) ? this.current.Item : null; } }
            public bool MoveNext() {
                if (null == this.current) this.current = this.root;
                else this.current = this.current.Next;
                return (null != this.current);
            }
            public void Reset() { this.Parent.RequestValidEnumerator(); }
            public void Dispose() { }
            private DLList<T> Parent;
            public DLListEnumerator(DLList<T> parent) { this.Parent = parent; }
            private DLListEnumerator() { } // no empty constructor
        }
        public void RequestValidEnumerator() {
            this.myEnumerator.SetValid(this.head);
        }
        private DLListEnumerator<T> myEnumerator;
        public IEnumerator<T> GetEnumerator() {
            this.myEnumerator.SetValid(this.head);
            return this.myEnumerator;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { // this is FU
            return this.GetEnumerator();
        }
        private DLNode<T> cursor = null;
        public void MoveCursorNext() {
            if (null != this.cursor) {
                if (null != this.cursor.Next) this.cursor = this.cursor.Next;
            } else cursor = this.tail;
        }
        public void MoveCursorPrev() {
            if (null != this.cursor) {
                if (null != this.cursor.Prev) this.cursor = this.cursor.Prev;
            } else cursor = this.head;
        }
        public T Cursor { get { return (null != this.cursor) ? this.cursor.Item : null; } }

        private DLNode<T> head = null;
        private DLNode<T> tail = null;
        public void AddBefore(T item) {
            this.myEnumerator.SetInvalid();
            DLNode<T> node = New(item);
            if (null == this.head) {
                this.head = node;
                this.tail = node;
                this.cursor = node;
            } else if (this.cursor == this.head) { // neither head nor cursor are null
                this.head = node;
                node.Next = this.cursor;
                node.Next.Prev = node;
                this.cursor = node;  // we set cursor to the inserted node
            } else {
                node.Prev = this.cursor.Prev;
                node.Next = this.cursor;
                node.Prev.Next = node;
                node.Next.Prev = node;
                this.cursor = node; // we set the curser to the inserted node
            }                
        }
        public void AddAfter(T item) {
            this.myEnumerator.SetInvalid();
            DLNode<T> node = New(item);
            if (null == this.tail) {
                this.tail = node;
                this.head = node;
                this.cursor = node;
            } else if (this.cursor == this.tail) { // neither tail nor cursor are null
                this.tail = node;
                node.Prev = this.cursor;
                node.Prev.Next = node;
                this.cursor = node; // we set the cursor ti the inserted node
            } else {
                node.Next = this.cursor.Next;
                node.Prev = this.cursor;
                node.Next.Prev = node;
                node.Prev.Next = node;
                this.cursor = node; // we set the cursor to the inserted node
            }
        }
        public void Remove() {
            this.myEnumerator.SetInvalid();
            if (null != this.cursor) {
                DLNode<T> old = this.cursor;
                if (this.cursor == this.head) this.head = this.cursor.Next;
                if (this.cursor == this.tail) this.tail = this.cursor.Prev;
                if (null != this.cursor.Next) this.cursor.Next.Prev = this.cursor.Prev;
                if (null != this.cursor.Prev) this.cursor.Prev.Next = this.cursor.Next;
                if (null != this.cursor.Next) this.cursor = this.cursor.Next;
                else this.cursor = this.cursor.Prev;
                Delete(old);
            }
        }
    }

    
}