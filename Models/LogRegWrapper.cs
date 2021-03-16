using System;
using System.Collections.Generic;

// This is used to wrap the user and logged in user classes so they are accessible through the same class "LogRegWrapper"
namespace MessageBoard.Models
{
    public class LogRegWrapper
    {
        public User Register { get; set; }
        public LogUser Login { get; set; }
    }
}

