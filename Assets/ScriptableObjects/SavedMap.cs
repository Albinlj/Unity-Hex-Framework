using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "MapDataObj")]
public class SavedMap : ScriptableObject {
    public Blueprint aMap;
    public int strut = 5;

}
