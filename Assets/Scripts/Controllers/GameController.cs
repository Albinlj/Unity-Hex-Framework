namespace Assets.Scripts.Controllers
{
    public class GameController : Singleton<GameController>
    {
        private void Start()
        {
            //MapController.Instance.LoadBlueprint(BlueprintCreation.CreateRectangularBlueprint(2, 2));
            var blueprint = BlueprintCreation.CreateRectangularBlueprint(4, 4);
            MapController.Instance.LoadBlueprint(blueprint);

            //Vertex.ClickedEvent += Moves.RotateVertexBorders;
            //Cell.ClickedEvent += Moves.RotateCellBorders;
        }
    }
}