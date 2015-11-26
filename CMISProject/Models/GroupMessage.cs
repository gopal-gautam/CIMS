using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the message assigned to group. 
    /// All members of the group can view and interact the message but only the message creator can delete/modify the message
    /// The properties are:
    /// GroupMessageId: identifies the group message uniquely
    /// GroupId : used as foreign key to identify the group to which the message is assigned
    /// Group: represents the group to which the message is assigned
    /// MessageId : used as foreign key to identify the message to be assigned
    /// Message: represents the message to be assigned.
    /// </summary>
    public class GroupMessage
    {
        [Required]
        [ScaffoldColumn(false)]
        public int GroupMessageId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [Required]
        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Messsage { get; set; }


    }

}