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
        public TimeSpan StartTime { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "HH:mm")]
        public TimeSpan EndTime { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }
        
        [DataType(DataType.MultilineText)]
        public Mode BreakRemark { get; set; }

    }
}