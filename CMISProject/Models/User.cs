using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CMISProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;




namespace CMISProject.Models
{
    ///<summary>
    ///This contains the class that contains all the properties of User that represents the users.
    ///Users are created by Admin only and as per permissions other users also can create users in some scenario
    ///It also contains 2 enum classes:
    ///BloodGroup: represents the names of blood groups of user
    ///Sex: represents the gender of the user
    ///The properties are:
    ///UserId:identifies the user uniquely
    ///UserName: represents login name of the user
    ///Password:  represents the password to log into the system
    ///FirstName: represents the First name of the user
    ///MiddleName: represents the Middle name of the user
    ///LastName: represents the Last or family name of the user
    ///CreatedDate : represents the date when user is created.
    /// CreatedBy : represents the name of user creator.
    /// ModifiedDate : represents the date in which user is modified.
    /// ModifiedBy : represents the name of user modifier.
    /// Email: represents the email address of user
    /// PhoneNumber: represents the contact number of user and 
    ///                 for multiple phone numbers,user can separate the numbers with comma
    /// Sex: represents the gender of the user
    /// DateOfBirth: represents the birth date of the user
    /// Nationality: represents the nation to which user belongs
    /// BloodGroup: represents the blood group named of the user
    /// CitizenShipNumber: represents the citizenship number of the user
    ///</summary>
    public enum BloodGroup
    {
        APositive, ANegative, BPositive, BNegative, ABPositive, ABNegative, OPositive, ONegative
    }
    public enum UserType
    {
       Student, Teacher, Staff
    }
    public enum Sex
    {
        Male, Female, Other
    }

    public enum Semester
    {
        I, II, III, IV, V, VI, VII, VIII
    }

    [Table("User")]
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        //[ScaffoldColumn(false)]
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
        public DateTime? CreatedDate { get; set; }

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

        [Required]
        [UIHint("Semester")]
        public Semester Semester { get; set; }

        [Required]
        [Display(Name = "Primary Guardian Name")]
        [UIHint("Primary Gurardian")]
        public string Guardian1Name { get; set; }

        [Required]
        [Display(Name = "Primary Guardian Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [UIHint("Primary Guardian Phone No.")]
        public long Guardian1PhoneNumber { get; set; }

        [Display(Name = "Secondary Guardian Name")]
        [UIHint("Secondary Gaurdian Name")]
        public string Guardian2Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Secondary Guardian Phone Number")]
        [UIHint("Secondary Gaurdian Phone No.")]
        public string Guardian2PhoneNumber { get; set; }

        [Required]
        [Display(Name="Type of User")]
        [UIHint("Type")]
        public UserType Type { get; set; } 
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