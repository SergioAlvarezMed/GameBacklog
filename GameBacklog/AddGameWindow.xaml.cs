using System.Windows;
using GameBacklog.database;

namespace GameBacklog;

public partial class AddGameWindow : Window
{
    private readonly GamesRepository _gameRepository;
    private readonly MainWindow _mainWindow;
    
    public AddGameWindow(MainWindow mainWindow)
    {
        InitializeComponent();
        _gameRepository = new GamesRepository();
        _mainWindow = mainWindow;
    }

    private void AddGameButton_Click(object sender, RoutedEventArgs e)
    {
        System.Console.WriteLine("Add game button clicked");
        _gameRepository.AddGame(GameNameTextBox.Text, "Not Started");
        _mainWindow.ReloadGamesLists();
        Close();
    }
}