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
        private List<PieceAction> OnMouseActions = new List<PieceAction>();

        private void OnMouseDown()
        {
            foreach (var action in OnMouseActions)
            {
                if (action != null)
                    action.Execute(this);
            }
        }

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