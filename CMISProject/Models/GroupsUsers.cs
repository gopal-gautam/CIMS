using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to show the relationship of the group and user. 
    /// It shows which user is assigned to which group.
    /// The properties are:
    /// Id: identifies the groups users relation uniquely
    /// GroupId : used as foreign key that identifies the group
    /// Group : represents the group
    /// UserId : used as foreign key that identifies the user
    /// User : represents the user.
    /// </summary>
    public class GroupsUsers
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        [Required]
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
