using Dashboard.Library;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Dashboard.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public ApplicationUser APIUser { get; set; }
        public string AuthToken { get; set; }

        public bool HasValidToken
        {
            get
            {
                //return String.IsNullOrEmpty(AuthToken) ? Functions.IsTokenValid(AuthToken, this.APIUser.Id) : false;
                return false;
            }
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            APIUser = new ApplicationUser();
            AuthToken = String.Empty;

            // If we weren't able to grab the Session object, try to grab the user from the old AuthToken and SessionToken
            if (this.Request.Headers.Contains("AuthToken"))
            {
                string authToken = this.Request.Headers.GetValues("AuthToken").FirstOrDefault();
                AuthToken = authToken;
                //APIUser = tokens.User;
            }
        }
    }
}
