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
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value must be between 2 & 50 characters.")]
        public string Value { get; set; }
    }
}