﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using GridMath.Algorithms;

#endregion

namespace GridMath.Shapes
{
    public class GridCircle : IGridShape
    {
        public GridCircle(int cx, int cy, int radius) : this(new GridCoordinatePair(cx, cy), radius)
        {
            
        }
        
        public GridCircle(GridCoordinatePair center, int radius)
        {
            if (radius < 1) throw new ArgumentOutOfRangeException(nameof(radius), radius, null);

            _center = center;
            _radius = radius;
        }

        private GridCoordinatePair _center;
        private int _radius;

        public IEnumerable<GridCoordinatePair> Interior
        {
            get
            {
                var edges = Edge.ToArray();
                var fill = FloodFill.GetFloodFillCoordinates(_center, edges, BoundingBox);
                var interior = new List<GridCoordinatePair>(edges);
                interior.AddRange(fill);
                return interior;
            }
        }

        public IEnumerable<GridCoordinatePair> Edge => Bresenham.PlotCircle(_center.X, _center.Y, _radius);

        public GridBoundingBox BoundingBox =>
            GridBoundingBox.FromMinMax(
                _center.X - _radius, _center.Y - _radius, _center.X + _radius,
                _center.Y + _radius);

        public GridCoordinatePair Center
        {
            get => _center;
            set => _center = value;
        }

        public int Radius
        {
            get => _radius;
            set
            {
                if (value < 1) return;
                _radius = value;
            }
        }


        public bool Contains(GridCoordinatePair position)
        {
            return BoundingBox.Contains(position) && Interior.Contains(position);
        }

        public bool Contains(int x, int y)
        {
            return Contains(new GridCoordinatePair(x, y));
        }

        public bool Overlaps(GridBoundingBox boundingBox)
        {
            return Contains(boundingBox.NearestPoint(_center.X, _center.Y));
        }

        public void Translate(int x, int y)
        {
            _center = _center.Translation(x, y);
        }

        public void Rotate(GridRotation rotation)
        {
            // Done
        }

        public void Flip(GridAxis axis)
        {
            // Done
        }
    }
}