using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMISProject.Models
{
    public enum MessageType
    {
        NormalMsg, ReplyMsg, Notice /*, Comment */, Complaint, Suggestion, Event, TeacherHelp, Proposal
    }
    public enum React
    {
        Like, Unlike
    }
    public enum MessageMode
    {
        ReadOnly, ReadLikeDislike, ReadLikeDislikeReplyComment, Deny
    }
    public class Message
    {
        [Required]
        [Display(Name="MessageId")]
        [ScaffoldColumn(false)]
        public int MessageId { get; set; }


        [Required]
        [Display(Name="MessageType")]
        public MessageType MessageType { get; set; }

        [Required]
        [Display(Name="Message")]
        public string  Msg { get; set; }

        [Required]
        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set;}

        public string Attachment { get; set; }

        /*
        [Required]
        // [ForeignKey("User")]
        [Column("UserId")]
        public virtual User ReceivedBy { get; set; }

        [Required]
        public DateTime RecievedDate { get; set; }
        */
        public React React { get; set; }

        [Required]
        public MessageMode Mode { get; set; }

    }
}