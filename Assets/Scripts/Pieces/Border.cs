using Assets.Scripts.Coords;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Border : Piece
    {
        [SerializeField] public BorderInfo Info;

        //Event Actions

        // Use this for initialization
        private void Start()
        {
            Coloring.RandomizeColor(gameObject);
        }

        public BorderCoord Coord
        {
            get => Info.Coord;
            private set => Info.Coord = value;
        }

        private void OnMouseDown()
        {
        }

        public void Initialize(BorderInfo borderInfo)
        {
            UpdateTransformName(borderInfo);
            Info = borderInfo;
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            Vector2 position = Info.Coord;
            Quaternion rotation = (Quaternion)Info.Coord;
            transform.SetPositionAndRotation(position, rotation);
        }

        public bool RotateAround(Piece piece, bool clockwise)
        {
            if (piece is Vertex vertex)
            {
                var newCoord = Hex.GetBorderCoordRotatedAroundVertex(vertex.Info.Coord, Info.Coord, clockwise);
                Info.Coord = newCoord;
                UpdatePosition();
                return true;
            }
            else if (piece is Cell cell)
            {
                var newCoord = Hex.GetBorderCoordRotatedAroundCell(cell.Coord, Info.Coord, clockwise);
                Info.Coord = newCoord;
                UpdatePosition();
                return true;
            }
            return false;
        }
    }
}