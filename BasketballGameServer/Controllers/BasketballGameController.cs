using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballGameServerBL.Models;
using System.IO;
using BasketballGameServer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
                    HttpContext.Session.SetObject("user", user);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return user;
                }

                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return null;
                }
            }
            catch (Exception e)
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
            try
            {
                if (player != null)
                {
                    bool addPlayer = this.context.AddPlayer(player);

                    if (addPlayer)
                    {
                        HttpContext.Session.SetObject("theUser", player);
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return player;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                        return null;
                    }

                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region CoachSignUp
        [Route("CoachSignUp")]
        [HttpPost]
        public Coach CoachSignUp([FromBody] Coach coach)
        {
            try
            {
                if (coach != null)
                {
                    bool addCoach = this.context.AddCoach(coach);

                    if (addCoach)
                    {
                        HttpContext.Session.SetObject("theUser", coach);
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return coach;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                        return null;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region UserExistByEmail
        [Route("UserExistByEmail")]
        [HttpGet]
        public bool UserExistByEmail([FromQuery] string email)
        {
            try
            {
                bool exist = this.context.UserExistByEmail(email);

                if (exist)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return true;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
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

        #region UpdateGamesStatuses
        [Route("UpdateGamesStatuses")]
        [HttpPost]
        public List<Game> UpdateGamesStatuses()
        {
            try
            {
                List<Game> games = context.Games.Include(g => g.GameStatus).ToList();
                if (games != null)
                {
                    List<Game> list = this.context.UpdateGamesStatuses();

                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return list;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region GetGames
        [Route("GetGames")]
        [HttpGet]
        public List<Game> GetGames(int teamId)
        {
            try
            {
                List<Game> games = UpdateGamesStatuses();
                if (games != null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    if (teamId != -1)
                        return games.Where(g => (g.HomeTeamId == teamId) || (g.AwayTeamId == teamId)).ToList();
                    return games;
                }
                return null;
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region AddTeam
        [Route("AddTeam")]
        [HttpPost]
        public Team AddTeam([FromBody] Team team)
        {
            try
            {
                if (team != null)
                {
                    bool addTeam = this.context.AddTeam(team);

                    if (addTeam)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return team;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return null;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region GetOpenTeams
        [Route("GetOpenTeams")]
        [HttpGet]
        public List<Team> GetOpenTeams()
        {
            List<Team> teams = context.Teams.Where(t => t.Players.Count() < 10).ToList();
            return teams;
        }
        #endregion

        #region AddRequestToJoinTeam
        [Route("AddRequestToJoinTeam")]
        [HttpPost]
        public bool AddRequestToJoinTeam([FromBody] RequestToJoinTeam request)
        {
            try
            {
                if (request != null)
                {
                    bool addRequest = this.context.AddRequestToJoinTeam(request);

                    if (addRequest)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region GetRequestsToJoinTeam
        [Route("GetRequestsToJoinTeam")]
        [HttpGet]
        public List<RequestToJoinTeam> GetRequestsToJoinTeam([FromQuery] int coachId)
        {
            List<RequestToJoinTeam> requests = context.GetRequestsToJoinTeam(coachId);
            return requests;
        }
        #endregion

        #region UpdatePlayer
        [Route("UpdatePlayer")]
        [HttpPost]
        public bool UpdatePlayer([FromBody] Player player)
        {
            try
            {
                if (player != null)
                {
                    bool updatePlayer = this.context.UpdatePlayer(player);

                    if (updatePlayer)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return false;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion 

        #region ApproveRequestToJoinTeam
        [Route("ApproveRequestToJoinTeam")]
        [HttpPost]
        public bool ApproveRequestToJoinTeam([FromBody] Player player)
        {
            try
            {
                if (player != null)
                {
                    RequestToJoinTeam request = player.RequestToJoinTeams.FirstOrDefault();
                    if (request != null)
                        request.RequestToJoinTeamStatus = context.RequestToJoinTeamStatuses.Where(r => r.Id == 1).FirstOrDefault();
                    bool updatePlayer = this.context.UpdatePlayer(player);

                    if (updatePlayer)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return false;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region DeleteRequestToJoinTeam
        [Route("DeleteRequestToJoinTeam")]
        [HttpPost]
        public bool DeleteRequestToJoinTeam([FromBody] Player player)
        {
            try
            {
                if (player != null)
                {
                    RequestToJoinTeam request = player.RequestToJoinTeams.FirstOrDefault();
                    if (request != null)
                        request.RequestToJoinTeamStatus = context.RequestToJoinTeamStatuses.Where(r => r.Id == 2).FirstOrDefault();
                    bool updatePlayer = this.context.UpdatePlayer(player);

                    if (updatePlayer)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return false;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region GetTeams
        [Route("GetTeams")]
        [HttpGet]
        public List<Team> GetTeams()
        {
            List<Team> teams = context.Teams.Include(t => t.Coach).Include(t => t.Players).Where(t => t.Players.Count() >= 2).ToList();
            return teams;
        }
        #endregion

        #region HasGame
        [Route("HasGame")]
        [HttpGet]
        public bool HasGame([FromQuery] int teamId1, int teamId2, DateTime date)
        {
            try
            {
                bool hasGame1 = context.HasGame(teamId1, date);
                bool hasGame2 = context.HasGame(teamId2, date);
                if (hasGame1 || hasGame2)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return true;
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region AddRequestToGame
        [Route("AddRequestToGame")]
        [HttpPost]
        public bool AddRequestToGame([FromBody] RequestGame request)
        {
            try
            {
                if (request != null)
                {
                    bool addRequest = this.context.AddRequestToGame(request);

                    if (addRequest)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return false;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region GetRequestsGame
        [Route("GetRequestsGame")]
        [HttpGet]
        public List<RequestGame> GetRequestsGame([FromQuery] int teamId)
        {
            try
            {
                List<RequestGame> requests = context.GetRequestsGame(teamId);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return requests;
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region ApproveRequestToGame
        [Route("ApproveRequestToGame")]
        [HttpPost]
        public bool ApproveRequestToGame([FromBody] RequestGame request)
        {
            if (request != null)
            {
                Game game = new Game()
                {
                    HomeTeam = request.CoachHomeTeam.Team,
                    AwayTeam = request.AwayTeam,
                    GameStatus = context.GameStatuses.Where(r => r.Id == 1).FirstOrDefault(),
                    ScoreAwayTeam = -1,
                    ScoreHomeTeam = -1,
                    Date = request.Date,
                    Time = request.Time,
                    Position = request.Position
                };
                try
                {
                    bool success = context.AddGame(game);

                    if (success)
                    {
                        RequestGame rq = context.RequestGames.Where(r => r.Id == request.Id).Include(r => r.RequestGameStatus).FirstOrDefault();
                        rq.RequestGameStatus = context.RequestGameStatuses.Where(r => r.Id == 1).FirstOrDefault();
                        rq.RequestGameStatusId = rq.RequestGameStatus.Id;
                        context.Entry(rq).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    return false;
                }
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
        }
        #endregion

        #region DeleteRequestToGame
        [Route("DeleteRequestToGame")]
        [HttpPost]
        public bool DeleteRequestToGame([FromBody] RequestGame request)
        {
            if (request != null)
            {
                RequestGame rq = context.RequestGames.Where(r => r.Id == request.Id).Include(r => r.RequestGameStatus).FirstOrDefault();

                rq.RequestGameStatus = context.RequestGameStatuses.Where(r => r.Id == 2).FirstOrDefault();
                rq.RequestGameStatusId = rq.RequestGameStatus.Id;
                context.Entry(rq).State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return true;
                }
                catch (Exception e)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    return false;
                }
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
        }

        #endregion

        #region AddGame
        [Route("AddGame")]
        [HttpPost]
        public Game AddGame([FromBody] Game game)
        {
            try
            {
                if (game != null)
                {
                    bool addGame = this.context.AddGame(game);

                    if (addGame)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return game;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return null;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return null;
            }
        }
        #endregion

        #region GetMyRequestToJoinTeam
        [Route("GetMyRequestToJoinTeam")]
        [HttpGet]
        public RequestToJoinTeam GetMyRequestToJoinTeam([FromQuery] int playerId)
        {
            RequestToJoinTeam request = context.GetMyRequestToJoinTeam(playerId);
            return request;
        }
        #endregion

        #region GetPlayers
        [Route("GetPlayers")]
        [HttpGet]
        public List<Player> GetPlayers([FromQuery] int userId)
        {
            try
            {
                if (userId != -1)
                {
                    List<Player> list = context.Players.Where(x => x.UserId == userId).Include(x => x.GameStats).ToList();
                    return list;
                }
                else
                {
                    List<Player> list = context.Players.Include(x => x.GameStats).ToList();
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetGameStats
        [Route("GetGameStats")]
        [HttpGet]
        public List<GameStat> GetGameStats([FromQuery] int gameId, int teamId)
        {
            try
            {
                List<GameStat> gameStats = context.GameStats.Where(x => x.GameId == gameId).Include(x => x.Player.Team).Include(x => x.Player.User).ToList();
                List<GameStat> list = gameStats.Where(x => x.Player.TeamId == teamId).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region SaveGameStats
        [Route("SaveGameStats")]
        [HttpPost]
        public bool SaveGameStats([FromBody] List<GameStat> listGameStats)
        {
            try
            {
                if (listGameStats != null)
                {
                    bool saveGameStats = this.context.SaveGameStats(listGameStats);
                    if (saveGameStats)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return true;
                    }
                    else
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                        return false;
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return false;
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return false;
            }
        }
        #endregion

        #region GetPlayersRanking
        [Route("GetPlayersRanking")]
        [HttpGet]
        public List<PlayerStatistics> GetPlayersRanking()
        {
            try
            {
                //שליפת כל נתוני המשחקים
                List<GameStat> list = context.GameStats.Where(g => g.PlayerShots != -1).Include(g => g.Player.Team).Include(g => g.Player.User).ToList();
                List<PlayerStatistics> result;
                //אם הרשימה ריקה 
                if (list == null)
                    return null;

                //קבץ את הנתונים לפי מזהה השחקן
                //עבור כל קבוצה- צור רשומת סטטיסטיקת שחקן שהערכים שלה הם
                //שחקן - השחקן של קבוצת הערכים
                //Games- כמות הרשומות בקבוצת הערכים
                //Sum - סכום לפי קובצת הערכים לפי שדה playershots
                result = list.GroupBy(p => p.Player.Id).Select(cl => new PlayerStatistics
                {
                    Player = cl.First().Player,
                    Games = cl.Count(),
                    TotalScore = cl.Sum(s => s.PlayerShots)
                }).ToList<PlayerStatistics>().OrderByDescending(s => ((double)(s.TotalScore)) / s.Games).ToList();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region GetTeamsRanking
        [Route("GetTeamsRanking")]
        [HttpGet]
        public List<TeamStatistics> GetTeamsRanking()
        {
            try
            {
                List<GameStat> list = context.GameStats.Where(g => g.PlayerShots != -1).Include(g => g.Player.Team).ThenInclude(t => t.GameAwayTeams).Include(g => g.Player.Team).ThenInclude(t => t.GameHomeTeams).Include(g => g.Player.User).ToList();
                List<TeamStatistics> result;
                //אם הרשימה ריקה 
                if (list == null)
                    return null;

                result = list.GroupBy(t => t.Player.Team.Id).Select(cl => new TeamStatistics
                {
                    Team = cl.First().Player.Team,
                    Games = cl.First().Player.Team.GameAwayTeams.Where(g=>g.ScoreAwayTeam!=-1).Count() + cl.First().Player.Team.GameHomeTeams.Where(g=>g.ScoreHomeTeam!=-1).Count(),
                    TotalScore = cl.Sum(s => s.PlayerShots)
                }).ToList<TeamStatistics>().OrderByDescending(s => ((double)(s.TotalScore)) / s.Games).ToList();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}

