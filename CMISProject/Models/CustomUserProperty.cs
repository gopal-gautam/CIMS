using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class CustomUserProperty
    {
        [Required]
        [ScaffoldColumn(false)]
        public int CustomUserPropertyId { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [UIHint("Property Name")]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value must be between 2 & 50 characters.")]
        [UIHint("Value")]
        public string Value { get; set; }
    }
}