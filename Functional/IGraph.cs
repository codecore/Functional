using System.Collections.Generic;

namespace Functional.Graph {
    public interface IEdge<C> {
        long ID { get; }
        C Cost { get; set; }
        bool Skip { get; set; }
        long Start { get; }
        long Destination { get; }
    }
    public interface INode<T> {
        long ID { get; }
        T Name { get; }
        bool Visited { get; set; }
    }
    public interface IBNode<T> {
        long ID { get; }
        T Name { get; }
        bool Visited { get; set; }
        IBNode<T> Left { get; set; }
        IBNode<T> Right { get; set; }
        IBNode<T> Duplicate { get; set; }
    }
}
