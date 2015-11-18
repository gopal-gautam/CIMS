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
        public string AdminName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 20 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Date Of Establishment")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="YYYY-MM-dd")]
        public DateTime DateOfEstablishment { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual ICollection<string> PhoneNumber { get; set; }

        [Display (Name = "P.O.BoxNumber")]
        public string POBoxNumber { get; set; }

        public string FaxNumber { get; set; }

        public string PanNo { get; set; }

        public string VatNo { get; set; }

        [DataType(DataType.Upload)]
        public string LogoFile { get; set; }
                            
    }
}