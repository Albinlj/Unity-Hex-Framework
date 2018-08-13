using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

static class MapBuilder {



    public static void Testing() {




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

    public static SaveInfo SaveMap(Map _map) {
        SaveInfo saveInfo = new SaveInfo();
        foreach (Cell cell in _map.cells) {
            saveInfo.pieceInfoList.Add(cell.GetInfo());
        }
        foreach (Border[] borders in _map.borders) {
            saveInfo.pieceInfoList.Add(borders[0].GetInfo());
            saveInfo.pieceInfoList.Add(borders[1].GetInfo());
            saveInfo.pieceInfoList.Add(borders[2].GetInfo());
        }
        foreach (Vertex[] vertices in _map.vertices) {
            saveInfo.pieceInfoList.Add(vertices[0].GetInfo());
            saveInfo.pieceInfoList.Add(vertices[1].GetInfo());
        }
        return saveInfo;
    }



}




