using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

static class MapBuilder {


    public static void SaveMap(Map _mapToSave) {
        string stringToSave = JsonUtility.ToJson(_mapToSave);
        PlayerPrefs.SetString("savedMap", stringToSave);
    }

    public static void Testing() {





        Cell[] cellArray = new Cell[3];
        string[] stringCellArray = new string[3];
        for (int i = 0; i < 3; i++) {

            cellArray[i] = MapController.instance.cells[2, i + 2];
            stringCellArray[i] = JsonUtility.ToJson(cellArray[i]);
        }



        String[,] StringArray2d = new String[,] {{
             "kaos",
             "rejv",
             "ARGH"
        },{
            "boule",
            "slem",
            "ost"
        }};
        String[] stringArray = new String[] {
             "kaos",
             "rejv",
             "ARGH"

        };

        string jsoncellarray = JsonHelper2.ToJson(cellArray);

        Debug.Log(jsoncellarray);
        Debug.Log(stringCellArray[1]);

        Debug.Log(stringArray[0]);
        Debug.Log(stringArray);

        Debug.Log(stringArray);



        //string jsonarray2d = JsonHelper.ToJson(StringArray2d);

        //string jsonarray = JsonHelper2.ToJson(stringArray);

        //File.WriteAllText(
        //    "Assets/arraycell.txt",
        //    jsonarray
        //    );
        //Debug.Log(jsonarray);

        //Debug.Log(jsonarray2d);

        //Debug.Log(StringArray2d);




    }

    public static Map LoadMap() {
        string stringToLoad = PlayerPrefs.GetString("savedMap");
        return JsonUtility.FromJson<Map>(stringToLoad);
    }



}




