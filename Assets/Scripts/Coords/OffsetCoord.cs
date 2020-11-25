using System;
using UnityEngine;

namespace Assets.Scripts.Coords
{
    public struct OffsetCoord
    {
        [field: SerializeField] public int X { get; set; }

        [field: SerializeField] public int Y { get; set; }

        public OffsetCoord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"Offset [{X}, {Y}]";

        public static implicit operator OffsetCoord(Vector2Int vti) => new OffsetCoord(vti.x, vti.y);

        public static implicit operator OffsetCoord(AxialCoord ac) => new OffsetCoord(ac.X, ac.Y + (int)Math.Floor((float)ac.X / 2));

        public static implicit operator AxialCoord(OffsetCoord oc) => new AxialCoord(oc.X, oc.Y - (int)Math.Floor((float)oc.X / 2));
    }
}