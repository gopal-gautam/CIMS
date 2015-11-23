using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{

    public enum React
    {
        Like, Dislike,
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