using CMISProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMISProject.ViewModels.MessageViewModels
{
    public class SendMessageViewModel
    {
        [Required]
        [Display(Name = "MessageType")]
        [UIHint("Message Type")]
        public MessageType MessageType { get; set; }

        [Required]
        [Display(Name = "Message")]
        [UIHint("Enter Message")]
        [DataType(DataType.MultilineText)]
        [UIHint("Message")]
        public string Msg { get; set; }

        [DataType(DataType.Upload)]
        [UIHint("Upload File")]
        public HttpPostedFileBase Attachment { get; set; }

        public React React { get; set; }

        [Required]
        [UIHint("Message Mode")]
        public MessageMode Mode { get; set; }

        //public GroupMessage groupMessage { get; set; }
        public UserMessage userMessage { get; set; }

    }
    public class GroupMessageViewModel
    {
        [Required]
        [Display(Name = "MessageType")]
        [UIHint("Message Type")]
        public MessageType MessageType { get; set; }

        [Required]
        [Display(Name = "Message")]
        [UIHint("Enter Message")]
        [DataType(DataType.MultilineText)]
        [UIHint("Message")]
        public string Msg { get; set; }

        [DataType(DataType.Upload)]
        [UIHint("Upload File")]
        public HttpPostedFileBase Attachment { get; set; }

        public React React { get; set; }

        [Required]
        [UIHint("Message Mode")]
        public MessageMode Mode { get; set; }

        public GroupMessage groupMessage { get; set; }
    }
}
