using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class Layout {
    public static float radius = 0.5f;

    public static bool isFlatTop = true;

    public Vector2 borderDirections { get; private set; }

    //public Vector2[] CubeVectors {
    //    get { return Hex.vertexDirections.Select(a => new Vector2()}
    //    private set { }
    //}


    static public float RadiusInner {
        get { return radius * (float)Math.Sqrt(3) / 2; }
        private set { }
    }
    static public float OffsetX {
        get {
            if (isFlatTop)
                return radius * 3 / 2;
            else
                return RadiusInner * 2;
        }
        private set { }
    }


    static public float OffsetY {
        get {
            if (!isFlatTop)
                return radius * 3 / 2;
            else
                return RadiusInner * 2;
        }
        private set { }
    }




    public static Vector2 CellOffsetToWorld(Vector2Int _offset) {
        float x, y;
        x = _offset.x * OffsetX;
        y = (_offset.y + ((float)Math.Abs(_offset.x) % 2) / 2) * OffsetY;
        return new Vector2(x, y);
    }

    public static Vector2 CubeToWorld(Vector3Int _cube) {
        float x, y;
        x = (_cube.x - _cube.y - _cube.z) * OffsetX / 2;
        y = _cube.y * RadiusInner - _cube.z * RadiusInner;
        return new Vector2(x, y);
    }


}