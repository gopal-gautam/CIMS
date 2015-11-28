//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace CMISProject.Models
//{
//    /// <summary>
//    /// This contains the class that contains additional properties of student except the user property
//    /// that is unique property of students.
//    /// It contains 1 enum class:
//    /// Semester: contains names of the semesters
//    /// The properties are:
//    /// Semester: represents the semester of the student
//    /// Guardian1Name: represents the name of primary guardian
//    /// Guardian1Address: represents the address of primary guardian
//    /// Guardian2Name: represents the name of secondary guardian
//    /// Guardian2Address: represents the address of secondary guardian
//    /// </summary>
    

//    [Table("Student")]
//    public class Student : User
//    {
//        [Required]
//        [UIHint("Semester")]
//        public Semester Semester { get; set; }

//        [Required]
//        [Display(Name= "Primary Guardian Name")]
//        [UIHint("Primary Gurardian")]
//        public string Guardian1Name { get; set; }

//        [Required]
//        [Display(Name = "Primary Guardian Phone Number")]
//        [DataType(DataType.PhoneNumber)]
//        [UIHint("Primary Guardian Phone No.")]
//        public long Guardian1PhoneNumber { get; set; }

//        [Display(Name = "Secondary Guardian Name")]
//        [UIHint("Secondary Gaurdian Name")]
//        public string Guardian2Name { get; set; }

//        [DataType(DataType.PhoneNumber)]
//        [Display(Name = "Secondary Guardian Phone Number")]
//        [UIHint("Secondary Gaurdian Phone No.")]
//        public string Guardian2PhoneNumber { get; set; }

//    }
//}