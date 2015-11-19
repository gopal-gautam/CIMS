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
        public string SubjectName { get; set; }

        [Required]
        public int GroupId { get; set; }
        
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        [Display(Name="Subject Teacher")]
        public int SubjectTeacherId { get; set; }

        [ForeignKey("SubjectTeacherId")]
        public virtual User SubjectTeacher { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        [UIHint("Credit Hours")]
        public int CreditHours { get; set; }

        [Required]
        [Display(Name = "Primary Book")]
        [UIHint("Primary Book")]
        public string PrimaryBook { get; set; } 

        [Display(Name= "Reference Book1")]
        [UIHint("Reference Book1")]
        public string ReferenceBook1 { get; set;}

        [Display(Name= "Reference Book2")]
        [UIHint("Reference Book2")]
        public string ReferenceBook2 { get; set;}

    }
}