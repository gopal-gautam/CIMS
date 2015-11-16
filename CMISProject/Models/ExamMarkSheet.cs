using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    //public enum Semester
    //{
    //    I, II, III, IV, V, VI, VII, VIII
    //}

    public enum SGPA
    {
        Aplus, A, Bplus, B, Cplus, C, D, F
    }

    public enum ExamType
    {
        Board, PreBoard, MidTerm, FirstTerm, SecondTerm, ThirdTerm, ClassTest, UnitTest, SurpriseTest, Other
    }
    public class ExamMarkSheet
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ExamMarkSheetId { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual Student Student { get; set; }

        [Required]
        // [ForeignKey("SubjectId")]
        [Column("SubjectId")]
        public virtual Subject Subject { get; set; }

        [Required]
        public int Marks { get; set; }

        [Required]
        public string ExamType { get; set; }

        [Required]
        public int FullMarks { get; set; }

        [Required]
        public int PassMarks { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public int SubjectRank { get; set; }

        [Required]
        public Semester Semester { get; set; }

        public SGPA SGPA { get; set; }


    }
}