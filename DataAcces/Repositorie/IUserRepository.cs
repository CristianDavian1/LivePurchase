using Models.DTOs;

namespace DataAcces.Repositorie
{
     public interface IUserRepository
    {
        Task<Boolean> AddUser(RequestAddGenericUser addUser);
    }
}