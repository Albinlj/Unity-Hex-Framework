using System;
using UnityEngine;
using static Assets.Scripts.Coords.Directions;

namespace Assets.Scripts.Coords
{
    [Serializable]
    public struct VertexCoord : IEquatable<VertexCoord>
    {
        [field: SerializeField] public AxialCoord Axial { get; private set; }
        [field: SerializeField] public int Index { get; private set; }

        public VertexCoord(Vector2Int axial, int index)
        {
            Axial = axial;
            Index = index;
        }

        public override string ToString() => $"Vertex [{Axial.X}, {Axial.Y}] I:{Index}";

        public VertexCoord[] Neighbors
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[]
                        {
                            new VertexCoord(Axial + new AxialCoord(2, -1), 1),
                            new VertexCoord(Axial + HexDirections[0], 1),
                            new VertexCoord(Axial + HexDirections[2], 0),
                        };

                    case 1:
                        return new[]
                        {
                            new VertexCoord(Axial + HexDirections[2], 0),
                            new VertexCoord(Axial + new AxialCoord(-2, 1), 0),
                            new VertexCoord(Axial + HexDirections[3], 0),
                        };

                    default:
                        throw new Exception();
                }
            }
        }

        public AxialCoord[] Hexes
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[] { Axial + HexDirections[0], Axial, Axial + HexDirections[5], };

                    case 1:
                        return new[] { Axial, Axial + HexDirections[2], Axial + HexDirections[3], };

                    default:
                        throw new Exception();
                }
            }
        }

        public BorderCoord[] Borders
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[]
                        {
                            new BorderCoord(Axial + HexDirections[5], 1), new BorderCoord(Axial, 0),
                            new BorderCoord(Axial + HexDirections[5], 2),
                        };

                    case 1:
                        return new[]
                        {
                            new BorderCoord(Axial, 2), new BorderCoord(Axial + HexDirections[3], 1),
                            new BorderCoord(Axial + HexDirections[3], 0),
                        };

                    default:
                        throw new Exception();
                }
            }
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Axial.X;

                    case 1:
                        return Axial.Y;

                    case 2:
                        return Index;

                    default:
                        throw new IndexOutOfRangeException($"Invalid VertexCoord index addressed: {(object)index}!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Axial = new Vector2Int(value, Axial.Y);
                        break;

                    case 1:
                        Axial = new Vector2Int(Axial.X, value);
                        break;

                    case 2:
                        Index = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException($"Invalid VertexCoord index addressed: {(object)index}!");
                }
            }
        }

        public bool Equals(VertexCoord other)
        {
            return Axial.Equals(other.Axial) && Index == other.Index;
        }

        public override bool Equals(object obj)
        {
            return obj is VertexCoord other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Axial.GetHashCode() * 397) ^ Index;
            }
        }
    }
}