using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels
{
    public class CustomGroupPropertyViewModel
    {
        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        [UIHint("Property Name")]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value must be between 2 & 50 characters.")]
        [DataType(DataType.MultilineText)]
        [UIHint("Value")]
        public string Value { get; set; }
    }
}