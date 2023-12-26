namespace GameBacklog.controllers
{
    public class GridClickPrinterController : GridClickController
    {
        private readonly string _resourceText = "Clicked on: ";

        public void handle_click(Dictionary<string, string> args)
        {
            System.Console.WriteLine(
                _resourceText + args["x"] + ", " + args["y"]
            );
        }
    }
}