using Assets.Scripts.Actions.Cell;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pieces
{
    [Serializable]
    public abstract class Piece : MonoBehaviour
    {
        //static public event Action<Piece> PieceClickedEvent;
        //static public event Action<Piece> PieceMovedEvent;

        [SerializeField]
        private List<PieceAction> onMouseActions = new List<PieceAction>();

        internal void UpdateTransformName(object obj)
        {
            transform.name = obj.ToString();
        }

        private void OnMouseDown()
        {
            foreach (var action in onMouseActions)
            {
                if (action != null)
                    action.Execute(this);
            }
        }

        public Color Color
        {
            get => Coloring.GetColor(gameObject);
            set => Coloring.ChangeColor(this.gameObject, value);
        }
    }
}