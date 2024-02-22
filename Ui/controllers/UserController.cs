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
        private IConfiguration config;

        public UserController(IUserDomain domainUser)
        {
            _domainUser = domainUser;
            this.config = config;
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

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try {
                var getUsers = await _domainUser.GetUsuarios();
                return Ok(getUsers);
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(RequestAuthenticate auth)
        {
            try{
                var authe = await _domainUser.Autenticate(auth);
                if (authe != null){
                    return Ok(authe);
                } else {
                   return Ok(new {msj = "Usuario no encontrado"});
                }
                
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }


    }
}
