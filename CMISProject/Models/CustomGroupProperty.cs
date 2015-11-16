using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class CustomGroupProperty
    {
        [Required]
        [ScaffoldColumn(false)]
        public int CustomGroupPropertyId { get; set; }

        [Required]
        // [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength= 2, ErrorMessage= "Value must be between 2 & 50 characters.")]
        public string Value { get; set;}
    }
}