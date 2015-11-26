using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the identity of admin. 
    /// Admin is the organization itself and has all the permissions to create, delete, 
    /// and modify uesrs and groups. The properties of admin are:
    /// AdminId : used to identify the admin uniquely
    /// AdminName : represents admin name for login
    /// OrganizationName : represents organization/college name that using this system
    /// Password : for admin login security
    /// DateOfEstablishment : represensts organization/college's established date
    /// CreatedDate : represents the date of admin creation.
    /// CreatedBy : represents the name of admin creator.
    /// ModifiedDate : represents the date in which admin is modified.
    /// ModifiedBy : represents the name of admin modifier.
    /// Email : represents the email address of orgranization/college.
    /// Website : represents the website of organization/college.
    /// Address : represents the address of organization/college.
    /// PhoneNumbers : represents the contact numbers of organization/college. 
    ///                 Multiple contact numbers can be added separated by commas.
    /// POBoxNumber : represents the P.O. Box number of organization/college.
    /// FaxNumber : represents the Fax number of organization/college.
    /// PanNo : represents the Pan number of organization/college.
    /// VatNo : represents the VAT number of organization/college.
    ///         organization/college may have only one of PanNo and VatNo
    /// LogoFile : represents the logo of organization/college. It is upload type.
    /// </summary>
    public class Admin
    {
        [Required]
        [ScaffoldColumn(false)]
        public int AdminId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 30 characters")]
        [UIHint("Name")]
        public string AdminName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 50 characters")]
        [UIHint("Organization Name")]
        public string OrganizationName { get; set; }

        //[Required]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        //[UIHint("First Name")]
        //public string FirstName { get; set; }
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        //[UIHint("Middle Name")]
        //public string MiddleName { get; set; }
        //[Required]
        //[UIHint("Last Name")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        //public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Date Of Establishment")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:yyyy-MM-dd}")]
        [UIHint("Established Date")]
        public DateTime DateOfEstablishment { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [UIHint("E-mail Id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [UIHint("Website URL")]
        public string Website { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Address")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [UIHint("Phone Number")]
        public string PhoneNumbers { get; set; }

        [Display (Name = "P.O.Box Number")]
        [UIHint("P.O. Box No.")]
        public string POBoxNumber { get; set; }

        [UIHint("Fax No.")]
        public string FaxNumber { get; set; }

        [UIHint("Pan No.")]
        public string PanNo { get; set; }

        [UIHint("VAT No.")]
        public string VatNo { get; set; }

        [DataType(DataType.ImageUrl)]
        [UIHint("Upload Logo File")]
        public string LogoFile { get; set; }
        
        //public Admin()
        //{
        //    CreatedDate = DateTime.Now;
        //    //ModifiedDate = DateTime.Now;
        //}
    }
}