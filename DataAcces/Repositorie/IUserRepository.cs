using Models.DTOs;
using DataAcces.ModelsDb;


namespace DataAcces.Repositorie
{
     public interface IUserRepository
    {
        Task<Boolean> AddUser(RequestAddGenericUser addUser);
        Task<List<User>> GetUsers();
    }
}