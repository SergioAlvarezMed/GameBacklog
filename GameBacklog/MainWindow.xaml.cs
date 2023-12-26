using System.Globalization;
using System.Windows;
using System.Windows.Input;
using GameBacklog.controllers;

namespace GameBacklog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly GridClickController _controller;
        
        public MainWindow()
        {
            InitializeComponent();
            _controller = new GridClickPrinterController();
        }
        
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _controller.handle_click(new System.Collections.Generic.Dictionary<string, string>
            {
                { "x", e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture) },
                { "y", e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture) }
            });
            
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

    }
}