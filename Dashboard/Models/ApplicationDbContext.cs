using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<TasksList> TasksList { get; set; }
        public DbSet<Card> Cards { get; set; }
        
        public ApplicationDbContext()
            : base("MainConnection")
        {

        }
    }
}