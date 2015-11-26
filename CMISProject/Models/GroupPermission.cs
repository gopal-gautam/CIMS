using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the permission that assigned to group only by the admin 
    /// All members of the group get the permission.
    /// The properties are:
    /// GroupPermissionId : identifies the group permission uniquely
    /// GroupId: used as foreign key to identify the group to which the permission is assigned
    /// Group: represents the group to which the permission is assigned
    /// PermissionId: used as foreign key to identify the permission that is to be assigned to group
    /// Permission: represents the permission assigned to group
    /// </summary>
    public class GroupPermission
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupPermissionId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        
        [Required]
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }

    }
}