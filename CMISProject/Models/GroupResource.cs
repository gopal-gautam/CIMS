using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class GroupResource
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupResourceId { get; set; }

        [Required]
        [Display(Name = "GroupResourceId")]
        public int GrpResId { get; set; }

        [Required]
        // [ForeignKey("GroupId")]
        [Column("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        // [ForeignKey("ResourceId")]
        [Column("ResourceId")]
        public virtual Resource Resource { get; set; }

    }
}