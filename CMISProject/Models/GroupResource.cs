using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the resource that assigned to group only by the admin 
    /// All the members of the group get the resource.
    /// The properties are:
    /// GroupResourceId : identifies the group resource uniquely
    /// GroupId: used as foreign key to identify the group to which the resource is assigned
    /// Group: represents the group to which the resource is assigned
    /// ResourceId: used as foreign key to identify the resource that is to be assigned to group
    /// Resource: represents the resource assigned to group
    /// </summary>
    public class GroupResource
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupResourceId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public string ResourceName { get; set; }

        [ForeignKey("ResourceName")]
        public virtual Resource Resource { get; set; }

    }
}