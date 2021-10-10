using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class Player
    {
        public Player()
        {
            GameStats = new HashSet<GameStat>();
            PlayerOnTeamForSeasons = new HashSet<PlayerOnTeamForSeason>();
            RequestToJoinTeams = new HashSet<RequestToJoinTeam>();
        }

        public int Id { get; set; }
        public double Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<GameStat> GameStats { get; set; }
        public virtual ICollection<PlayerOnTeamForSeason> PlayerOnTeamForSeasons { get; set; }
        public virtual ICollection<RequestToJoinTeam> RequestToJoinTeams { get; set; }
    }
}
