using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class Position
    {
        public Position()
        {
            PlayerOnTeamForSeasons = new HashSet<PlayerOnTeamForSeason>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlayerOnTeamForSeason> PlayerOnTeamForSeasons { get; set; }
    }
}
