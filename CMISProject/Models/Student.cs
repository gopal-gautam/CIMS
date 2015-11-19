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
        [UIHint("Semester")]
        public Semester Semester { get; set; }

        [Required]
        [Display(Name= "Primary Guardian Name")]
        [UIHint("Primary Gurardian")]
        public string Guardian1Name { get; set; }

        [Required]
        [Display(Name = "Primary Guardian Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [UIHint("Primary Guardian Phone No.")]
        public long Guardian1PhoneNumber { get; set; }

        [Display(Name = "Secondary Guardian Name")]
        [UIHint("Secondary Gaurdian Name")]
        public string Guardian2Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Secondary Guardian Phone Number")]
        [UIHint("Secondary Gaurdian Phone No.")]
        public string Guardian2PhoneNumber { get; set; }

    }
}