using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath.Shapes;

namespace PonderingProgrammer.Map2d.ProcGen.Mazes
{
    public static class RandomizedPrimMazeGenerator
    {
        private static Random Rng = new Random();
        
        public static GridPolyPoint GenerateMaze(IGridMap map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            
            var graph = map.GetGraph(false);

            var passages = new List<GridMapField>();
            var walls = new List<GridMapField>();
            var startNode = graph.Nodes[Rng.Next(graph.Nodes.Length)];
            passages.Add(startNode);
            walls.AddRange(graph.GetAdjacentNodes(startNode));
            while (walls.Count > 0)
            {
                var wall = PickWall(walls, graph, passages);

                if (wall == null) break;
                
                passages.Add(wall);
                walls.Remove(wall);

                walls.AddRange(graph.GetAdjacentNodes(wall)
                               .Where(f => graph.GetAdjacentNodes(f).Count(passages.Contains) == 1));
            }
            return new GridPolyPoint(passages.Select(f => f.Coordinates));
        }

        private static GridMapField PickWall(IEnumerable<GridMapField> walls, GridMapAdjacencyList graph, ICollection<GridMapField> paths)
        {
            var notConnectingWalls = walls.Where(wall => graph.GetAdjacentNodes(wall).Count(paths.Contains) == 1).ToList();
            return notConnectingWalls.Any() ? notConnectingWalls[Rng.Next(notConnectingWalls.Count)] : null;
        }
    }
}