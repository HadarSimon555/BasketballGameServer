using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class Game
    {
        public Game()
        {
            GameStats = new HashSet<GameStat>();
            RequestGames = new HashSet<RequestGame>();
        }

        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int GameStatusId { get; set; }
        public int ScoreAwayTeam { get; set; }
        public int ScoreHomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }
        public virtual GameStatus GameStatus { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual ICollection<GameStat> GameStats { get; set; }
        public virtual ICollection<RequestGame> RequestGames { get; set; }
    }
}
