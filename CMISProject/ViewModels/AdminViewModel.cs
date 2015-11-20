using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        [Display(Name="Admin Username")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 30 characters")]
        [UIHint("Name")]
        public string AdminName { get; set; }

        [Required]
        [Display(Name= "Organization Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 50 characters")]
        [UIHint("Organization Name")]
        public string OrganizationName { get; set; }

        //[Required]
        //[Display(Name = "First Name")]
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
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage="Password must have atleat 1 uppercase, 1 lowercase, 1 number or special character and at least 8 characters")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Date Of Establishment")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [UIHint("Established Date")]
        public DateTime DateOfEstablishment { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required]
        [Display(Name= "Modified Date")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [Display(Name = "Modified By")]
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
        public virtual ICollection<string> PhoneNumber { get; set; }

        [Display(Name = "P.O.Box Number")]
        [UIHint("P.O. Box No.")]
        public string POBoxNumber { get; set; }

        [UIHint("Fax No.")]
        public string FaxNumber { get; set; }

        [UIHint("Pan No.")]
        public string PanNo { get; set; }

        [UIHint("VAT No.")]
        public string VatNo { get; set; }

        [DataType(DataType.Upload)]
        [UIHint("Upload Logo File")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}