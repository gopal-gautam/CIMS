using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class GroupPermission
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupPermissionId { get; set; }

        // [ForeignKey("GroupId")]
        [Column("GroupId")]
        public virtual Group Group { get; set; }

        // [ForeignKey("PermissionId")]
        public virtual Permission Permission { get; set; }

    }
}