using System;
using System.Collections.Generic;

#nullable disable

namespace BasketballGameServerBL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
    }
}
