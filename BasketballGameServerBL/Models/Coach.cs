﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class Coach
    {
        public Coach()
        {
            RequestGames = new HashSet<RequestGame>();
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestGame> RequestGames { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
