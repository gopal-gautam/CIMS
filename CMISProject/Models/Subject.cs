using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class Subject
    {
        [Required]
        [ScaffoldColumn(false)]
        public int SubjectId { get; set; }

        [Required]
        [Display(Name = "SubjectName")]
        public string SubName { get; set; }

        [Required]
        // [ForeignKey("GroupId")]
        [Column("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Display(Name="SubjectTeacher")]
        public virtual User SubTeacher { get; set; }

        [Required]
        [Display(Name = "CreditHours")]
        public int CreditHrs { get; set; }

        [Required]
        [Display(Name = "PrimaryBook")]
        public string PriBook { get; set; } 

        [Display(Name= "ReferenceBook1")]
        public string RefBook1 { get; set;}

        [Display(Name= "ReferenceBook2")]
        public string RefBook2 { get; set;}

    }
}