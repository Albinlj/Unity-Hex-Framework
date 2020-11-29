using Assets.Scripts.Lists;
using Assets.Scripts.Pieces;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class MapController : Singleton<MapController>
    {
        private Transform cellHolder;
        private Transform borderHolder;
        private Transform vertexHolder;
        private Transform poolHolder;

        [SerializeField]
        private Blueprint loadBlueprint;

        [SerializeField]
        //private Blueprint saveBlueprint;

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
        }

        public void Reset()
        {
            var pieceList = PieceList.Ins;
            foreach (var cell in pieceList.Cells)
                Destroy(cell.Value);
            foreach (var border in pieceList.Borders)
                Destroy(border.Value);
            foreach (var vertex in pieceList.Vertexes)
                Destroy(vertex.Value);

            pieceList.Cells.Clear();
            pieceList.Borders.Clear();
            pieceList.Vertexes.Clear();
        }

        public void SaveBlueprint(string path = "Resources/Blueprints")
        {
            var blueprint = ScriptableObject.CreateInstance<Blueprint>();
            blueprint.cellInfoList = PieceList.Ins.Cells.Select(p => p.Value.Info).ToList();
            blueprint.borderInfoList = PieceList.Ins.Borders.Select(p => p.Value.Info).ToList();
            blueprint.vertexInfoList = PieceList.Ins.Vertexes.Select(p => p.Value.Info).ToList();
        }

        public void LoadBlueprint() => LoadBlueprint(loadBlueprint);

        public void LoadBlueprint(Blueprint blueprint)
        {
            foreach (CellInfo cellInfo in blueprint.cellInfoList)
                PieceInstantiator.Ins.Instantiate(cellInfo);
            foreach (BorderInfo borderInfo in blueprint.borderInfoList)
                PieceInstantiator.Ins.Instantiate(borderInfo);
            foreach (VertexInfo vertexInfo in blueprint.vertexInfoList)
                PieceInstantiator.Ins.Instantiate(vertexInfo);
        }

        public void InstantiateRectangularMap(int width, int height)
        {
            var blueprint = BlueprintCreation.CreateRectangularBlueprint(width, height);
            LoadBlueprint(blueprint);
        }
    }
}