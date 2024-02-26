using Microsoft.AspNetCore.Mvc;
using System;
using Models.DTOs;
using Models.Responses;
using Business.Domain.UserDomain;
using Microsoft.AspNetCore.Authorization;
using Utils.Security;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserDomain _domainUser;
        private readonly TokenGenerator _tokenGenerator;
        private IConfiguration config;

        public UserController(IUserDomain domainUser, TokenGenerator tokenGenerator)
        {
            _domainUser = domainUser;
            this.config = config;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try {
                
                return Ok("seee jajajaja");
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto auth)
        {
            try{
                // var authe = await _domainUser.Autenticate(auth);
                if (auth.UserName == "perrohp"){
                    var tokenGenerado = _tokenGenerator.GenerarToken(auth);
                    return Ok(new {usuario = auth, token = tokenGenerado});
                } else {
                   return Ok(new {msj = "Usuario no encontrado"});
                }
                
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }


    }
}
