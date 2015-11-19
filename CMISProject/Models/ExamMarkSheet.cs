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

    public enum SemesterGradePointAverage
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
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Student Student { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [Required]
        [UIHint("Obtained Marks")]
        public int Marks { get; set; }

        [Required]
        [UIHint("Exam Type")]
        public ExamType ExamType { get; set; }

        [Required]
        public int FullMarks { get; set; }

        [Required]
        public int PassMarks { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [UIHint("Exam Date & Time")]
        public DateTime ExamDate { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [UIHint("Subject Rank")]
        public int SubjectRank { get; set; }

        [Required]
        [UIHint("Semester")]
        public Semester Semester { get; set; }

        [UIHint("SGPA")]
        public SemesterGradePointAverage SemesterGradePointAverage { get; set; }

    }
}