using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// This model is for User information and validating.
namespace MessageBoard.Models
{    
    public class Comment{
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User Creator { get; set; }
        public int MessageId { get; set; }
        public Message ParentMessage { get;set; }
    }
}