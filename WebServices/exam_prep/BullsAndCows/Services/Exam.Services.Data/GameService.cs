namespace Exam.Services.Data
{
    using Exam.Data.Models;
    using System;
    using System.Linq;
    using Exam.Services.Data.Contracts;
    using Exam.Data.Repositories;
    using Common.Constants;

    public class GameService : IGameService
    {
        //private readonly IHighScoreService highScore;
        private readonly IRepository<Game> games;
        //private readonly IRandomProvider random;

        public GameService(IRepository<Game> games)
        {
           // this.highScore = highScore;
            this.games = games;
          //  this.random = random;
        }

        public bool CanMakeGuess(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void ChangeGameState(int id, bool finished)
        {
            throw new NotImplementedException();
        }

        public Game CreateGame(string name, string number, string userId)
        {
            var newGame = new Game
            {
                Name = name,
                GameState = GameState.WaitingForOpponent,
                RedUserId = userId,
                RedUserNumber = number,
                DateCreated = DateTime.UtcNow
            };

            this.games.Add(newGame);
            this.games.SaveChanges();

            return newGame;
        }

        public bool GameCanBeJoinedByUser(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Game> GetGameDetails(int id)
        {
            return this.games
                .All()
                .Where(g => g.Id == id);
        }

        public IQueryable<Game> GetPublicGames(int page = 1, string userId = null)
        {
            return this.games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent
                    || (g.GameState != GameState.WaitingForOpponent
                    && (g.RedUserId == userId || g.BlueUserId == userId)))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedUser.Email)
                .Skip((page - 1) * GameConstants.GamesPerPage)
                .Take(GameConstants.GamesPerPage);
        }

        public string JoinGame(int id, string number, string userId)
        {
            throw new NotImplementedException();
        }

        public bool UserIsPartOfGame(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
