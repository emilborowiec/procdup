using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.GridMath.Shapes;

namespace PonderingProgrammer.Map2d.ProcGen.Mazes
{
    public static class RandomizedDepthFirstMazeGenerator
    {
        private static readonly Random Rng = new Random();
        
        public static GridPolyPoint GenerateMaze(IGridMap map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            
            var graph = map.GetGraph(false);

            var passages = new List<GridMapField>();
            var stack = new Stack<GridMapField>();
            var startNode = graph.Nodes[Rng.Next(graph.Nodes.Length)];
            passages.Add(startNode);
            stack.Push(startNode);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var step = PickStep(currentNode, map, passages);
                
                if (step == null) continue;
                
                stack.Push(currentNode);
                var wall = map.GetFieldAt(
                    (currentNode.Coordinates.X + step.Coordinates.X) / 2,
                    (currentNode.Coordinates.Y + step.Coordinates.Y) / 2);
                passages.Add(wall);
                passages.Add(step);
                stack.Push(step);
            }

            return new GridPolyPoint(passages.Select(f => f.Coordinates));
        }

        private static GridMapField PickStep(GridMapField currentNode, IGridMap map, List<GridMapField> passages)
        {
            var up = currentNode.Coordinates.Translation(0, -2);
            var down = currentNode.Coordinates.Translation(0, 2);
            var left = currentNode.Coordinates.Translation(-2, 0);
            var right = currentNode.Coordinates.Translation(2, 0);
            var candidates = new List<GridCoordinatePair> {up, down, left, right}
                .Select(map.GetFieldAt).Where(f => f != null)
                .Where(f => !passages.Contains(f))
                .ToList();
            return candidates.Count == 0 ? null : candidates[Rng.Next(candidates.Count)];
        }
    }
}