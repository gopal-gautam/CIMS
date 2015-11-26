using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains the properties to represent resource in detail.
    /// All assigned users can view the routine.
    /// The properties are:
    /// RoutineId: identifies the routine uniquely
    /// IssuedDate: represents the date when routine is issued
    /// IssuedBy: represents the name of the user who issued the routine
    /// ModifiedDate: represents the date when routine is modified
    /// ModifiedBy: represents the name of the user who modified the routine
    /// Periods: gets all the properties values to include in the routine
    /// GroupId: used as foreign key to identify the group to which routine is assigned
    /// Gorup: represents the group to which routine is assigned
    /// </summary>
    public class Routine
    {
        [Required]
        [ScaffoldColumn(false)]
        public int RoutineId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssuedDate { get; set; }

        public string IssuedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<Period> Periods { get; set;}

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

    }
}