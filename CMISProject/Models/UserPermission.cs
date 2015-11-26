using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the permission that assigned to user only by the admin 
    /// Only the assigned user get the permission.
    /// The properties are:
    /// UserPermissionId : identifies the user permission uniquely
    /// UserId: used as foreign key to identify the user to which the permission is assigned
    /// User: represents the user to which the permission is assigned
    /// PermissionId: used as foreign key to identify the permission that is to be assigned to user
    /// Permission: represents the permission assigned to group
    /// </summary>
    public class UserPermission
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserPermissionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }

    }
}