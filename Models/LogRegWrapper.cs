using System;
using System.Collections.Generic;
// This is used to wrap the user and logged in user classes
namespace MessageBoard.Models
{
    public class LogRegWrapper
    {
        public User Register { get; set; }
        public LogUser Login { get; set; }
    }
}

