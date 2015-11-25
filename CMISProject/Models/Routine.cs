using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    public enum Mode
    {
        breakTime, refreshTime
    }
    public class Routine
    {
        [Required]
        [ScaffoldColumn(false)]
        public int RoutineId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="HH:mm")]
        [UIHint("Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "HH:mm")]
        [UIHint("End Time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }

        public string IssuedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [UIHint("Day")]
        public DayOfWeek Day { get; set; }
        
        [DataType(DataType.MultilineText)]
        [UIHint("Break Remark")]
        public Mode BreakRemark { get; set; }

        //public Routine()
        //{
        //    IssuedDate = DateTime.Now;
        //}

    }
}