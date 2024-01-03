using Microsoft.AspNetCore.Mvc;
using System;
using Models.DTOs;
using Models.Responses;
using Business.Domain.UserDomain;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserDomain _domainUser;

        public UserController(IUserDomain domainUser)
        {
            _domainUser = domainUser;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenericUser([FromBody] RequestAddGenericUser UserRequest)
        {
            try {
                var addUser = await _domainUser.CreateUser(UserRequest);
                return Ok(addUser);
            }catch(System.Exception e){
                return Problem(e.Message);
            }
            

            
        }
    }
}
