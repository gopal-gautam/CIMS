using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CMISProject.Models
{
    /// <summary>
    /// This contains the class that contains all the properties to represent the message. 
    /// All users can create the message and only creator can delete/modify the message.
    /// It also contains 2 enum classes:
    /// MessageType: contains all the names that represents the type of the message
    /// MessageMode: contains all the message that is in readonly or readlikeDislike or any other modes
    /// The properties are:
    /// MessageId: identifies the message uniquely
    /// MessageType: represents the type of the message, either the message is normal message or notice or so on
    /// Msg: represents the message contents
    /// CreatedDate : represents the date of message creation.
    /// CreatedBy : represents the name of message creator.
    /// ModifiedDate : represents the date in which message is modified.
    /// ModifiedBy : represents the name of message modifier.
    /// Attachment: contains the attached document with message which is taken as resource
    /// Mode: represents the mode of the message either the message is readonly or so on.
    /// </summary>
    public enum MessageType
    {
        NormalMsg, ReplyMsg, Notice /*, Comment */, Complaint, Suggestion, Event, TeacherHelp, Proposal
    }
    //public enum React
    //{
    //    Like, Unlike
    //}
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

        public string CreatedBy { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        [ReadOnly(true)]
        public DateTime? CreatedDate { get; set;}

        //[Required]
        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [DataType(DataType.Upload)]
        [UIHint("Upload File")]
        public Resource Attachment { get; set; }


        /*
        [Required]
        // [ForeignKey("User")]
        [Column("UserId")]
        public virtual User ReceivedBy { get; set; }

        [Required]
        public DateTime RecievedDate { get; set; }
        */
        //public React React { get; set; }

        [Required]
        [UIHint("Message Mode")]
        public MessageMode Mode { get; set; }

        //public Message()
        //{
        //    CreatedDate = DateTime.Now;
        //    //ModifiedDate = DateTime.Now;
        //}
    }
}