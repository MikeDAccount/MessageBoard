using System;
using System.Collections.Generic;

// This model is used to allow us to access more than one model at a time.
namespace MessageBoard.Models
{
    public class MessageBoardWrapper
    {
        public User LoggedUser { get; set; }
        public List<User> AllUsers { get; set; }
        public List<Message> AllMessages {get; set; }
        public List<Comment> AllComments { get; set; } 
        public Message Msg { get; set; }
        public Comment Cmt {get;set; }

    }
}