using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains the properties to represent resource in detail.
    /// All users can upload resources and only uploader and admin can remove it.
    /// It also contains 1 enum class;
    /// Type: contains the name of type of resource
    /// The properties are:
    /// ResourceName : used as primary key for the model and represents the name of resource created by the system
    /// ResourceType : represents the type of resource
    /// FileName: represents the original name of the resource at the time of upload
    /// UploadedDate: represents the date when resource is uploaded
    /// UploadedBy: represents the name of resource uploader
    /// ModifiedDate: represents the date when resource is modified
    /// ModifiedBy: represents the name of resource modifier
    /// SubjectId : used as foreign key to identify the subject to which resource is related
    /// Subject: represents the subject to which resource is related
    /// </summary>
    public enum Type
    {
        Syllabus, Question, Note, Ebook, Assignment, Image
    }
    public class Resource
    {
        //[Required]
        //[ScaffoldColumn(false)]
        //public int ResourceId { get; set; }

        //[Required]
        
        [Display(Name= "Resource Type")]
        [UIHint("Resource Type")]
        public Type? ResourceType{ get; set;}

        [Key]
        [Required]
        [Display(Name = "Resource Name")]
        [UIHint("Resource Name")]
        public string ResourceName { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public string Filename { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? UploadedDate { get; set; }

        public string UploadedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

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