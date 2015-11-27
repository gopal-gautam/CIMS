using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    ///<summary>
    ///This contains the class that contains all the properties that need to be in the exam marksheet of students.
    ///It also contains 2 enum classes:
    ///SemesterGradePointAverage: contains all grade names that are given to represent average marks of student in one semester
    ///ExamType: contains names of all types of exam that took place in organization/college for students
    ///It is the result published to each student.
    ///This contains following properties:
    ///ExamMarkSheetId: identifies the Exam mark sheet of each students uniquely
    ///UserId : represents foreign key for student that is the id of the student to whom this mark sheet is assigned
    ///Student : represents the student to whom this mark sheed is assigned
    ///SubjectId : represents foreign key for the subject that is id of the subject whose marks is to be shown
    ///Subject : represents the subject whose marks is to be shown
    ///Marks : represents marks of one subject
    ///ExamType : represents type of the exam whose mark sheet is to be shown
    ///FullMarks : represents full marks of the exam
    ///Passmarks : represents pass marks of the exam
    ///ExamDate : represents the date of examination
    ///SubjectRank : represents rank in each subject
    ///Semester : represents the semester of the students. Semester is represented by enum class in Student Model
    ///SemesterGradePointAverage : represents the semester wise average of a student 
    ///</summary>
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
        public virtual User Student { get; set; }

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