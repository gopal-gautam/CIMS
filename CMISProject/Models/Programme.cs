using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class Programme
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ProgrammeId { get; set; }

        [Required]
        public string ProgrammeName { get; set; }
    }
}