using Dashboard.Interfaces;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Dashboard.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]   
    public class TasksListController : ApiController
    {
        private ITasksListRepository repository;
        private string userId;
        //private ApplicationDbContext db = new ApplicationDbContext();

        public TasksListController(ITasksListRepository repo)
        {            
            this.repository = repo;
            this.userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }
        public int PostAddList(TasksList list)
        {
            list.UserId = this.userId;
            int listId = repository.AddList(list);
            return listId;
        }

        public IEnumerable<TasksList> GetLists()
        {
            //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            //var userId = ClaimsPrincipal.Current.Identity.GetUserId();
            //var userId1 = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //var Name = ClaimsPrincipal.Current.Identity.Name;
            //var Name1 = User.Identity.Name;

            List<TasksList> model = repository.GetUserLists(this.userId).ToList();
            //var model = repository.GeAllLists();
            return model;
            
        }        
        

        public void DeleteList(int id)
        {
            repository.DeleteList(id);
        }
    }
}
