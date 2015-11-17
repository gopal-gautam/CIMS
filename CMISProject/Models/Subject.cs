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
        [Display(Name = "Subject Name")]
        public string SubName { get; set; }

        [Required]
        // [ForeignKey("GroupId")]
        [Column("GroupId")]
        public virtual Group Group { get; set; }

        [Display(Name="Subject Teacher")]
        public int? SubTeacherId { get; set; }

        [ForeignKey("SubTeacherId")]
        public virtual User SubTeacher { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public int CreditHrs { get; set; }

        [Required]
        [Display(Name = "Primary Book")]
        public string PriBook { get; set; } 

        [Display(Name= "Reference Book1")]
        public string RefBook1 { get; set;}

        [Display(Name= "Reference Book2")]
        public string RefBook2 { get; set;}

    }
}