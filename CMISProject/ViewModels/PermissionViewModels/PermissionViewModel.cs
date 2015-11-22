using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.PermissionViewModels
{
    public class PermissionViewModel
    {
        [UIHint("Permission Name")]
        public string Perm { get; set; }
    }
}