using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class Faculty
    {
        [Required]
        [ScaffoldColumn(false)]
        public int FacultyId { get; set; }

        [Required]
        [UIHint("Faculty Name")]
        public string FacultyName { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User FacultyHead { get; set; }


    }
}