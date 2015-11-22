using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.AdminViewModels
{
    public class AdminListViewModel
    {
        [Required]
        [Display(Name = "Organization Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 50 characters")]
        [UIHint("Organization Name")]
        public string OrganizationName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Address")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        [UIHint("Logo")]
        public string LogoFile { get; set; }
    }
}