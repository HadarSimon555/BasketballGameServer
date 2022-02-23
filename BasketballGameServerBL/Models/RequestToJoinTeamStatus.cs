using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class RequestToJoinTeamStatus
    {
        public RequestToJoinTeamStatus()
        {
            RequestToJoinTeams = new HashSet<RequestToJoinTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestToJoinTeam> RequestToJoinTeams { get; set; }
    }
}
