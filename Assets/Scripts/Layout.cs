using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Layout {
    public static float radius = 1;

    public static bool isFlatTop = true;

    static public float OffsetX {
        get {
            if (isFlatTop)
                return radius * 3 / 4;
            else
                return radius * (float)Math.Sqrt(3) / 2;
        }
        private set { }
    }

    static public float OffsetY {
        get {
            if (!isFlatTop)
                return radius * 3 / 4;
            else
                return radius * (float)Math.Sqrt(3) / 2;
        }
        private set { }
    }




    public static Vector2 offsetToWorld(Vector2Int offsetCoord) {
        float x, y;
        x = offsetCoord.x * OffsetX;
        y = (offsetCoord.y + ((float)offsetCoord.x % 2) / 2) * OffsetY;
        return new Vector2(x, y);
    }

    public static Vector2 axialToWorld(Vector2Int axialCoord) {
        float x, y;
        y = radius * (float)(axialCoord.x * Math.Sqrt(3) / 2 + Math.Sqrt(3));
        x = radius * (axialCoord.x * 3 / 2);
        return new Vector2(x, y);
    }

}