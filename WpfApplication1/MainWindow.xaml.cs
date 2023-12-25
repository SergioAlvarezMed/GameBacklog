using System.Globalization;
using System.Windows.Input;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private GridClickController _controller;
        
        public MainWindow()
        {
            InitializeComponent();
            
            _controller = new GridClickPrinterController();
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _controller.handle_click(new System.Collections.Generic.Dictionary<string, string>
            {
                {"x", e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture)},
                {"y", e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture)}
            });
            
             System.Console.WriteLine(
                 e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture),
                e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture)
             );
        }
    }
}