using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    public class UserPermission
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserPermissionId { get; set; }
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User User { get; set; }

        // [ForeignKey("PermissionId")]
        [Column("Permission")]
        public virtual Permission Permission { get; set; }

    }
}