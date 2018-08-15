using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Blueprint {
    public int width, height;
    public List<CellInfo> cellInfoList = new List<CellInfo>();
    public List<BorderInfo> borderInfoList = new List<BorderInfo>();
    public List<VertexInfo> vertexInfoList = new List<VertexInfo>();
}
