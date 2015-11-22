using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

///<Summary>
///This namespace includes all the properties of Subject Model that need to be shown as brief view of Subject.
///</Summary>
namespace CMISProject.ViewModels.SubjectViewModels
{
    public class SubjectListViewModel
    {
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        [UIHint("Credit Hours")]
        public int CreditHours { get; set; }

        [ForeignKey("SubjectTeacherId")]
        public User SubjectTeacher { get; set; }
    }
}