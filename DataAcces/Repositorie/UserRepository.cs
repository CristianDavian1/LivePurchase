using DataAcces.ModelsDbAWS;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using System.Linq;
using Utils.Security;


namespace DataAcces.Repositorie
{
   public class UserRepository : IUserRepository
   {
        private readonly LivePurchaseContext _dbcontext;
        private readonly SecuredPassword _securedPassword;

        public UserRepository( LivePurchaseContext dbcontext, SecuredPassword securedPassword)
        {
            _dbcontext = dbcontext;
            _securedPassword = securedPassword;
        }
        public async Task<Boolean> AddUser(RequestAddGenericUser addUser)
        {
            var securedPass = _securedPassword.GenerarHash(addUser.password);
            var newUser = new User
            {
                Id = addUser.UserId,
                UserName = addUser.UserName,
                AddressUser = addUser.AddressUser,
                UserEmail = addUser.UserEmail,
                UserRol = addUser.UserRol,
                UserType = addUser.userType,
                Password = securedPass,
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

        public async Task<User> UserLogin(LoginDto auth)
        {
            var compareHash = _securedPassword.GenerarHash(auth.Password);
            var respose = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == auth.UserName && u.Password == compareHash);

            return respose;

        }


   }
}