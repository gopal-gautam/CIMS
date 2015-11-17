using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(30, MinimumLength= 8, ErrorMessage="Password should be more than 8 character and less than 30 characters")]
        public string Psswd { get; set; }
        
        [Required]
        [Display(Name="Group Name")]
        [StringLength(30, MinimumLength= 2, ErrorMessage= "Group name must be between 2 and 30 characters")]
        public string GroupName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public string CreatedBy { get; set; }
        
        [StringLength(30, MinimumLength= 2, ErrorMessage="SubgroupName must be between 2 and 30 characters")]
        public string Subgroup { get; set; }
        
        [Required]
        public Status Status { get; set; } 
         
    }
}