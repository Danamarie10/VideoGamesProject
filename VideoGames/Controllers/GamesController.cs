using Microsoft.AspNetCore.Mvc;
using VideoGames.Models;

namespace VideoGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepo _repo;

        public GamesController(IGameRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var games = _repo.GetAllGames();
            return View(games);
        }
        public IActionResult ViewGame(int id)
        {
            var game = _repo.GetGame(id);
            return View(game);
        }
        public IActionResult UpdateGame(int id)
        {
            Games game = _repo.GetGame(id);
            if (game == null)
            {
                return View("ProductNotFound");

            }
            return View(game);
        }
        public IActionResult UpdateGameToDatabase(Games game)
        {
            _repo.UpdateGame(game);

            return RedirectToAction("ViewGame", new { id = game.ID });

        }
        public IActionResult AddGame(Games gameToAdd)
        {
            if (gameToAdd == null)
            {
                return View("GameNotFound");
            }
            return View(gameToAdd);
        }
        public IActionResult AddGameToDatabase(Games game)
        {
            _repo.AddGame(game);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteGame(Games game)
        {
            _repo.DeleteGame(game);
            return RedirectToAction("Index");
        }
    }
}
