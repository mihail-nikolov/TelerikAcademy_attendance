﻿namespace Exam.Services.Data.Contracts
{
    using Exam.Data.Models;
    using System.Linq;

    public interface IGameService
    {
        IQueryable<Game> GetPublicGames(int page = 0, string userId = null);

        Game CreateGame(string name, string number, string userId);

        IQueryable<Game> GetGameDetails(int id);

        bool GameCanBeJoinedByUser(int id, string userId);

        string JoinGame(int id, string number, string userId);

        bool CanMakeGuess(int id, string userId);

        bool UserIsPartOfGame(int id, string userId);

        void ChangeGameState(int id, bool finished);
    }
}
