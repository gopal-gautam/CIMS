using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.ViewModels.UserViewModels
{
    public class UserProfileViewModel
    {
        [Required]
        [Display(Name="Username")]
        [Remote("doesUserNameExist", "User", ErrorMessage = "This username is not available. Please use another username.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        [UIHint("Username")]
        public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must have atleat 1 uppercase, 1 lowercase, 1 number or special character and at least 8 characters)")]
        //[StringLength(30, MinimumLength = 8, ErrorMessage = "Password should be more than 8 character and less than 30 characters")]
        //[UIHint("Password")]
        //public string Password { get; set; }

        [Required]
        [Display(Name="First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 20 characters")]
        [UIHint("Middle Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Middle Name must be between 2 and 20 characters")]
        [UIHint("Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name="Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 20 characters")]
        [UIHint("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        [UIHint("E-mail Id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Address")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
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
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name="Blood Group")]
        [UIHint("Blood Group")]
        public BloodGroup BloodGroup { get; set; }

        [Display(Name="Citizenship Number")]
        [UIHint("Citizenship No.")]
        public string CitizenShipNumber { get; set; }

    }
}