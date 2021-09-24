using System;
using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Map2d
{
    /// <summary>
    /// A <c>GridMapAdjacencyList</c> is an <c>IGraph</c> that represents adjacency of <c>IGridMap</c>s fields.
    /// A node this graph is <c>GridMapField</c>.
    /// It can be built for all of map's fields, or subset of them.
    /// </summary>
    public class GridMapAdjacencyList : IGraph<GridMapField>
    {
        private readonly List<GridMapField> _nodes;
        private readonly LinkedList<Tuple<int, int>>[] _adjacencyList;

        public GridMapAdjacencyList(IGridMap gridMap, Func<GridMapField, bool> predicate = null)
        {
            _nodes = new List<GridMapField>();
            foreach (var field in gridMap.Fields)
            {
                if (predicate != null && !predicate.Invoke(field)) continue;
                
                _nodes.Add(field);
            }
            
            _adjacencyList = new LinkedList<Tuple<int, int>>[_nodes.Count];
            for (var i = 0; i < _adjacencyList.Length; ++i)
            {
                _adjacencyList[i] = new LinkedList<Tuple<int, int>>();
            }
        }

        public GridMapField[] Nodes => _nodes.ToArray();
        
        public void AddEdge(GridMapField node1, GridMapField node2, int weight, bool bidirectional = true)
        {
            var node1Index = GetNodeIndex(node1);
            var node2Index = GetNodeIndex(node2);
            AddEdgeIfNew(node1Index, node2Index, weight);
            if (bidirectional) AddEdgeIfNew(node2Index, node1Index, weight);
        }

        public bool RemoveEdge(GridMapField node1, GridMapField node2, int weight)
        {
            var node1Index = GetNodeIndex(node1);
            var node2Index = GetNodeIndex(node2);
            Tuple<int, int> edge = new Tuple<int, int>(node2Index, weight);
 
            return _adjacencyList[node1Index].Remove(edge);
        }
        
        public IEnumerable<Tuple<GridMapField, int>> GetEdgesFrom(GridMapField node)
        {
            return new LinkedList<Tuple<GridMapField, int>>(_adjacencyList[GetNodeIndex(node)].Select(edge => new Tuple<GridMapField, int>(_nodes[edge.Item1], edge.Item2)));
        }

        public IEnumerable<GridMapField> GetAdjacentNodes(GridMapField node)
        {
            return GetEdgesFrom(node).Select(edge => edge.Item1).ToList();
        }
        
        public bool IsConnected()
        {
            if (_nodes.Count == 0) return false;
            
            // Using breadth-first search
            var queue = new Queue<Tuple<int, int>>();
            var discovered = new List<int>();

            discovered.Add(0);
            foreach (var edge in _adjacencyList[0])
            {
                queue.Enqueue(edge);
            }

            while (queue.Count > 0)
            {
                var (nodeIndex, _) = queue.Dequeue();
                if (discovered.Contains(nodeIndex)) continue;
                
                discovered.Add(nodeIndex);
                foreach (var newEdge in _adjacencyList[nodeIndex])
                {
                    queue.Enqueue(newEdge);
                }
            }

            return discovered.Count == _nodes.Count;
        }

        private int GetNodeIndex(GridMapField node)
        {
            for (var index = 0; index < _nodes.Count; index++)
            {
                if (_nodes[index] == node) return index;
            }

            return -1;
        }
        
        private void AddEdgeIfNew(int node1Index, int node2Index, int weight)
        {
            if (_adjacencyList[node1Index].All(tuple => tuple.Item1 != node2Index))
                _adjacencyList[node1Index].AddLast(new Tuple<int, int>(node2Index, weight));
        }
    }
}
