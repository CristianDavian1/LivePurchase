using Business.Domain.UserDomain;
using Models.Responses;
using Models.DTOs;
using DataAcces.Repositorie;

public class UserDomain : IUserDomain
{

    private readonly IUserRepository _IUserRepo;

    public UserDomain(IUserRepository userRepo)
    {
        _IUserRepo = userRepo;
    }

    public async Task<GeneralResponseMessage> CreateUser(RequestAddGenericUser user)
    {
        try{
             var add = await _IUserRepo.AddUser(user);
             if (add == true){
                GeneralResponseMessage repuesta = new GeneralResponseMessage
                {
                    Status = 200,
                    Msg = "Se agrego el usuario correctamente" 
                };
            return repuesta;
             } else {
                GeneralResponseMessage repuesta = new GeneralResponseMessage
                {
                    Status = 200,
                    Msg = "No se pudo agregar el usuario" 
                };
                return repuesta;
             }
             
        }catch(System.Exception e){
            GeneralResponseMessage repuesta = new GeneralResponseMessage
                {
                    Status = 500,
                    Msg =  e.Message
                };
            return repuesta;
        }
       
    }
}