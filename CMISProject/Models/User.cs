using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMISProject.Models
{
    public enum UserType
    {
        Staff, Student
    }
    public enum Sex
    {
        Male, Female, Other
    }
    public class User
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 20 characters")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Middle Name must be between 2 and 20 characters")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 20 characters")]
        public string LastName { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User CreatedBy { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        
        public string Email { get; set; }
        
        [Required]
        public string Address { get; set; }

        public virtual ICollection<string> PhoneNumber { get; set; }
        
        [Required]
        public Sex Sex { get; set; }

        [Required]
        [Display(Name="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Nationality { get; set; }

        public string ImageFile { get; set; }

        public string BloodGroup { get; set; }

        public string CitizenShipNumber { get; set; }

    }
}