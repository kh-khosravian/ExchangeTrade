using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeTrade.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ExchangeTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userLogic.GetUser(username);
            if (user == null)
                return NotFound("Username not exist");
            return Ok(user);
        }
    }
}