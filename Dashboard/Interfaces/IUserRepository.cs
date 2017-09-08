using Dashboard.Models;
using Dashboard.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(RegisterViewModel userModel);
        Task<ApplicationUser> FindUser(string userName, string password);
        void Dispose();

        //User CreateUser(User user);
    }
}
