using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains the properties that saves the reaction from the user. 
    /// Anyone who is assigned to the message can interact as per the message type and mode.
    /// It also contains one enum class:
    /// React: contains name of the reaction
    /// The properties are:
    /// Id: identifies the message uniquely
    /// MessageId: used as foreign key to identify the message which is reacted
    /// Message: represents the message which is reacted
    /// UserId: used as foreign key to identify the user who reacted
    /// User: represents the user who reacted
    /// React: represents the type of react
    /// </summary>
    public enum React
    {
        Like, Dislike
    }
    public class MessageReaction
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        [ForeignKey("MessageId")]
        public Message Message { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public React React { get; set; }
    }
}