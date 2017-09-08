using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dashboard.Models
{
    [DataContract]
    public class TasksList
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [IgnoreDataMember]
        public List<Card> Cards { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        [IgnoreDataMember]
        public virtual ApplicationUser User { get; set; }
    }
}