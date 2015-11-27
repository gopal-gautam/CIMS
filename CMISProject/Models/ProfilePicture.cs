using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class ProfilePicture
    {
        [Key]
        public int UserId { get; set; }

        public string ImageFile { get; set; }
    }
}