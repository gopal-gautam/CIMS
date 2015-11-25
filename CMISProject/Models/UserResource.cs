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