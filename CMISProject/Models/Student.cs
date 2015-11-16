using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public enum Semester
    {
        I, II, III, IV, V, VI, VII, VIII
    }

    public class Student : User
    {
        [Required]
        public Semester Semester { get; set; }

        [Required]
        public string GuardianName1 { get; set; }

        [Required]
        public string GuardianAddress1 { get; set; }

        public string GuardianName2 { get; set; }

        public string GuardianAddress2 { get; set; }

        
    }
}