using Assets.Scripts.Coords;
using Assets.Scripts.Lists;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Vertex : Piece
    {
        public VertexInfo Info { get; set; }

        public IEnumerable<Border> Borders => PieceList.Ins.Borders.TryGetMany(Info.Coord.Borders);

        private void Start() => Coloring.RandomizeColor(this.gameObject);

        public VertexCoord Coord
        {
            get => Info.Coord;
            private set => Info.Coord = value;
        }

        public void Initialize(VertexInfo newInfo)
        {
            Info = newInfo;
            UpdatePosition();
            UpdateTransformName(newInfo);
        }

        private void UpdatePosition() => transform.position = (Vector2)Info.Coord;

        private void ChangeCoord(VertexInfo vertexInfo)
        {
            ////var newCoord = vertexInfo.Coord;
            ////Info.Coord = newCoord;
            //Info = vertexInfo;
            //transform.name = $"Vertex {Info}";
            //MapController.Instance.UpdateCoordInMap(this);
        }
    }
}