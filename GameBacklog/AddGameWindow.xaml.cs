using System.Windows;
using GameBacklog.database;

namespace GameBacklog;

public partial class AddGameWindow : Window
{
    private readonly GamesRepository _gameRepository;
    
    public AddGameWindow()
    {
        InitializeComponent();
        _gameRepository = new GamesRepository();
        
    }

    private void AddGameButton_Click(object sender, RoutedEventArgs e)
    {
        System.Console.WriteLine("Add game button clicked");
        _gameRepository.AddGame(GameNameTextBox.Text, "Not Started");
        Close();
    }
}