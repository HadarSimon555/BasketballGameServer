using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class PlayerOnTeamForSeason
    {
        public int PositionId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
    }
}
