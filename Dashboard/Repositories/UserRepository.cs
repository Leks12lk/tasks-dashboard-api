using Dashboard.Interfaces;
using Dashboard.Library;
using Dashboard.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dashboard.ViewModels;

namespace Dashboard.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ApplicationDbContext db;

        private UserManager<ApplicationUser> _userManager;

        public UserRepository()
        {
            db = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
 
        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
 
            var result = await _userManager.CreateAsync(user, userModel.Password);
 
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);
 
            return user;
        }
 
        public void Dispose()
        {
            db.Dispose();
            _userManager.Dispose();
 
        }

        //public User CreateUser(User user)
        //{
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    user.AuthToken = GenerateAuthToken(user.Id);
        //    user.Password = Functions.PasswordMD5Calc(user.Password, user.Id);
        //    db.SaveChanges();
        //    return user;
        //}

        //private string GenerateAuthToken(int userId)
        //{
        //    return Functions.MD5Calc(userId.ToString());
        //}
    }
}