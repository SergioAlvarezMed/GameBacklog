using GameBacklog.models;
using Microsoft.Data.Sqlite;
namespace GameBacklog.database
{
    public class GamesRepository
    {
        private static void CreateTableIfNotExists()
        {
            var connection = new SqliteConnection("Data Source=database.db");
            
            // Create a new table called games if it doesn't exist
            connection.Open();
            var createTableCommand = connection.CreateCommand();
            createTableCommand.CommandText = "CREATE TABLE IF NOT EXISTS games (name VARCHAR(255), status VARCHAR(255))";
            createTableCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void AddGame(string name, string status)
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            // Insert a new game
            connection.Open();
            var insertGameCommand = connection.CreateCommand();
            insertGameCommand.CommandText = "INSERT INTO games (name, status) VALUES ($name, $status)";
            insertGameCommand.Parameters.AddWithValue("$name", name);
            insertGameCommand.Parameters.AddWithValue("$status", status);
            insertGameCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        public List<Game> GetNotStartedGames()
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            connection.Open();
            var selectGamesCommand = connection.CreateCommand();
            selectGamesCommand.CommandText = "SELECT * FROM games WHERE status = 'Not Started'";
            var reader = selectGamesCommand.ExecuteReader();
            var games = new List<Game>();
            
            while (reader.Read())
            {
                games.Add(new Game(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            
            return games;
        }

        public List<Game> GetInProgressGames()
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            connection.Open();
            var selectGamesCommand = connection.CreateCommand();
            selectGamesCommand.CommandText = "SELECT * FROM games WHERE status = 'In Progress'";
            var reader = selectGamesCommand.ExecuteReader();
            var games = new List<Game>();
            
            while (reader.Read())
            {
                games.Add(new Game(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            
            return games;
        }

        public List<Game> GetDoneGames()
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            connection.Open();
            var selectGamesCommand = connection.CreateCommand();
            selectGamesCommand.CommandText = "SELECT * FROM games WHERE status = 'Done'";
            var reader = selectGamesCommand.ExecuteReader();
            var games = new List<Game>();
            
            while (reader.Read())
            {
                games.Add(new Game(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            
            return games;
        }

        public static void UpdateGameStatus(string gameName, string status)
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            connection.Open();
            var updateGameCommand = connection.CreateCommand();
            updateGameCommand.CommandText = "UPDATE games SET status = $status WHERE name = $name";
            updateGameCommand.Parameters.AddWithValue("$name", gameName);
            updateGameCommand.Parameters.AddWithValue("$status", status);
            updateGameCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteGame(string name)
        {
            CreateTableIfNotExists();
            
            var connection = new SqliteConnection("Data Source=database.db");
            
            connection.Open();
            var deleteGameCommand = connection.CreateCommand();
            deleteGameCommand.CommandText = "DELETE FROM games WHERE name = $name";
            deleteGameCommand.Parameters.AddWithValue("$name", name);
            deleteGameCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
    
    
}