using System;
using UnityEngine;
using static Assets.Scripts.Coords.Directions;

namespace Assets.Scripts.Coords
{
    [System.Serializable]
    public struct AxialCoord : IEquatable<AxialCoord>
    {
        [field: SerializeField] public int X { get; set; }

        [field: SerializeField] public int Y { get; set; }

        public int Z
        {
            get => -X - Y;
            set
            {
                X = -Y - value;
                Y = -X - value;
            }
        }

        public AxialCoord(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region operators

        public override string ToString() => $"Axial [{X}, {Y}]";

        public static implicit operator Vector2Int(AxialCoord hc) => new Vector2Int(hc.X, hc.Y);

        public static implicit operator AxialCoord(Vector2Int vti) => new AxialCoord(vti.x, vti.y);

        public static implicit operator Vector3Int(AxialCoord hc) => new Vector3Int(hc.X, hc.Y, -hc.X - hc.Y);

        public static implicit operator AxialCoord(Vector3Int vti) => new AxialCoord(vti.x, vti.y);

        public static AxialCoord operator +(AxialCoord hc1, AxialCoord hc2)
        {
            return new AxialCoord(hc1.X + hc2.X, hc1.Y + hc2.Y);
        }

        public static AxialCoord operator -(AxialCoord hc1, AxialCoord hc2)
        {
            return new AxialCoord(hc1.X - hc2.X, hc1.Y - hc2.Y);
        }

        public static bool operator ==(AxialCoord hc1, AxialCoord hc2)
        {
            return hc1.X == hc2.X && hc1.Y == hc2.Y;
        }

        public static bool operator !=(AxialCoord hc1, AxialCoord hc2)
        {
            return hc1.X != hc2.X || hc1.Y == hc2.Y;
        }

        #endregion operators

        public AxialCoord[] Neighbors =>
            new[]
            {
                this + HexDirections[0],
                this + HexDirections[1],
                this + HexDirections[2],
                this + HexDirections[3],
                this + HexDirections[4],
                this + HexDirections[5],
            };

        public BorderCoord[] Borders => new[]
            {
                new BorderCoord(this, 0),
                new BorderCoord(this, 1),
                new BorderCoord(this, 2),
                new BorderCoord(this + HexDirections[3], 0),
                new BorderCoord(this + HexDirections[4], 1),
                new BorderCoord(this + HexDirections[5], 2)
            };

        public VertexCoord[] Vertexes =>
            new[]
            {
                new VertexCoord(this, 0),
                new VertexCoord(this + HexDirections[0], 1),
                new VertexCoord(this + HexDirections[2], 0),
                new VertexCoord(this, 0),
                new VertexCoord(this + HexDirections[3], 0),
                new VertexCoord(this + HexDirections[5], 1),
            };

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;

                    case 1:
                        return Y;

                    case 2:
                        return -X - Y;

                    default:
                        throw new IndexOutOfRangeException($"Invalid HexCoord index addressed: {(object)index}!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;

                    case 1:
                        Y = value;
                        break;

                    case 2:
                        Z = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException($"Invalid HexCoord index addressed: {(object)index}!");
                }
            }
        }

        public bool Equals(AxialCoord other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is AxialCoord other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}