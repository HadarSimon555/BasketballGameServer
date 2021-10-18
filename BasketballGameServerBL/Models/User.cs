using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class User
    {
        public User()
        {
            Coaches = new HashSet<Coach>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public bool Gender { get; set; }
        public string City { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
