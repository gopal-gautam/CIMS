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
        [Column("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string InactiveDate { get; set; }

        [Required]
        public string Reason { get; set; }
    }
}