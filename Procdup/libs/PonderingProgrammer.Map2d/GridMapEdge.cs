using System;

namespace PonderingProgrammer.Map2d
{
    public class GridMapEdge
    {
        public GridMapField F1 { get; }
        public GridMapField F2 { get; }
        public bool Directional { get; }
        public double Weight { get; set; }

        public GridMapEdge(GridMapField c1, GridMapField c2)
        {
            if (c1 == c2) throw new ArgumentException("Edges pointing to the same field are illegal in this graph");
            F1 = c1 ?? throw new ArgumentNullException(nameof(c1));
            F2 = c2 ?? throw new ArgumentNullException(nameof(c2));
        }

        public GridMapEdge(GridMapField c1, GridMapField c2, bool directional) : this(c1, c2)
        {
            Directional = directional;
        }

        public GridMapEdge(GridMapField c1, GridMapField c2, bool directional, double weight) : this(c1, c2, directional)
        {
            Weight = weight;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is GridMapEdge edge))
            {
                return false;
            }

            if (Directional != edge.Directional) return false;
            var sameSame = F1.Equals(edge.F1) && F2.Equals(edge.F2);
            var sameReverse = F1.Equals(edge.F2) && F2.Equals(edge.F1);
            if (Directional)
            {
                return sameSame;
            }
            return sameSame || sameReverse;
        }

        public override int GetHashCode()
        {
            return Directional ? HashCode.Combine(F1, F2) : F1.GetHashCode() + F2.GetHashCode();
        }
    }
}
