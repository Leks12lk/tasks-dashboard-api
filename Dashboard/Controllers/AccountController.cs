using Dashboard.Interfaces;
using Dashboard.Library;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dashboard.ViewModels;
using Microsoft.AspNet.Identity;
using Dashboard.Repositories;

namespace Dashboard.Controllers
{
    //[RoutePrefix("{route:Route}/Account")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IUserRepository repository;
        public AccountController(IUserRepository repo)
        {
            //this.repository = new UserRepository();
            this.repository = repo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await repository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        //private SignInManager _signInManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set { _signInManager = value; }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        //[Route("Register")]
        //public User PostRegister(Dashboard.ViewModels.AccountViewModels.RegisterViewModel user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new User();
        //    }
        //    User model = new User();
        //    model.Email = user.Email;
        //    model.FirstName = user.FirstName;
        //    model.LastName = user.LastName;            

        //    var userData = repository.CreateUser(model);
        //    return userData;
            
        //}

    }
}
