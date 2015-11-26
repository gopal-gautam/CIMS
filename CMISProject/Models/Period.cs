using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
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