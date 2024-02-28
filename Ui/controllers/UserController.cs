using Microsoft.AspNetCore.Mvc;
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
                var getUsers = await _domainUser.GetUsuarios();
                return Ok(getUsers);
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto auth)
        {
            try{
                var authe = await _domainUser.Autenticate(auth);
                if (authe.Msg != null){
                    var tokenGenerado = _tokenGenerator.GenerarToken(auth);
                    return Ok(new {usuario = authe, token = tokenGenerado});
                } else {
                   return Ok(new {stattus = 204, msj = "Usuario no encontrado, o contraseña incorrecta"});
                }
                
            } catch(System.Exception e){
                return Problem(e.Message);
            }
        }


    }
}
