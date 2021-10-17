using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballGameServerBL.Models;
using System.IO;

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

        [Route("Test")]
        [HttpGet]
        public string Hello()
        { return "hello Hadar"; }

        #region Login
        [Route("Login")]
        [HttpPost]
        public PlayerDTO Login([FromBody] PlayerDTO p)
        {
            try
            {
                Player pl = this.context.Login(p.PlayerEmail, p.PlayerUserName, p.PlayerPassword);
                //Check user name and password
                if (pl != null)
                {
                    PlayerDTO pDTO = new PlayerDTO(pl);
                    HttpContext.Session.SetObject("player", pDTO);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return pDTO;
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

    }
}
