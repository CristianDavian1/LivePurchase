using Business.Domain.UserDomain;
using Models.Responses;
using Models.DTOs;
using DataAcces.Repositorie;
using DataAcces.ModelsDbAWS;

public class UserDomain : IUserDomain
{

    private readonly IUserRepository _IUserRepo;

    public UserDomain(IUserRepository userRepo)
    {
        _IUserRepo = userRepo;
    }

    public async Task<GeneralResponseMessage<string>> CreateUser(RequestAddGenericUser user)
    {
        try{
             var add = await _IUserRepo.AddUser(user);
             if (add == true){
                GeneralResponseMessage<string> repuesta = new GeneralResponseMessage<string>
                {
                    Status = 200,
                    Msg = "Se agrego el usuario correctamente" 
                };
            return repuesta;
             } else {
                GeneralResponseMessage<string> repuesta = new GeneralResponseMessage<string>
                {
                    Status = 200,
                    Msg = "No se pudo agregar el usuario" 
                };
                return repuesta;
             }
             
        }catch(System.Exception e){
            GeneralResponseMessage<string> repuesta = new GeneralResponseMessage<string>
                {
                    Status = 500,
                    Msg =  e.Message
                };
            return repuesta;
        }
       
    }

    public async Task<UsersResponse> GetUsuarios()
    {
        try{
            var getU = await _IUserRepo.GetUsers();
            if(getU.Count > 0){
                
                UsersResponse usuarios = new UsersResponse
                {
                    Status = 200,
                    msg = "OK",
                    Usuarios = getU
                };
                return usuarios;
            } else {
                UsersResponse usuarios = new UsersResponse
                {
                    Status = 204,
                    msg = "OK - No se encontraron usuarios",
                    Usuarios = getU
                };

                return usuarios;
            }
        } catch(System.Exception e){
            UsersResponse usuarios = new UsersResponse
                {
                    Status = 200,
                    msg = $"Error del servidor al obtener usuarios {e}",
                    Usuarios = null
                };
                return usuarios;
        }
    }

    public async Task<GeneralResponseMessage<User>> Autenticate(LoginDto auth)
    {
        try{
            var res = await _IUserRepo.UserLogin(auth);
            if (res != null){
                GeneralResponseMessage<User> response = new GeneralResponseMessage<User>
                {
                    Status = 200,
                    Msg = res
                };
            return response;
            } else {
                GeneralResponseMessage<User> response = new GeneralResponseMessage<User>
                {
                    Status = 204,
                    Msg = null
                };
                return response;
            }
            
        } catch(System.Exception e){
            GeneralResponseMessage<User> errorResponse = new GeneralResponseMessage<User>
            {
                Status = 500,
                Msg = null 
            };
        return errorResponse;
        }   
    }
}