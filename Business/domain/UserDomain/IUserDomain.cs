using Models.DTOs;
using Models.Responses;
using DataAcces.ModelsDbAWS;

namespace Business.Domain.UserDomain
{
    public interface IUserDomain
    {
        Task<GeneralResponseMessage<string>> CreateUser(RequestAddGenericUser user);
        Task<UsersResponse> GetUsuarios();
        Task<GeneralResponseMessage<User>> Autenticate(LoginDto auth);
    }
}
