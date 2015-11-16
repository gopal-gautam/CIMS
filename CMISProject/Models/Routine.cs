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
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        // [ForeignKey("GroupId")]
        [Column("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User User { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }
        
        public Mode BreakRemark { get; set; }

    }
}