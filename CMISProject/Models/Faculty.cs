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
        public string FacultyName { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User FacultyHead { get; set; }


    }
}