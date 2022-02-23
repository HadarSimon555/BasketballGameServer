﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class RequestToJoinTeam
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int RequestToJoinTeamStatusId { get; set; }

        public virtual Player Player { get; set; }
        public virtual RequestToJoinTeamStatus RequestToJoinTeamStatus { get; set; }
        public virtual Team Team { get; set; }
    }
}
