using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    ///  This class contains the additional properties of user 
    /// that only can be created, deleted and modified by Admin. It is assigned to user by Admin.
    /// The properties of this class are:
    /// CustomUserPropertyId : identifies the custom property of group uniquely
    /// UserId : represents id of the user to which this property is assigned and used as foreign key for User.
    /// User : represents the user to which property is assigned
    /// Property : represents name of the costum property
    /// Value : holds the value of that property
    /// </summary>
    public class CustomUserProperty
    {
        
        [Required]
        [ScaffoldColumn(false)]
        public int CustomUserPropertyId { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [UIHint("Property Name")]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Value must be between 2 & 50 characters.")]
        [UIHint("Value")]
        public string Value { get; set; }
    }
}