using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.ProcGenDemo
{
    public static class MapRenderer
    {
        private static readonly Color MapBackgroundColor = Color.Aquamarine;
        private static readonly Color RoomColor = Color.Beige;
        private static readonly Color PassageColor = Color.Bisque;

        public static void DrawMap(IGridMap map, SpriteBatch spriteBatch, int scale)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            
            spriteBatch.DrawRectangle(map.Bounds.ToRectangle(scale), MapBackgroundColor);
            
            foreach (var room in map.FindFeatures(FeatureType.Room))
            {
                spriteBatch.FillRectangle(room.Shape.BoundingBox.ToRectangle(scale), RoomColor);
            }

            foreach (var passage in map.FindFeatures(FeatureType.Passage))
            {
                var polyPoint = (GridPolyPointFeature) passage;
                foreach (var coordinate in polyPoint.PolyPoint.Coordinates)
                {
                    spriteBatch.FillRectangle(new Rectangle(coordinate.X * scale, coordinate.Y * scale, scale, scale), PassageColor);
                }
            }
        }
    }
}
