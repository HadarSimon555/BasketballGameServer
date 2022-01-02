using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballGameServerBL.Models;
using System.IO;
using BasketballGameServer.DTO;

namespace BasketballGameServer.Controllers
{
    [Route("BasketballGameApi")]
    [ApiController]
    public class BasketballGameController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        BasketballGameDBContext context;
        public BasketballGameController(BasketballGameDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region Test
        [Route("Test")]
        [HttpGet]
        public string Hello()
        { return "hello Hadar"; }
        #endregion

        #region Login
        [Route("Login")]
        [HttpPost]
        public User Login([FromBody] UserDTO u)
        {
            try
            {
                User user = this.context.Login(u.Email, u.Pass);
                if (user != null)
                {
                    // UserDTO userDTO = new UserDTO(user);
                    HttpContext.Session.SetObject("user", user);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return user;
                }

                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region PlayerSignUp
        [Route("PlayerSignUp")]
        [HttpPost]
        public Player PlayerSignUp([FromBody] Player player)
        {
            //Check user name and password
            if (player != null)
            {
                bool addPlayer = this.context.AddPlayer(player);

                if (addPlayer)
                {
                    HttpContext.Session.SetObject("theUser", player);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                    return player;
                }
                else
                    return null;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        #endregion

        #region CoachSignUp
        [Route("CoachSignUp")]
        [HttpPost]
        public Coach CoachSignUp([FromBody] Coach coach)
        {
            //Check user name and password
            if (coach != null)
            {
                bool addCoach = this.context.AddCoach(coach);

                if (addCoach)
                {
                    HttpContext.Session.SetObject("theUser", coach);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                    return coach;
                }
                else
                    return null;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        #endregion,

        #region UserExistByEmail
        [Route("UserExistByEmail")]
        [HttpGet]
        public bool UserExistByEmail([FromQuery] string email)
        {
            bool exist = this.context.UserExistByEmail(email);

            if (exist)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return true;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
        }
        #endregion

        #region UploadImage
        [Route("UploadImage")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");
            //Check if user logged in and its ID is the same as the contact user ID
            if (user != null)
            {
                if (file == null)
                {
                    return BadRequest();
                }

                try
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    return Ok(new { length = file.Length, name = file.FileName });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }
            return Forbid();
        }
        #endregion

        #region GetGames
        [Route("GetGames")]
        [HttpGet]
        public List<Game> GetGames(string myTeam)
        {
            return context.Games.ToList();
        }
        #endregion

        #region GetPlayerOnTeamForSeason
        [Route("GetPlayerOnTeamForSeason")]
        [HttpGet]
        public PlayerOnTeamForSeason GetPlayerOnTeamForSeason([FromQuery] int userId)
        {
            try
            {
                Player p = context.Players.FirstOrDefault(x => x.UserId == userId);
                return context.PlayerOnTeamForSeasons.FirstOrDefault(x => x.PlayerId == p.Id);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region AddTeam
        [Route("AddTeam")]
        [HttpPost]
        public Team AddTeam([FromBody] Team team)
        {
            //Check user name and password
            if (team != null)
            {
                bool addTeam = this.context.AddTeam(team);

                if (addTeam)
                {
                    HttpContext.Session.SetObject("theUser", team);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                    return team;
                }
                else
                    return null;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        #endregion

        #region GetLeagues
        [Route("GetLeagues")]
        [HttpGet]
        public List<League> GetLeagues()
        {
            return context.Leagues.ToList();
        }
        #endregion
    }
}

