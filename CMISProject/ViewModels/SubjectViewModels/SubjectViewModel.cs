using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.SubjectViewModels
{
    public class SubjectViewModel
    {
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        //[Required]
        //public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        //[Required]
        //[Display(Name = "Subject Teacher")]
        //public int SubjectTeacherId { get; set; }

        [ForeignKey("SubjectTeacherId")]
        public User SubjectTeacher { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        [UIHint("Credit Hours")]
        public int CreditHours { get; set; }

        [Required]
        [Display(Name = "Primary Book")]
        [UIHint("Book")]
        public string PrimaryBook { get; set; }

        [Display(Name = "Reference Book1")]
        [UIHint("Book")]
        public string ReferenceBook1 { get; set; }

        [Display(Name = "Reference Book2")]
        [UIHint("Book")]
        public string ReferenceBook2 { get; set; }
    }
}