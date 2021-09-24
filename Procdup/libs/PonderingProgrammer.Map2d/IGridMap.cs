using System;
using System.Collections.Generic;
using PonderingProgrammer.GridMath;
using PonderingProgrammer.Map2d.FeatureObjects;

namespace PonderingProgrammer.Map2d
{
    /// <summary>
    /// A IGridMap is a model of an area based on a 2-dimensional grid coordinate system.
    /// It is presentation agnostic.
    /// The area is bounded by a rectangular box.
    /// The map is composed of features organized in layers.
    /// The map is divided into fields, one field per one location in grid coordinate system, within bounds.
    /// An IGridMap object is represented as a graph of fields connected by their adjacency.
    /// Sub-graphs can be composed based on features being present on fields. For example navigation graph.   
    /// </summary>
    public interface IGridMap
    {
        GridBoundingBox Bounds { get; }
        
        GridMapField[] Fields { get; }
        
        /// <returns>Returns index of field at given coordinates or -1 if not found</returns>
        int GetFieldIndex(int x, int y);
        
        /// <returns>Returns index of given field or -1 if not found</returns>
        int GetFieldIndex(GridMapField field);
        
        Dictionary<int, List<IGridFeatureObject>> FeatureLayers { get; }

        void AddFeature(IGridFeatureObject feature, int layer = 0);

        GridMapField GetFieldAt(int x, int y);
        GridMapField GetFieldAt(GridCoordinatePair coordinates);
        ICollection<GridMapField> GetFieldsInBoundary(GridBoundingBox boundary);
        ICollection<IGridFeatureObject> GetFeaturesInBoundary(GridBoundingBox boundary);
        
        public List<IGridFeatureObject> FindFeatures(FeatureType featureType);
        IEnumerable<GridMapField> FindFields(Func<GridMapField, bool> predicate);
        
        IEnumerable<GridMapField> FindAdjacentFields(int x, int y, bool includeDiagonallyAdjacent = false);
        IEnumerable<GridMapField> FindAdjacentFields(GridCoordinatePair coordinates, bool includeDiagonallyAdjacent = false);

        GridMapAdjacencyList GetGraph(bool allowDiagonalAdjacency);
        GridMapAdjacencyList GetFeatureGraph(bool allowDiagonalAdjacency, FeatureType featureType);
    }
}
