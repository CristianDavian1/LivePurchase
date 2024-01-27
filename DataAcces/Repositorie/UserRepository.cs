using DataAcces.ModelsDb;
using Models.DTOs;
using System.Linq;

namespace DataAcces.Repositorie
{
   public class UserRepository : IUserRepository
   {
        private readonly LivePurchaseContext _dbcontext;

        public UserRepository( LivePurchaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<User>> AddUser(RequestAddGenericUser addUser)
        {
            var users = _dbcontext.Users.ToList();
            return users;
        }
   }
}