using Assets.Scripts.Coords;
using System;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Border : Piece
    {
        //Fields
        [SerializeField] private BorderInfo info;

        public BorderInfo Info
        {
            get => info;
            set => info = value;
        }

        //Event Actions
        public static event Action<Border> ClickedEvent;

        // Use this for initialization
        private void Start()
        {
            Coloring.RandomizeColor(gameObject);
        }

        private void OnMouseDown()
        {
            ClickedEvent(this);
        }

        public void Initialize(BorderInfo borderInfo)
        {
            ChangeCoord(borderInfo.Coord);
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            Vector2 position = info.Coord.Axial.ToWorldPosition() + Directions.HexDirections[info.Coord.Index].ToWorldPosition() / 2;
            Quaternion rotation = Quaternion.AngleAxis(60 - 60 * info.Coord.Index, Vector3.back);
            transform.SetPositionAndRotation(position, rotation);
        }

        private void ChangeCoord(BorderCoord newCoord)
        {
            info.Coord = newCoord;
            transform.name = newCoord.ToString();
            MapController.Instance.UpdateCoordInMap(this);
        }

        public bool RotateAround(Piece piece, bool clockwise)
        {
            if (piece is Vertex vertex)
            {
                var newCoord = Hex.GetBorderCoordRotatedAroundVertex(vertex.Info.Coord, Info.Coord, clockwise);
                ChangeCoord(newCoord);
                UpdatePosition();
                return true;
            }
            else if (piece is Cell cell)
            {
                var newCoord = Hex.GetBorderCoordRotatedAroundCell(cell.Coord, Info.Coord, clockwise);
                ChangeCoord(newCoord);
                UpdatePosition();
                return true;
            }
            return false;
        }
    }
}