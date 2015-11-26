using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains all the properties to represent the permission.
    /// Admin can only assign and remove the permission to group and user.
    /// The properties are:
    /// PermissionId: identifies the permission uniquely
    /// PermissionName: represents the name of the permission
    /// PermissionDescription: represents the description of the permission
    /// </summary>
    public class Permission
    {
        [Required]
        [ScaffoldColumn(false)]
        public int PermissionId { get; set; }

        [UIHint("Permission Name")]
        public string PermissionName { get; set; }

        [UIHint("Description")]
        public string PermissionDescription { get; set; }

    }
}