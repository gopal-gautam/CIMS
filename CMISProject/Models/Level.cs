using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class Level
    {
        [Required]
        [ScaffoldColumn(false)]
        public int LevelId { get; set; }

        [Required]
        public string Year { get; set; }

    }
}