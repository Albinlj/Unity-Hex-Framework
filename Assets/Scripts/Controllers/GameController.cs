using UnityEngine;
using System.Collections;

public class GameController : Singleton<GameController> {


    void Start() {


        MapController.Instance.LoadBlueprint(BlueprintHandler.CreateRectangularBlueprint(4, 3));

        Vertex.ClickedEvent += Moves.RotateVertexBorders;
        Cell.ClickedEvent += Moves.RotateCellBorders;

    }



}
