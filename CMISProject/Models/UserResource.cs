using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the resource that assigned to user only by the admin 
    /// Only the assigned user get the resource.
    /// The properties are:
    /// UserResourceId : identifies the user resource uniquely
    /// UserId: used as foreign key to identify the user to which the resource is assigned
    /// User: represents the user to which the resource is assigned
    /// ResourceId: used as foreign key to identify the resource that is to be assigned to user
    /// Resource: represents the resource assigned to user
    /// </summary>
    public class UserResource
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserResourceId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string ResourceName { get; set; }

        [ForeignKey("ResourceName")]
        public virtual Resource Resource { get; set; }
    }
}