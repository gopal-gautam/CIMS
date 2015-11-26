using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    
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