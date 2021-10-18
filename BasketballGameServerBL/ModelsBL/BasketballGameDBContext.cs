using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketballGameServerBL.Models
{
    public partial class BasketballGameDBContext:DbContext
    {
        // פעולת התחברות, אם ההתחברות לא הצליחה מחזיר null
        public Player Login(string email, string pass)
        {
            return this.Users.Where(u => u.Email == email && u.Pass == pass).FirstOrDefault();
        }

    }
}
