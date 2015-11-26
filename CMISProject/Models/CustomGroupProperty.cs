using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains the additional properties of group 
    /// that only can be created, deleted and modified by Admin. It is assigned to group by Admin.
    /// The properties of this class are:
    /// CustomGroupPropertyId : identifies the custom property of group uniquely
    /// GroupId : represents id of the group to which this property is assigned and used as foreign key for Group.
    /// Group : represents the group to which property is assigned
    /// Property : represents name of the costum property
    /// Value : holds the value of that property
    /// </summary>
    public class CustomGroupProperty
    {
        [Required]
        [ScaffoldColumn(false)]
        public int CustomGroupPropertyId { get; set; }

        //[Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        [UIHint("Property Name")]
        public string Property { get; set; }

        [Required]
        [StringLength(50, MinimumLength= 2, ErrorMessage= "Value must be between 2 & 50 characters.")]
        [DataType(DataType.MultilineText)]
        [UIHint("Value")]
        public string Value { get; set;}
    }
}