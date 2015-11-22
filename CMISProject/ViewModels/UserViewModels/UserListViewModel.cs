using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.UserViewModels
{
    public class UserListViewModel
    {
        [Required]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters")]
        [UIHint("Name")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("Address")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        [UIHint("E-mail Id")]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        [UIHint("Upload ImgFile")]
        public string ImageFile { get; set; }
    }
}