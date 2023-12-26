using System.Windows;

namespace GameBacklog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void MainWindowStartUp(object sender, StartupEventArgs e)
        {
            var wnd = new MainWindow
            {
                Title = "Game backlog",
                Width = 500,
                Height = 350
            };
            wnd.Show();
        }
    }
}