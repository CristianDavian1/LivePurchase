using Models.DTOs;
using DataAcces.ModelsDbAWS;
using Models.Responses;


namespace DataAcces.Repositorie
{
     public interface IUserRepository
    {
        Task<Boolean> AddUser(RequestAddGenericUser addUser);
        Task<List<User>> GetUsers();
        Task<User> UserLogin(RequestAuthenticate auth);
    }
}