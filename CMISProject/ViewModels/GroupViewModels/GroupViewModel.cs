using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.ViewModels
{
    //public enum Status
    //{
    //    active, inactive
    //}

    public class GroupViewModel
    {
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage="Password must have atleat 1 uppercase, 1 lowercase, 1 number or special character and at least 8 characters)")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required]
        [Remote("doesGroupNameExist", "Group", ErrorMessage= "This groupName is not valid. Please enter another groupName.")]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Group name must be between 2 and 30 characters")]
        [UIHint("Group Name")]
        public string GroupName { get; set; }

        //[Required]
        //[ScaffoldColumn(false)]
        //[DataType(DataType.DateTime)]
        //[UIHint("Date")]
        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[UIHint("Created By")]
        //public string CreatedBy { get; set; }

        //[DataType(DataType.DateTime)]
        //[UIHint("Date")]
        //public DateTime ModifiedDate { get; set; }

        //[UIHint("Modified By")]
        //public string ModifiedBy { get; set; }

        [Required]
        [UIHint("Status")]
        public Status Status { get; set; }
    }

    public class ChangeStatusViewModel
    {
        public string GroupName { get; set; }
        public Status Status { get; set; }
    }
}