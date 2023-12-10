using Microsoft.AspNetCore.Mvc;
using System;
using models.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult<User> GetUser()
        {
            User usuario = new User
            {
                UserId = 1,
                UserName = "Carlitos Romeros",
                Email = "carlos990@gmail.com"
            };
            return usuario;
        }
    }
}
