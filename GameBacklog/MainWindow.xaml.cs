using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using GameBacklog.controllers;
using GameBacklog.database;

namespace GameBacklog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly GridClickController _controller;
        private readonly GamesRepository _game_repository;
        
        private ObservableCollection<Game> _todoGames = new ObservableCollection<Game>();
        private ObservableCollection<Game> _inProgressGames = new ObservableCollection<Game>();
        private ObservableCollection<Game> _doneGames = new ObservableCollection<Game>();
        
        public MainWindow()
        {
            InitializeComponent();
            _controller = new GridClickPrinterController();
            _game_repository = new GamesRepository();
            
            ReloadGamesLists();
        }
        
        private void MainGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            _controller.handle_click(new System.Collections.Generic.Dictionary<string, string>
            {
                { "x", e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture) },
                { "y", e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture) }
            });
        }

        private void OpenAddGameWindow(object sender, RoutedEventArgs routedEventArgs)
        {
            System.Console.WriteLine("Add content button clicked");
            
            var addGameWindow = new AddGameWindow();
            addGameWindow.Show();
            
            ReloadGamesLists();
        }
        
        private void ReloadGamesLists()
        {
            System.Console.WriteLine("Reloading games lists");
            
            _todoGames = new ObservableCollection<Game>(_game_repository.get_not_started_games());
            _inProgressGames = new ObservableCollection<Game>(_game_repository.get_in_progress_games());
            _doneGames = new ObservableCollection<Game>(_game_repository.get_done_games());
            
            TodoGames.ItemsSource = _todoGames;
            InProgressGames.ItemsSource = _inProgressGames;
            DoneGames.ItemsSource = _doneGames;
        }

        private void MoveToInProgress(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Move to in progress button clicked");
            
            var game = (Game) TodoGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.update_game_status(game.Name, "In Progress");
            ReloadGamesLists();
        }
    }
}