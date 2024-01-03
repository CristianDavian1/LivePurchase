using Models.DTOs;
using Models.Responses;

namespace Business.Domain.UserDomain
{
    public interface IUserDomain
    {
        Task<GeneralResponseMessage> CreateUser(RequestAddGenericUser user);
    }
}
