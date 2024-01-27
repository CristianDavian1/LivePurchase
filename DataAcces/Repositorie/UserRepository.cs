using DataAcces.ModelsDb;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Boolean> AddUser(RequestAddGenericUser addUser)
        {
            var newUser = new User
            {
                UserName = addUser.UserName,
                AddressUser = addUser.AddressUser,
                UserEmail = addUser.UserEmail,
                UserRol = addUser.UserRol,
                UserType = addUser.userType
            };
            _dbcontext.Add(newUser);
            var res = await _dbcontext.SaveChangesAsync();
            if(res > 0){
                return true;
            } else {
                return false;
            }

            
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> usuarios = await _dbcontext.Users.ToListAsync();

            return usuarios;
        }
   }
}