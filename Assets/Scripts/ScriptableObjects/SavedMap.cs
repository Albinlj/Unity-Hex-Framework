using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MapData", menuName = "MapDataObj")]
    public class SavedMap : ScriptableObject
    {
        public Blueprint aMap;
        public int strut = 5;
    }
}