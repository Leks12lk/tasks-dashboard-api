using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Dashboard.Models
{
    [DataContract]
    public class Card
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [ForeignKey("List")]
        [DataMember(Name = "listId")]
        public int TasksListId { get; set; }
        [IgnoreDataMember]
        public virtual TasksList List { get; set; }
    }
}