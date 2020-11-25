using Assets.Scripts.Pieces;
using UnityEngine;

namespace Assets.Scripts.Actions.Cell
{
    public abstract class PieceAction : ScriptableObject
    {
        public abstract void Execute(Piece piece);
    }
}