using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// This model is for User information and validating.
namespace MessageBoard.Models
{    
    public class Message{
        [Key]
        public int MessageId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User Creator { get; set; }
        public List<Comment> ChildrenComments { get;set; }
    }
}