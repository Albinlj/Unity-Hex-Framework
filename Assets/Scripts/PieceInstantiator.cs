using Assets.Scripts.Lists;
using Assets.Scripts.Pieces;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class PieceInstantiator : ScriptableObject
    {
        private static PieceInstantiator _inst;

        public static PieceInstantiator Ins
        {
            get
            {
                if (_inst == null)
                    _inst = Resources.FindObjectsOfTypeAll<PieceInstantiator>().FirstOrDefault();
                if (_inst == null)
                    _inst = CreateInstance<PieceInstantiator>();
                return _inst;
            }
        }

        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private Border _borderPrefab;
        [SerializeField] private Vertex _vertexPrefab;

        [SerializeField] private PieceList _pieceList;

        public void OnEnable()
        {
            _cellPrefab = Resources.Load<Cell>("Cell");
            _borderPrefab = Resources.Load<Border>("Border");
            _vertexPrefab = Resources.Load<Vertex>("Vertex");
        }

        public Cell Instantiate(CellInfo info)
        {
            var obj = Instantiate(_cellPrefab);
            var cell = obj.GetComponent<Cell>();
            _pieceList.Cells.Add(info.Coord, cell);

            cell.Initialize(info);
            return obj;
        }

        //public Piece Instantiate<T>(PieceInfo info)
        //{
        //    var obj = Instantiate(_cellPrefab);
        //    var cell = obj.GetComponent<Cell>();
        //    _pieceList.Cells.Add(info.Coord, cell);

        //    cell.Initialize(info);
        //    return obj;
        //}

        public Border Instantiate(BorderInfo info)
        {
            var obj = Instantiate(_borderPrefab);
            var border = obj.GetComponent<Border>();
            _pieceList.Borders.Add(info.Coord, border);
            border.Initialize(info);
            return obj;
        }

        public Vertex Instantiate(VertexInfo info)
        {
            var obj = Instantiate(_vertexPrefab);
            var vertex = obj.GetComponent<Vertex>();
            _pieceList.Vertexes.Add(info.Coord, vertex);
            vertex.Initialize(info);
            return obj;
        }
    }
}