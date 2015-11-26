using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains all the properties to represent an inactive user.
    /// Admin adds user to inactive when they are out of the organization/college family due to some reason or passed out.
    /// The properties are:
    /// InactiveUserId: identifies the inactive user uniquely.
    /// InactivatedBy: represents the user who inactivated the user
    /// InactivatedDate: 
    /// </summary>
    public class InactiveUser
    {
        [Required]
        [ScaffoldColumn(false)]
        public int InactiveUserId { get; set; }

        public string InactivatedBy { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="YYYY-MM-dd")]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        [UIHint("Inactive Date")]
        public DateTime InactivatedDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Reason for Inactivation")]
        public string Reason { get; set; }

        //public InactiveUser()
        //{
        //    InactivedDate = DateTime.Now;
        //}
    }
}