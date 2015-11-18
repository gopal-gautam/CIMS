using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
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

        public int Percentage { get; set; }

        public int TotalMarks { get; set; }

     /* [Required]
        // // [ForeignKey("ExamMarkSheet")]
        [Column("Marks")]
        public virtual  ExamMarkSheet Marks { get; set; }
        */       

        [Required]
        [ScaffoldColumn(false)]
        public int Rank { get; set; }

        [Required]
        public SemesterGradePointAverage SemesterGradePointAverage { get; set; }
    }
}