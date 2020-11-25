using Assets.Scripts.Coords;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Layout
    {
        public static float radius = 0.5f;

        public static bool isFlatTop = true;

        public static float RadiusInner => radius * (float)Math.Sqrt(3) / 2;

        public static float OffsetX => isFlatTop ? radius * 3 / 2 : RadiusInner * 2;

        public static float OffsetY => !isFlatTop ? radius * 3 / 2 : RadiusInner * 2;

        public static Vector2 ToWorldPosition(this AxialCoord axial) => new Vector2(
            (axial.X - axial.Y - axial.Z) * OffsetX / 2,
            axial.Y * RadiusInner - axial.Z * RadiusInner);

        public static Vector2 ToWorldPosition(this BorderCoord border) => border.Axial.ToWorldPosition() + new Vector2(0.5f - border.Index, 0);
    }
}