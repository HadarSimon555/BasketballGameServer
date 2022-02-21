using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketballGameServerBL.Models
{
    public partial class BasketballGameDBContext : DbContext
    {
        #region Login
        // פעולת התחברות, אם ההתחברות לא הצליחה מחזיר null
        public User Login(string email, string pass)
        {
            return this.Users.Include(u => u.Players).ThenInclude(u => u.Team).Include(u => u.Coaches).ThenInclude(u => u.Teams).Where(u => u.Email == email && u.Pass == pass).FirstOrDefault();
        }
        #endregion

        #region AddPlayer
        public bool AddPlayer(Player player)
        {
            try
            {
                this.Players.Add(player);
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion

        #region AddCoach
        public bool AddCoach(Coach coach)
        {
            try
            {
                this.Coaches.Add(coach);
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion

        #region UserExistByEmail
        // פעולה הבודקת האם האימייל שהתקבל הוא ייחודי או שהוא כבר קיים ברשימת המשתמשים
        public bool UserExistByEmail(string email)
        {
            return Users.Any(u => u.Email == email);
        }
        #endregion

        #region AddTeam
        public bool AddTeam(Team team)
        {
            try
            {
                this.Teams.Update(team);
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion

        #region AddRequestToJoinTeam
        public bool AddRequestToJoinTeam(RequestToJoinTeam request)
        {
            try
            {
                this.RequestToJoinTeams.Add(new RequestToJoinTeam() { PlayerId = request.Player.Id, TeamId = request.Team.Id });
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<RequestToJoinTeam> GetRequests(int coachId)
        {
            return this.RequestToJoinTeams.Include(r => r.Player).ThenInclude(p => p.User).Include(r => r.Team).ThenInclude(c => c.Coach).Where(c => c.Id == coachId).ToList();
        }
        #endregion

        #region UpdatePlayer
        public bool UpdatePlayer(Player player)
        {
            if (player.Team != null)
                player.RequestToJoinTeams = null;
            try
            {
                this.Players.Update(player);
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion
    }
}