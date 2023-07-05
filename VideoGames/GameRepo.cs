using System.Data;
using Dapper;
using System.Collections.Generic;
using VideoGames.Models;
using System.Drawing;

namespace VideoGames
{
    public class GameRepo : IGameRepo
    {
        private readonly IDbConnection _connection;

        public GameRepo(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Games> GetAllGames()
        {
            return _connection.Query<Games>("SELECT * from Games;");
        }

        public Games GetGame(int id)
        {
            return _connection.QuerySingle<Games>("SELECT * FROM games WHERE ID = @id", new { id = id });
        }
        public void UpdateGame(Games games)
        {
            _connection.Execute("UPDATE products SET Title = @Title, Price = @price WHERE ID = @id",
             new { title = games.Title, price = games.Price, id = games.ID });
        }
        public void AddGame(Games gameToAdd)
        {
            _connection.Execute("Insert into games (title, genre, price, description, ImageURL) values (@title, @genre, @price, @description, @ImageURL)",
                new { title = gameToAdd.Title, genre = gameToAdd.Genre, price = gameToAdd.Price, description = gameToAdd.Description, ImageURL = gameToAdd.ImageURL });
        }
        public void DeleteGame(Games game)
        {
            _connection.Execute("DELETE FROM games WHERE ID = @id;", new { id = game.ID });

        }
    }
}
