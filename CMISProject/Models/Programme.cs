using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains properties to represent programme of the study that student chooses.
    /// Only the admin can create the programme.
    /// The properties are:
    /// ProgammeId : identifies the programme of the study assigned to student
    /// ProgrammeName: represents the name of the programme that student studies
    /// </summary>
    public class Programme
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ProgrammeId { get; set; }

        [Required]
        [UIHint("Programme Name")]
        public string ProgrammeName { get; set; }
    }
}