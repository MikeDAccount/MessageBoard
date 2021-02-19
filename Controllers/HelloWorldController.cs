using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MessageBoard.Controllers
{
    public class HelloWorldController :  Controller
    {
        // IActionResult can be used when accessing a .cshtml page.
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();  //return "This is my default action...";
        }
        // GET: /HelloWorld/Welcome/
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
            // return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}"); //return "This is the Welcome action method...";
        }
    }
}
// https://localhost:5001/HelloWorld/Welcome?name=Rick&numtimes=4
// Alt+Z will allow the code to wrap in the editor.
// "/[Controller]/[ActionName]/[Parameters]"