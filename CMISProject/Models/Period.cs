using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This cotains the class that contains all the properties to represent a period in detail. 
    /// It is added to routine to display the routine completely.
    /// It also contain 1 enum class:
    /// Mode: contains the type of break after a class if any
    /// The properties are:
    /// PeriodId: identifies the period uniquely
    /// StartTime: represents the starting time of the period
    /// EndTime: represents the period ending time
    /// TeacherUserId: used as foreign key to identify the teacher of that period
    /// Teacher: represents the teacher of that period
    /// Day: represents the day of a week on which there is period
    /// BreakRemark: represents the nature of the break
    /// </summary>
    public enum Mode
    {
        breakTime, refreshTime
    }

    public class Period
    {
        [Required]
        [ScaffoldColumn(false)]
        public int PeriodId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "HH:mm")]
        [UIHint("Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "HH:mm")]
        [UIHint("End Time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        public int TeacherUserId { get; set; }

        [ForeignKey("TeacherUserId")]
        public virtual User Teacher { get; set; }

        [Required]
        [UIHint("Day")]
        public DayOfWeek Day { get; set; }

        [DataType(DataType.MultilineText)]
        [UIHint("Break Remark")]
        public Mode BreakRemark { get; set; }
    }
}