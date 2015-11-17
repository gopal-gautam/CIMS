using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class Admin
    {
        [Required]
        [ScaffoldColumn(false)]
        public int AdminId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "AdminName must be between 2 and 30 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "DateOfEstablishment")]
        public string DateOfEstablishment { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public long PhoneNumber1 { get; set; }
        
        public long PhoneNumber2 { get; set; }
        
        public long PhoneNumber3 { get; set; }

        [Required]
        [Display (Name = "P.O.BoxNumber")]
        public string POBoxNumber { get; set; }

        public string FaxNumber { get; set; }

        public string PanNo { get; set; }

        public string VatNo { get; set; }

        public string LogoFile { get; set; }
                            
    }
}