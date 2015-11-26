using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains class that contains all the properties to hold the message assigned to user. 
    /// Only the assigned user can view and interact the message but only the message creator can delete/modify the message
    /// The properties are:
    /// UserMessageId: identifies the user message uniquely
    /// UserId : used as foreign key to identify the user to which the message is assigned
    /// User: represents the user to which the message is assigned
    /// MessageId : used as foreign key to identify the message to be assigned
    /// Message: represents the message to be assigned.
    /// </summary>
    public class UserMessage
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserMessageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Messsage { get; set; }

    }
}