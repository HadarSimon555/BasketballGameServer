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

    }
}
