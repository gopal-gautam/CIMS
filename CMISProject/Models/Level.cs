using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains properties to represent level of the student.
    /// Only the admin can create the level.
    /// The properties are:
    /// LevelId : identifies the level of the study assigned to student
    /// Year: represents the number of the year of study period of student
    /// </summary>
    public class Level
    {
        [Required]
        [ScaffoldColumn(false)]
        public int LevelId { get; set; }

        [Required]
        [UIHint("No. of Year")]
        public string Year { get; set; }

    }
}