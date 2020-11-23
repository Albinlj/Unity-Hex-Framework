using Assets.Scripts.Coords;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Cell : Piece
    {
        [SerializeField] private CellInfo info;

        public CellInfo Info
        {
            get => info;
            set => info = value;
        }

        private PolygonCollider2D polyCollider;

        //Properties

        public AxialCoord Coord
        {
            get => info.Coord;
            private set => info.Coord = value;
        }

        public IEnumerable<Border> Borders => MapController.Instance.GetBorders(info.Coord.Borders);

        private void Start()
        {
            Coloring.RandomizeColor(gameObject);
            polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        }

        public void Initialize(CellInfo cellInfo)
        {
            ChangeCoord(cellInfo);
            UpdatePosition(cellInfo);
        }

        private void UpdatePosition(CellInfo cellInfo) => transform.position = Layout.AxialToWorld(cellInfo.Coord);

        private void ChangeCoord(CellInfo cellInfo)
        {
            info = cellInfo;
            MapController.Instance.UpdateCoordInMap(this);
        }
    }
}