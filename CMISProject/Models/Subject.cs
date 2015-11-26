using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains all the properties to represent subject. Subject is assigned to students.
    /// The properties are:
    /// SubjectId: identifies the subject uniquely
    /// SubjectName: represents the name of the subject
    /// GroupId: used as foreign key to identify the group to which the subject is assigned
    /// Group: represents the group to which thesubject is assigned
    /// SubjectTeacherId: used as foreign key to identify the teacher assigned to that subject
    /// SubjectTeacher: represents the teacher assigned to that subject
    /// CreditHours: represents the credit of the subject gived by the university
    /// PrimaryBook: represents the primary course book of the subject
    /// ReferenceBook1: represents the reference book first of  the subject
    /// ReferenceBook2: represents the reference book second fo the subject
    /// </summary>
    public class Subject
    {
        [Required]
        [ScaffoldColumn(false)]
        public int SubjectId { get; set; }

        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        //[Required]
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