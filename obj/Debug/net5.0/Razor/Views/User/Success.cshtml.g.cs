#pragma checksum "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba74820169ebf879851ba840632cf7a5fc28c67a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Success), @"mvc.1.0.view", @"/Views/User/Success.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\_ViewImports.cshtml"
using MessageBoard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\_ViewImports.cshtml"
using MessageBoard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba74820169ebf879851ba840632cf7a5fc28c67a", @"/Views/User/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46b696d81999c192a07425bb3ea5d238089969ff", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MessageBoard.Models.MessageBoardWrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
  
    ViewData["Title"] = "Success";     // this assigns what the title of the page will be called. We are calling it "Success"

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"display: flex\">\r\n    <div style=\"margin: auto\">\r\n");
            WriteLiteral("        <h1 class=\"text-success\">Success! Welcome, ");
#nullable restore
#line 9 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                                              Write(ViewBag.SessionUser.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" from ViewBag</h1>    ");
            WriteLiteral("\r\n        <h2 class=\"text-info\">Your email from the database is: ");
#nullable restore
#line 10 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                                                          Write(Model.LoggedUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
        <h3 class=""text-danger"">All Users from the database</h3>
        <table class=""table"">
            <thead>
                <th>User Id</th>
                <th>Username</th>
                <th>Email</th>
            </thead>
            <tbody>
");
#nullable restore
#line 19 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                 foreach (User user in Model.AllUsers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 23 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                       Write(user.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 26 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                       Write(user.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 29 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Owner\Desktop\Envy Personal\Documents\Mike\WyzAnt Tutors\Andrew Wheeler\C# MVC\MessageBoard\Views\User\Success.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>    \r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessageBoard.Models.MessageBoardWrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
