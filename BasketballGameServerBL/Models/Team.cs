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
            PlayerOnTeamForSeasons = new HashSet<PlayerOnTeamForSeason>();
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
        public virtual ICollection<PlayerOnTeamForSeason> PlayerOnTeamForSeasons { get; set; }
        public virtual ICollection<RequestToJoinTeam> RequestToJoinTeams { get; set; }
    }
}
