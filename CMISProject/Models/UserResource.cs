using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class UserResource
    {
        [Required]
        [Display(Name = "UserResourceId")]
        [ScaffoldColumn(false)]
        public int UserResourceId { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User User { get; set; }

        [Required]
        // [ForeignKey("ResourceId")]
        [Column("ResourceId")]
        public virtual Resource Resource { get; set; }
    }
}