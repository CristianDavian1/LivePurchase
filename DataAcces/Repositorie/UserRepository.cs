using DataAcces.ModelsDbAWS;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using System.Linq;
using Models.Responses;
using Models;

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
                Id = addUser.UserId,
                UserName = addUser.UserName,
                AddressUser = addUser.AddressUser,
                UserEmail = addUser.UserEmail,
                UserRol = addUser.UserRol,
                UserType = addUser.userType,
                Password = addUser.password,
                Names = addUser.names,
                LastNames = addUser.lastNames,
                Document = addUser.document
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

        public async Task<User> UserLogin(RequestAuthenticate auth)
        {
            var respose = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserEmail == auth.userEmail && u.Password == auth.password);

            return respose;

        }


   }
}