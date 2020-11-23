using Assets.Scripts.Actions.Cell;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    [Serializable]
    public abstract class Piece : MonoBehaviour
    {
        private List<PieceAction> Actions = new List<PieceAction>();

        //static public event Action<Piece> PieceClickedEvent;
        //static public event Action<Piece> PieceMovedEvent;
        public static event Action<Piece, bool> ClickedEvent;

        private void OnMouseDown() => ClickedEvent?.Invoke(this, true);

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public Color Color
        {
            get => Coloring.GetColor(gameObject);
            set => Coloring.ChangeColor(this.gameObject, value);
        }
    }
}