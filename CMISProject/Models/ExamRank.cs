using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    ///<summary>
    ///This contains the class that contains all the properties for showing overall rank of students in the exam
    ///It has following properties:
    ///ExamRankId : identifies the row to show the rank uniquely
    ///UserId : used as foreign key for student
    ///Student : represents the student whose rank is to be shown
    ///TotalMarks : represents the total marks of the student
    ///Percentage : represents the obtained % of the student
    ///Rank : represents the overall rank of student in the exam
    ///SemesterGradePointAverage : represents semester wise grade marks of student value 
    ///                             from the enum class SemesterGradePointAverage in ExamMarkSheet Model
    ///</summary>

    //public enum SemesterGradePointAverage
    //{
    //    Aplus, A, Bplus, B, Cplus, C, D, F
    //}

    public class ExamRank
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ExamRankId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Student Student { get; set; }

        [UIHint("Total Marks")]
        public int TotalMarks { get; set; }

        [UIHint("Percentage")]
        public int Percentage { get; set; }
     /* [Required]
        // // [ForeignKey("ExamMarkSheet")]
        [Column("Marks")]
        public virtual  ExamMarkSheet Marks { get; set; }
        */       

        [Required]
        [ScaffoldColumn(false)]
        [UIHint("Rank")]
        public int Rank { get; set; }

        [Required]
        [UIHint("SGPA")]
        public SemesterGradePointAverage SemesterGradePointAverage { get; set; }
    }
}