using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Vertex : Piece
    {
        public VertexInfo Info { get; set; }

        public IEnumerable<Border> Borders => MapController.Instance.GetBorders(Info.Coord.Borders.ToList());

        private void Start() => Coloring.RandomizeColor(this.gameObject);

        public void Initialize(VertexInfo newInfo)
        {
            ChangeCoord(newInfo);
            UpdatePosition();
        }

        private void UpdatePosition() => transform.position = Info.Coord.Axial.ToWorldPosition() + new Vector2(0.5f - Info.Coord.Index, 0);

        private void ChangeCoord(VertexInfo vertexInfo)
        {
            //var newCoord = vertexInfo.Coord;
            //Info.Coord = newCoord;
            Info = vertexInfo;
            transform.name = $"Vertex {Info}";
            MapController.Instance.UpdateCoordInMap(this);
        }
    }
}