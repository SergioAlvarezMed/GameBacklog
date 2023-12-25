using System.Collections.Generic;
using WpfApplication1.Properties;

namespace WpfApplication1
{
    public class GridClickPrinterController : GridClickController
    {
        private readonly string _resourceText = Resources.GridClickPrinterController_sample_message;

        public void handle_click(Dictionary<string, string> args)
        {
            System.Console.WriteLine(
                _resourceText + args["x"] + ", " + args["y"]
            );
        }
    }
}