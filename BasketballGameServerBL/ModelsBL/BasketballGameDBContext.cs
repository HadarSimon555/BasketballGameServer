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
        #region Login
        // פעולת התחברות, אם ההתחברות לא הצליחה מחזיר null
        public User Login(string email, string pass)
        {
            return this.Users.Where(u => u.Email == email && u.Pass == pass).FirstOrDefault();
        }
        #endregion

        #region AddPlayer
        public void AddPlayer(Player player)
        {
            try
            {
                this.Players.Add(player);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region AddCoach
        public void AddCoach(Coach coach)
        {
            try
            {
                this.Coaches.Add(coach);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        // פעולה הבודקת האם האימייל שהתקבל הוא ייחודי או שהוא כבר קיים ברשימת המשתמשים
        public bool UserExistByEmail(string email)
        {
            return Users.Any(u => u.Email == email);
        }

        // פעולה הבודקת האם הסיסמה שהתקבלה היא ייחודית או שהיא כבר קיים ברשימת המשתמשים
        public bool UserExistByUserName(string pass)
        {
            return Users.Any(u => u.Pass == pass);
        }
    }
}
