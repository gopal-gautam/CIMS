using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CMISProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;



///<summary>
///
///</summary>
namespace CMISProject.Models
{
    public enum BloodGroup
    {
        APositive, ANegative, BPositive, BNegative, ABPositive, ABNegative, OPositive, ONegative
    }
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
        [UIHint("Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 20 characters")]
        [UIHint("First Name")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Middle Name must be between 2 and 20 characters")]
        [UIHint("Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 20 characters")]
        [UIHint("Last Name")]
        public string LastName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        //[Required]
        //public int GroupId { get; set; }

        //[ForeignKey("GroupId")]
        //public virtual Group Group { get; set; }

        [DataType(DataType.EmailAddress)]
        [UIHint("E-mail Id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Address")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [UIHint("Phone No.")]
        public string PhoneNumber { get; set; }

        [Required]
        [UIHint("Sex")]
        public Sex Sex { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [UIHint("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [UIHint("Nationality")]
        public string Nationality { get; set; }

        [Required]
        [UIHint("Religion")]
        public string Religion { get; set; }


        [DataType(DataType.Upload)]
        [UIHint("Upload ImgFile")]
        public string ImageFile { get; set; }

        [UIHint("Blood Group")]
        public BloodGroup BloodGroup { get; set; }

        [UIHint("Citizenship No.")]
        public string CitizenShipNumber { get; set; }


        //public User()
        //{
        //    CreatedDate = DateTime.Now;
        //    //ModifiedDate = DateTime.Now;
        //}

        //public class ApplicationDbContext : IdentityDbContext<User>
        //{
        //    public ApplicationDbContext()
        //        : base("DefaultConnection")
        //    {

        //    }
        //}

    }
}