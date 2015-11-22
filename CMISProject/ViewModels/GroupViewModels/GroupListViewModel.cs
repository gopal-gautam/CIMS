using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.GroupViewModels
{
    public class GroupListViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Group name must be between 2 and 30 characters")]
        [UIHint("Group Name")]
        public string GroupName { get; set; }

        [Required]
        [UIHint("Status")]
        public Status Status { get; set; }
    }
}