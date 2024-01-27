using Models.DTOs;
using Models.Responses;
using DataAcces.ModelsDb;

namespace Business.Domain.UserDomain
{
    public interface IUserDomain
    {
        Task<GeneralResponseMessage> CreateUser(RequestAddGenericUser user);
        Task<UsersResponse> GetUsuarios();
    }
}
