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