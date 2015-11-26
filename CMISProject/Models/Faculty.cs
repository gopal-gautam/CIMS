using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains all the properties needed to represent faculty 
    /// which can only be created/modified/deleted by Admin.
    /// It contains following properties:
    /// FacultyId : identifies the faculty uniquely
    /// FacultyName : represents the name of the faculty
    /// FacultyHeadId : represents foreign key for user who is head of the faculty
    /// FacultyHead : represents the head of the faculty
    /// </summary>
    public class Faculty
    {
        [Required]
        [ScaffoldColumn(false)]
        public int FacultyId { get; set; }

        [Required]
        [UIHint("Faculty Name")]
        public string FacultyName { get; set; }

        //[Required]
        public int FacultyHeadId { get; set; }

        [ForeignKey("FacultyHeadId")]
        public virtual User FacultyHead { get; set; }


    }
}