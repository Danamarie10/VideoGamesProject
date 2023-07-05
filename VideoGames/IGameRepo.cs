using System.Net.Http.Headers;
using VideoGames.Models;

namespace VideoGames
{
    public interface IGameRepo
    {
        public IEnumerable<Games> GetAllGames();
        public Games GetGame(int id);

        public void UpdateGame(Games games);

        public void AddGame(Games gameToAdd);

        public void DeleteGame(Games game);
    }
}
