namespace Assets.Scripts.Controllers
{
    public class GameController : Singleton<GameController>
    {
        private void Start()
        {
            MapController.Instance.LoadBlueprint(BlueprintHandler.CreateRectangularBlueprint(8, 6));

            //Vertex.ClickedEvent += Moves.RotateVertexBorders;
            //Cell.ClickedEvent += Moves.RotateCellBorders;
        }
    }
}