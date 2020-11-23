using System;
using UnityEngine;
using static Assets.Scripts.Coords.Directions;

namespace Assets.Scripts.Coords
{
    [Serializable]
    public struct BorderCoord : IEquatable<BorderCoord>
    {
        [field: SerializeField]
        public AxialCoord Axial { get; private set; }

        [field: SerializeField]
        public int Index { get; private set; }

        public BorderCoord(AxialCoord axial, int index)
        {
            Axial = axial;
            Index = index;
        }

        public BorderCoord[] Neighbors
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[]
                        {
                            new BorderCoord(Axial + HexDirections[5], 1),
                            new BorderCoord(Axial + HexDirections[0], 2), new BorderCoord(Axial, 1),
                            new BorderCoord(Axial + HexDirections[5], 2),
                        };

                    case 1:
                        return new[]
                        {
                            new BorderCoord(Axial, 0), new BorderCoord(Axial + HexDirections[0], 2),
                            new BorderCoord(Axial + HexDirections[2], 0), new BorderCoord(Axial, 2),
                        };

                    case 2:
                        return new[]
                        {
                            new BorderCoord(Axial, 1), new BorderCoord(Axial + HexDirections[2], 0),
                            new BorderCoord(Axial + HexDirections[3], 1),
                            new BorderCoord(Axial + HexDirections[3], 0),
                        };

                    default:
                        throw new Exception();
                }
            }
        }

        public override string ToString() => $"Border [{Axial.X}, {Axial.Y}] I:{Index}";

        public AxialCoord[] Hexes
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[] { Axial, Axial + HexDirections[0], };

                    case 1:
                        return new[] { Axial, Axial + HexDirections[1], };

                    case 2:
                        return new[] { Axial, Axial + HexDirections[2], };

                    default:
                        throw new Exception();
                }
            }
        }

        public VertexCoord[] Vertexes
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[] { new VertexCoord(Axial, 0), new VertexCoord(Axial + HexDirections[0], 1), };

                    case 1:
                        return new[]
                        {
                            new VertexCoord(Axial + HexDirections[0], 1),
                            new VertexCoord(Axial + HexDirections[2], 0),
                        };

                    case 2:
                        return new[] { new VertexCoord(Axial + HexDirections[2], 0), new VertexCoord(Axial, 1), };

                    default:
                        throw new Exception();
                }
            }
        }

        public static bool operator ==(BorderCoord b1, BorderCoord b2)
        {
            return b1.Equals(b2);
        }

        public static bool operator !=(BorderCoord b1, BorderCoord b2)
        {
            return !b1.Equals(b2);
        }

        public bool Equals(BorderCoord other)
        {
            return Axial.Equals(other.Axial) && Index == other.Index;
        }

        public override bool Equals(object obj)

        {
            return obj is BorderCoord other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Axial.GetHashCode() * 397) ^ Index;
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
    }
}