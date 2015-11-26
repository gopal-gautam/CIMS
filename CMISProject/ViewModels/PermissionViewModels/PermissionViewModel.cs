using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.PermissionViewModels
{
    public class PermissionViewModel
    {
        [Display(Name="Permission Name")]
        public string PermissionName { get; set; }

        [Display(Name="Description")]
        public string PermissionDescription { get; set; }
    }
}