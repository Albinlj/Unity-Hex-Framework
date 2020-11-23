using Assets.Scripts.Controllers;
using Assets.Scripts.Coords;
using Assets.Scripts.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class MapController : Singleton<MapController>
    {
        public GameObject cellPrefab;
        public GameObject borderPrefab;
        public GameObject vertexPrefab;
        private Transform cellHolder;
        private Transform borderHolder;
        private Transform vertexHolder;
        private Transform poolHolder;
        private Validator validator;
        private Pool<Cell> cellPool;
        private Pool<Border> borderPool;
        private Pool<Vertex> vertexPool;

        [SerializeField] private Blueprint bluePrint;

        public Map map;

        // Use this for initialization

        private void Start()
        {
            cellHolder = new GameObject("CellHolder").transform;
            cellHolder.SetParent(this.transform);
            borderHolder = new GameObject("BorderHolder").transform;
            borderHolder.SetParent(this.transform);
            vertexHolder = new GameObject("vertexHolder").transform;
            vertexHolder.SetParent(this.transform);
            poolHolder = new GameObject("poolHolder").transform;
            poolHolder.SetParent(this.transform);

            cellPool = new Pool<Cell>(cellPrefab, poolHolder, cellHolder);
            borderPool = new Pool<Border>(borderPrefab, poolHolder, borderHolder);
            vertexPool = new Pool<Vertex>(vertexPrefab, poolHolder, vertexHolder);
        }

        public void LoadBlueprint(Blueprint blueprint)
        {
            cellPool.ReleaseAll();
            borderPool.ReleaseAll();
            vertexPool.ReleaseAll();

            map = new Map(blueprint.width, blueprint.height);
            int cellCount = blueprint.width * blueprint.height;
            cellPool.Populate((blueprint.width - 2) * (blueprint.height - 2));
            borderPool.Populate(cellCount * 3);
            vertexPool.Populate((blueprint.width) * (blueprint.height - 2) * 2);

            foreach (CellInfo cellInfo in blueprint.cellInfoList)
            {
                cellPool.Get().Initialize(cellInfo);
            }
            foreach (BorderInfo borderInfo in blueprint.borderInfoList)
            {
                borderPool.Get().Initialize(borderInfo);
            }
            foreach (VertexInfo vertexInfo in blueprint.vertexInfoList)
            {
                vertexPool.Get().Initialize(vertexInfo);
            }
            CameraController.Instance.UpdateCamera(blueprint.width - 2, blueprint.height - 2);
        }

        public void SaveBlueprint()
        {
            bluePrint.cellInfoList = cellPool.usedList.Select(c => c.Info).ToList();
            bluePrint.borderInfoList = borderPool.usedList.Select(b => b.Info).ToList();
            bluePrint.vertexInfoList = vertexPool.usedList.Select(v => v.Info).ToList();

            EditorUtility.SetDirty(bluePrint);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private Cell GetCell(OffsetCoord offset)
        {
            return validator.IsValidCoord(offset)
                ? map.cells[offset.X, offset.Y]
                : null;
        }

        public List<Cell> GetCells(List<OffsetCoord> list) => list.Select(GetCell).ToList();

        public Border GetBorder(BorderCoord borderCoord)
        {
            return map.borders[
                ((OffsetCoord)borderCoord.Axial).X,
                ((OffsetCoord)borderCoord.Axial).Y
            ][
                borderCoord.Index
            ];
        }

        public List<Border> GetBorders(IEnumerable<BorderCoord> borderCoordList) => borderCoordList.Select(GetBorder).ToList();

        public void UpdateCoordInMap(Cell cell)
        {
            OffsetCoord offsetCoord = cell.Coord;
            map.cells[offsetCoord.X, offsetCoord.Y] = cell;
        }

        public void UpdateCoordInMap(Border border)
        {
            OffsetCoord offsetCoord = border.Info.Coord.Axial;
            map.borders[offsetCoord.X, offsetCoord.Y][border.Info.Coord.Index] = border;
        }

        public void UpdateCoordInMap(Vertex vertex)
        {
            OffsetCoord offsetCoord = vertex.Info.Coord.Axial;
            map.vertices[offsetCoord.X, offsetCoord.Y][vertex.Info.Coord.Index] = vertex;
        }
    }
}