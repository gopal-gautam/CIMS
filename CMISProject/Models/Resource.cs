using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public enum Type
    {
        Syllabus, Question, Note, Ebook, Assignment
    }
    public class Resource
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ResourceId { get; set; }

        [Required]
        [Display(Name= "ResourceType")]
        public Type Rtype{ get; set;}

        [Required]
        [Display(Name = "ResourceName")]
        public string ResName { get; set; }

        [Required]
        public string Filename { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        public virtual User UploadedBy { get; set; }

        [Required]
        // [ForeignKey("SubjectId")]
        [Column("SubjectId")]
        public virtual Subject Subject { get; set; }




    }
}