﻿using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMISProject.ViewModels
{
    //public enum BloodGroup
    //{
    //    APositive, ANegative, BPositive, BNegative, ABPositive, ABNegative, OPositive, ONegative
    //}
    //public enum UserType
    //{
    //    Staff, Student
    //}
    //public enum Sex
    //{
    //    Male, Female, Other
    //}

    public class UserViewModel
    {
        [Required]
        [Remote("doesUserNameExist", "User", ErrorMessage="This username is not available. Please use another username.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 30 characters")]
        [UIHint("Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage="Password must have atleat 1 uppercase, 1 lowercase, 1 number or special character and at least 8 characters)")]
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

        //[Required]
        //[UIHint("Date")]
        //public DateTime CreatedDate { get; set; }

        //[Required]
        //[UIHint("Created By")]
        //public string CreatedBy { get; set; }

        //[DataType(DataType.DateTime)]
        //[UIHint("Date")]
        //public DateTime ModifiedDate { get; set; }

        //[UIHint("Date")]
        //public string ModifiedBy { get; set; }

        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
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
        public HttpPostedFileBase ImageFile { get; set; }

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
        [Display(Name = "Type of User")]
        [UIHint("Type")]
        public UserType Type { get; set; } 
    }
}