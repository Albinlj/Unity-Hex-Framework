using Assets.Scripts.Coords;
using Assets.Scripts.Lists;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    public class Cell : Piece
    {
        [SerializeField]
        public CellInfo Info { get; set; }

        private PolygonCollider2D polyCollider;

        //Properties

        public AxialCoord Coord
        {
            get => Info.Coord;
            private set => Info.Coord = value;
        }

        private void Start()
        {
            Coloring.RandomizeColor(gameObject);
            polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        }

        public void OnEnable()
        {
            //MonoDictionary<AxialCoord, Cell>.Ins.Items.Add(Info.Coord, this);
            //UpdatePosition(Info);
        }

        public void Initialize(CellInfo info)
        {
            Info = info;
            PieceList.Ins.Cells.Add(Info.Coord, this);
            UpdatePosition(Info);
            UpdateTransformName(info);
        }

        public IEnumerable<Border> Borders => PieceList.Ins.Borders.TryGetMany(Info.Coord.Borders);

        private void UpdatePosition(CellInfo cellInfo) => transform.position = (Vector2)cellInfo.Coord;

        private void ChangeCoord(CellInfo cellInfo)
        {
            Info = cellInfo;
        }
    }
}