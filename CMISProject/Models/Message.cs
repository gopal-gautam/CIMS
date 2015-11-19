using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [UIHint("Message Type")]
        public MessageType MessageType { get; set; }

        [Required]
        [Display(Name="Message")]
        [UIHint("Enter Message")]
        [DataType(DataType.MultilineText)]
        [UIHint("Message")]
        public string  Msg { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [ScaffoldColumn(false)]
        public virtual User CreatedBy { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [ReadOnly(true)]
        public DateTime CreatedDate { get; set;}

        [DataType(DataType.Upload)]
        [UIHint("Upload File")]
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
        [UIHint("Message Mode")]
        public MessageMode Mode { get; set; }

        public Message()
        {
            CreatedDate = DateTime.Now;
        }
    }
}