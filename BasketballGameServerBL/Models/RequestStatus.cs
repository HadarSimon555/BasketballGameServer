using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            RequestGames = new HashSet<RequestGame>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestGame> RequestGames { get; set; }
    }
}
