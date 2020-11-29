using Assets.Scripts.Pieces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    [CreateAssetMenu(fileName = "Blueprint", menuName = "Blueprint")]
    public class Blueprint : ScriptableObject
    {
        public List<CellInfo> cellInfoList = new List<CellInfo>();
        public List<BorderInfo> borderInfoList = new List<BorderInfo>();
        public List<VertexInfo> vertexInfoList = new List<VertexInfo>();
    }
}