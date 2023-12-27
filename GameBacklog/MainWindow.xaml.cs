using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using GameBacklog.controllers;
using GameBacklog.database;
using GameBacklog.models;

namespace GameBacklog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IGridClickController _gridClickController;
        private readonly GamesRepository _gameRepository;
        
        private ObservableCollection<Game> _todoGames = new ObservableCollection<Game>();
        private ObservableCollection<Game> _inProgressGames = new ObservableCollection<Game>();
        private ObservableCollection<Game> _doneGames = new ObservableCollection<Game>();
        
        public MainWindow()
        {
            InitializeComponent();
            _gridClickController = new GridClickPrinterController();
            _gameRepository = new GamesRepository();
            
            ReloadGamesLists();
        }
        
        private void MainGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            _gridClickController.HandleClick(new System.Collections.Generic.Dictionary<string, string>
            {
                { "x", e.GetPosition(pnlMainGrid).X.ToString(CultureInfo.InvariantCulture) },
                { "y", e.GetPosition(pnlMainGrid).Y.ToString(CultureInfo.InvariantCulture) }
            });
        }

        private void OpenAddGameWindow(object sender, RoutedEventArgs routedEventArgs)
        {
            System.Console.WriteLine("Add content button clicked");
            
            var addGameWindow = new AddGameWindow(this);
            addGameWindow.Show();
            
            ReloadGamesLists();
        }

        public void ReloadGamesLists()
        {
            System.Console.WriteLine("Reloading games lists");
            
            _todoGames = new ObservableCollection<Game>(_gameRepository.GetNotStartedGames());
            _inProgressGames = new ObservableCollection<Game>(_gameRepository.GetInProgressGames());
            _doneGames = new ObservableCollection<Game>(_gameRepository.GetDoneGames());
            
            TodoGames.ItemsSource = _todoGames;
            InProgressGames.ItemsSource = _inProgressGames;
            DoneGames.ItemsSource = _doneGames;
        }

        private void MoveToInProgressFromBacklog(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Move to in progress button clicked");
            
            var game = (Game) TodoGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.UpdateGameStatus(game.Name, "In Progress");
            ReloadGamesLists();
        }

        private void MoveToBacklog(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Move to backlog button clicked");
            
            var game = (Game) InProgressGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.UpdateGameStatus(game.Name, "Not Started");
            ReloadGamesLists();
        }

        private void MoveToDoneFromInProgress(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Move to done button clicked");
            
            var game = (Game) InProgressGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.UpdateGameStatus(game.Name, "Done");
            ReloadGamesLists();
        }

        private void DeleteDoneElement(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Delete element button clicked");
            
            var game = (Game) DoneGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.DeleteGame(((Game) DoneGames.SelectedItem).Name);
            ReloadGamesLists();
        }

        private void MoveToInProgessFromDone(object sender, RoutedEventArgs e)
        {  
            System.Console.WriteLine("Move to in progress button clicked");
            
            var game = (Game) DoneGames.SelectedItem;
            if (game == null) return;
            
            GamesRepository.UpdateGameStatus(game.Name, "In Progress");
            ReloadGamesLists();
        }
    }
}