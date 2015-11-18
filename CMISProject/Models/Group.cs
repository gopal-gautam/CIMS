using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public enum Status
    {
        active, inactive
    }
    public class Group
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupId { get; set; }

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength= 8, ErrorMessage="Password should be more than 8 character and less than 30 characters")]
        public string Password { get; set; }
        
        [Required]
        [Display(Name="Name")]
        [StringLength(30, MinimumLength= 2, ErrorMessage= "Group name must be between 2 and 30 characters")]
        public string GroupName { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        
        [StringLength(30, MinimumLength= 2, ErrorMessage="SubgroupName must be between 2 and 30 characters")]
        public string Subgroup { get; set; }
        
        [Required]
        public Status Status { get; set; }

        public Group()
        {
            CreatedDate = DateTime.Now;
        }
         
    }
}