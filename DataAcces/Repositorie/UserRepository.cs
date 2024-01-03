using Models.DTOs;

namespace DataAcces.Repositorie
{
   public class UserRepository : IUserRepository
   {
        public async Task<Boolean> AddUser(RequestAddGenericUser addUser)
        {
            return true;
        }
   }
}