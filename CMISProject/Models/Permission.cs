using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace CMISProject.Models
{
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