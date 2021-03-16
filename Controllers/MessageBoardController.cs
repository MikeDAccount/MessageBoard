using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// Necessary for using session
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
// Necessary for password hashing.
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
// Necessary for connecting to our dbContext -> then to our database
using MessageBoard.Data;
// Allows us to reference this class to instantiate instances of models
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
    public class MessageBoardController : Controller
    {
        private MessageBoardContext _context;
        public MessageBoardController(MessageBoardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null. "int?" checks to see if LoggedId is null or not.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }

            // Allowing child comments to be able to be added to the parent comment by using "ChildrenComments".
            MessageBoardWrapper MBWrap = new MessageBoardWrapper()
            {
                AllMessages = _context.Messages
                    .Include(m => m.Creator)
                    .Include(children => children.ChildrenComments)
                    .ThenInclude(c => c.Creator)  
                    .OrderByDescending(d => d.CreatedAt)                  
                    .ToList(),
                
                // LoggedUser = _context.User.FirstOrDefault(u => u.UserId == (int)LoggedId),
            };
            return View("Dashboard", MBWrap);
        }

        [HttpPost]  // This allows for posting information to the database       

        // Lowercase "message" as parameter indicates the message obj from the form. 
        public IActionResult CreateMessage(MessageBoardWrapper message)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }
            
            User LoggedUser = _context.User.FirstOrDefault(u => u.UserId == (int)LoggedId);
            message.Msg.UserId = LoggedUser.UserId;
            _context.Messages.Add(message.Msg);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{MessageId}")] // the Dashboard knows what message to delete because this route matches the route specified in the Dashboard.cshtml Delete "a href" value.
        public RedirectToActionResult DeleteMessage(int MessageId)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }
            Message ToDelete = _context.Messages.FirstOrDefault(m => m.MessageId == MessageId); // Loops through the MessageId's to know which to send a message to.

            if (ToDelete == null || ToDelete.UserId != (int)LoggedId)
            {
                return RedirectToAction("Dashboard");
            }
            
            _context.Remove(ToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("messageboard/createcomment/{MessageId}")]

        public IActionResult CreateComment(MessageBoardWrapper comment, int MessageId)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null. This is to check that they are registered.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }
            User LoggedUser = _context.User.FirstOrDefault(u => u.UserId == (int)LoggedId);
            comment.Cmt.UserId = LoggedUser.UserId;
            comment.Cmt.MessageId = MessageId;
            _context.Comments.Add(comment.Cmt);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        // Only the user who posted the comment can delete it.
        [HttpGet("messageboard/delete/{CommentId}")] // the Dashboard knows what comment to delete because this route matches the route specified in the Dashboard.cshtml Delete "a href" value.
        public RedirectToActionResult DeleteComment(int CommentId)
        {
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }
            Comment ToDelete = _context.Comments.FirstOrDefault(c => c.CommentId == CommentId); // Loops through the MessageId's to know which to send a message to.

            if (ToDelete == null || ToDelete.UserId != (int)LoggedId)
            {
                return RedirectToAction("Dashboard");
            }
            
            _context.Remove(ToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}