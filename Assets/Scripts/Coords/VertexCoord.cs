using System;
using UnityEngine;

namespace Assets.Scripts.Coords
{
    [Serializable]
    public struct VertexCoord : IEquatable<VertexCoord>
    {
        [field: SerializeField] public AxialCoord Axial { get; private set; }
        [field: SerializeField] public int Index { get; private set; }

        public VertexCoord(AxialCoord axial, int index) : this(axial.X, axial.Y, index)
        {
        }

        public VertexCoord(int x, int y, int index)
        {
            var axialCoord = new AxialCoord(x, y);
            switch (index)
            {
                case 0:
                case 1:
                    Axial = axialCoord;
                    Index = index;
                    break;

                case 2:
                    Axial = axialCoord.Neighbors[2];
                    Index = 0;
                    break;

                case 3:
                    Axial = axialCoord.Neighbors[3];
                    Index = 1;
                    break;

                case 4:
                    Axial = axialCoord.Neighbors[3];
                    Index = 0;
                    break;

                case 5:
                    Axial = axialCoord.Neighbors[4];
                    Index = 1;
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public override string ToString() => $"Vertex [{Axial.X}, {Axial.Y}] I:{Index}";

        public static implicit operator Vector2(VertexCoord vc)
        {
            Vector2 offset;
            switch (vc.Index)
            {
                case 0:
                    offset = new Vector2(0.5f, 0);
                    break;

                case 1:
                    offset = new Vector2((float)Math.Cos(Math.PI / 3) / 2, AxialCoord.innerRadius / 2);
                    break;

                default:
                    throw new ArgumentException();
            }
            return (Vector2)vc.Axial + offset;
        }

        public VertexCoord[] Neighbors
        {
            get
            {
                switch (Index)
                {
                    case 0:
                        return new[]
                        {
                            new VertexCoord(Axial.Neighbors[5] , 1),
                            new VertexCoord(Axial, 1),
                            new VertexCoord(Axial.Neighbors[4] , 1),
                        };

                    case 1:
                        return new[]
                        {
                            new VertexCoord(Axial.Neighbors[1], 0),
                            new VertexCoord(Axial.Neighbors[2], 0),
                            new VertexCoord(Axial, 0),
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
                        return new[] { Axial.Neighbors[0], Axial, Axial.Neighbors[5] };

                    case 1:
                        return new[] { Axial.Neighbors[0], Axial.Neighbors[1], Axial };

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
                            new BorderCoord(Axial.Neighbors[5], 1),
                            new BorderCoord(Axial, 0),
                            new BorderCoord(Axial, 5),
                        };

                    case 1:
                        return new[]
                        {
                            new BorderCoord(Axial.Neighbors[0], 2 ),
                            new BorderCoord(Axial, 1),
                            new BorderCoord(Axial, 0),
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

        public bool Equals(VertexCoord other) => Axial == other.Axial && Index == other.Index;

        public override bool Equals(object obj) => obj is VertexCoord other && Equals(other);

        public static bool operator ==(VertexCoord vc1, VertexCoord vc2) => vc1.Axial == vc2.Axial && vc1.Index == vc2.Index;

        public static bool operator !=(VertexCoord vc1, VertexCoord vc2) => vc1.Axial != vc2.Axial || vc1.Index != vc2.Index;

        public override int GetHashCode()

        {
            unchecked { return (Axial.GetHashCode() * 397) ^ Index; }
        }
    }
}