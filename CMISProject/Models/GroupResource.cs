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
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public string ResourceName { get; set; }

        [ForeignKey("ResourceName")]
        public virtual Resource Resource { get; set; }

    }
}