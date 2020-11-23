using Assets.Scripts.Coords;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Layout
    {
        public static float radius = 0.5f;

        public static bool isFlatTop = true;

        public Vector2 BorderDirections { get; private set; }

        //public Vector2[] CubeVectors {
        //    get { return Hex.vertexDirections.Select(a => new Vector2()}
        //    private set { }
        //}

        public static float RadiusInner
        {
            get => radius * (float)Math.Sqrt(3) / 2;
            private set { }
        }

        public static float OffsetX
        {
            get
            {
                if (isFlatTop)
                    return radius * 3 / 2;
                else
                    return RadiusInner * 2;
            }
            private set { }
        }

        public static float OffsetY
        {
            get
            {
                if (!isFlatTop)
                    return radius * 3 / 2;
                else
                    return RadiusInner * 2;
            }
            private set { }
        }

        public static Vector2 CellOffsetToWorld(Vector2Int offset)
        {
            float x, y;
            x = offset.x * OffsetX;
            y = (offset.y + ((float)Math.Abs(offset.x) % 2) / 2) * OffsetY;
            return new Vector2(x, y);
        }

        public static Vector2 AxialToWorld(AxialCoord axial)
        {
            float x, y;
            x = (axial.X - axial.Y - axial.Z) * OffsetX / 2;
            y = axial.Y * RadiusInner - axial.Z * RadiusInner;
            return new Vector2(x, y);
        }
    }
}