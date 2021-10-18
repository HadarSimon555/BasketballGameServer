﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class GameStat
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlsyerShots { get; set; }
        public int PlayerId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
