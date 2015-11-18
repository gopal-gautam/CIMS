using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name= "Resource Type")]
        public Type ResourceType{ get; set;}

        [Required]
        [Display(Name = "Resource Name")]
        public string ResourceName { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string Filename { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UploadedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ReadOnly(true)]
        public virtual User UploadedBy { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public Resource()
        {
            UploadedDate = DateTime.Now;
        }
    }
}