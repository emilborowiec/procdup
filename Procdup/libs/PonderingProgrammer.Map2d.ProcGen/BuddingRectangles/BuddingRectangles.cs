using System;
using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.FeatureObjects;
using PonderingProgrammer.Map2d.ProcGen.Randoms;
using RandomBoxFactory = PonderingProgrammer.Map2d.ProcGen.Randoms.RandomBoxFactory;

namespace PonderingProgrammer.Map2d.ProcGen.BuddingRectangles
{
    public class BuddingRectangles
    {
        private RandomBoxFactory _randomBoxFactory = new RandomBoxFactory();
        private Random _rand = new Random();
        
        public IGridMap Generate(BuddingRectanglesGenerationOptions options)
        {
            var map = new GridMap(options.Width, options.Height);
            var roomsToVisit = new List<Room>();

            var box = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
            box = box.Relate(map.Bounds, Relation.CenterToCenter(),
                Relation.CenterToCenter());
            var firstRoom = new Room { Box = box };
            map.AddFeature(new GridRectFeature(FeatureType.Room, box));
            roomsToVisit.Add(firstRoom);

            while (roomsToVisit.Count > 0)
            {
                var room = roomsToVisit.First();
                box = _randomBoxFactory.RandomSizeBox(options.MinRectSize, options.MaxRectSize);
                foreach (var direction in _rand.ShuffleEnum<Grid4Direction>())
                {
                    if (!room.WallsToRooms.ContainsKey(direction))
                    {
                        box = box.PlaceBeside(room.Box, direction);
                        if (map.GetFeaturesInBoundary(box).Any() || !map.Bounds.Contains(box))
                        {
                            continue;
                        }

                        // no collision and within map bounds
                        var newRoom = new Room {Box = box};
                        room.WallsToRooms[direction] = newRoom;
                        map.AddFeature(new GridRectFeature(FeatureType.Room, box));
                        roomsToVisit.Add(newRoom);
                    }
                }

                roomsToVisit.Remove(room);
            }
            return map;
        }
    }
}
