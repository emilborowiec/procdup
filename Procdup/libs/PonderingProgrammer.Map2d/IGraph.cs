using System;
using System.Collections.Generic;

namespace PonderingProgrammer.Map2d
{
    /// <summary>
    /// An IGraph is a graph of generic <c>Nodes</c> and integer weighted edges.
    /// </summary>
    /// <typeparam name="T">Type of nodes linked by this graph</typeparam>
    public interface IGraph<T>
    {
        T[] Nodes { get; }
        void AddEdge(T node1, T node2, int weight, bool bidirectional = true);
        bool RemoveEdge(T node1, T node2, int weight);
        IEnumerable<Tuple<T, int>> GetEdgesFrom(T node);
        IEnumerable<T> GetAdjacentNodes(T node);
        bool IsConnected();
    }
}
