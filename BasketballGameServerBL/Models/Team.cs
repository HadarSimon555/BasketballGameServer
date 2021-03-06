using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class Team
    {
        public Team()
        {
            Coaches = new HashSet<Coach>();
            GameAwayTeams = new HashSet<Game>();
            GameHomeTeams = new HashSet<Game>();
            Players = new HashSet<Player>();
            RequestGames = new HashSet<RequestGame>();
            RequestToJoinTeams = new HashSet<RequestToJoinTeam>();
        }

        public int Id { get; set; }
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Game> GameAwayTeams { get; set; }
        public virtual ICollection<Game> GameHomeTeams { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<RequestGame> RequestGames { get; set; }
        public virtual ICollection<RequestToJoinTeam> RequestToJoinTeams { get; set; }
    }
}
