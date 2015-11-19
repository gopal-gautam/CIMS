using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class InactiveUser
    {
        [Required]
        [ScaffoldColumn(false)]
        public int InactiveUserId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="YYYY-MM-dd")]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        [UIHint("Inactive Date")]
        public string InactiveDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Reason for Inactivation")]
        public string Reason { get; set; }
    }
}