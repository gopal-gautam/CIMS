using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMISProject.Models
{
    public class UserMessage
    {
        [Required]
        [ScaffoldColumn(false)]
        public int UserMessageId { get; set; }

        // [ForeignKey("UserId")]
        [Column("UserId")]
        public virtual User User { get; set; }

        // [ForeignKey("MessageId")]
        [Column("MessageId")]
        public virtual Message Messsage { get; set; }


    }
}