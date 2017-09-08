using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dashboard.Models
{
    [DataContract]
    public class ApplicationUser : IdentityUser 
    {
        //public int Id { get; set; }
        //public string Email { get; set; }        
        //public string Password { get; set; }

        //[NotMapped]
        //public string AuthToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public List<TasksList> Lists { get; set; }
    }

    //public class TokenIdentity
    //{
    //    public int UserId { get; set; }

    //    public string AuthToken { get; set; }
      
    //}
}