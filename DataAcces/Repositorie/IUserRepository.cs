using Models.DTOs;
using DataAcces.ModelsDb;


namespace DataAcces.Repositorie
{
     public interface IUserRepository
    {
        Task<List<User>> AddUser(RequestAddGenericUser addUser);
    }
}