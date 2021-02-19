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
    public class UserController : Controller
    {
        private MessageBoardContext _context;
        public UserController(MessageBoardContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
         public IActionResult Register(LogRegWrapper user)   // the User model class is being conenected to on line 21 by "using MessageBoard.Models;"
        {
            // Check to see if form data passes validations
            if (ModelState.IsValid)
            {
                // Check to make sure email address is unique.
                if (_context.User.Any(u => u.Email == user.Register.Email))
                {
                    ModelState.AddModelError("Email", "Email in use. Already Registered? Please Log In.");
                    return View("Registration");   // this is indicating what file and what folder in the Views folder to look at. Old value "return View("Index", "User");"
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Register.Password = Hasher.HashPassword(user.Register, user.Register.Password);
                _context.User.Add(user.Register);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", user.Register.UserId);    // here user.Id is being assigned the value "UserID" for the session variable used for the entire site.
                return RedirectToAction("Success");  // This redirects the user to a page. Old value "return RedirectToAction("Success","User"); "
            }
            else 
            {
                return View("Registration");
            }
        }
        [HttpPost]
        public IActionResult Login(LogRegWrapper user)
        {
            if (ModelState.IsValid)
            {
                // We are getting the user emails that are in the MessageBoard.db database
                User userInDb = _context.User.FirstOrDefault(u => u.Email == user.Login.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Login.Email","Invalid email/password. Need to create an account?");
                    return View("Registration");
                }
                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                PasswordVerificationResult Result = Hasher.VerifyHashedPassword(user.Login, userInDb.Password, user.Login.Password);

                if(Result == 0)
                {
                    ModelState.AddModelError("Login.Email", "Invalid email/password.");
                    return View("Registration");
                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Success");
            }
            else
            {
               return View("Registration");
            }
        }
        [HttpGet]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Registration");
        }

        [HttpGet]
        public IActionResult Success()
        {
            // C# provides language support for nullable types using a question mark as a suffix. for example, int?
            // Checking to see if a user is logged in session.
            int? LoggedId = HttpContext.Session.GetInt32("UserId"); // get the UserID session variable if it is not null.
            if (LoggedId == null)
            {
                return RedirectToAction("Registration");
            }
            User VBUser = _context.User.FirstOrDefault(u => u.UserId == (int)LoggedId); // FirstOfDefault gets the first item in a list kind of like "select top ..." in SQL.
            ViewBag.SessionUser = VBUser;   // ViewBag allows access to session variables. SessionUser is the name we decided to use to identify the user data. Can call this anything. 

            MessageBoardWrapper MBWrap = new MessageBoardWrapper()
            {   // put all the users in a list, and get the logged in user.
                AllUsers = _context.User.ToList(),  
                LoggedUser = _context.User.FirstOrDefault(u => u.UserId == (int)LoggedId),
            };

            return View("Success", MBWrap);  // return View();
        }
    }
}