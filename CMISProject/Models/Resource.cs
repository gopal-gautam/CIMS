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
        //[Required]
        //[ScaffoldColumn(false)]
        //public int ResourceId { get; set; }

        //[Required]
        [Key]
        [Display(Name= "Resource Type")]
        [UIHint("Resource Type")]
        public Type? ResourceType{ get; set;}

        [Required]
        [Display(Name = "Resource Name")]
        [UIHint("Resource Name")]
        public string ResourceName { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string Filename { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UploadedDate { get; set; }

        public string UploadedBy { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        //[Required]
        public int? SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        //public Resource()
        //{
        //    UploadedDate = DateTime.Now;
        //    //ModifiedDate = DateTime.Now;
        //}
    }
}