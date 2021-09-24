using System.Collections.Generic;
using NetTopologySuite.Geometries;
using PonderingProgrammer.GridMath;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class Room
    {
        public GridBoundingBox Box { get; set; }
        public Dictionary<Grid4Direction, Room> WallsToRooms { get; } = new Dictionary<Grid4Direction, Room>();
    }
}
