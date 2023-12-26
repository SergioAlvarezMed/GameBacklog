namespace GameBacklog.controllers
{
    public class GridClickPrinterController : IGridClickController
    {
        private readonly string _resourceText = "Clicked on: ";

        public void HandleClick(Dictionary<string, string> args)
        {
            System.Console.WriteLine(
                _resourceText + args["x"] + ", " + args["y"]
            );
        }
    }
}