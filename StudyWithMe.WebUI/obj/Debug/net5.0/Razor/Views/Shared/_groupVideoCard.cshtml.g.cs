#pragma checksum "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_groupVideoCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dd7f18224aac1df687f7dbea40dd46331474cb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__groupVideoCard), @"mvc.1.0.view", @"/Views/Shared/_groupVideoCard.cshtml")]
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
#line 2 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.WebUI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.WebUI.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dd7f18224aac1df687f7dbea40dd46331474cb6", @"/Views/Shared/_groupVideoCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d3a04dcd2753bbd6873c1633ba6d7efe413d5ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__groupVideoCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupVideoDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card text-center\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 67, "\"", 136, 2);
            WriteAttributeValue("", 73, "data:image/*;base64,", 73, 20, true);
#nullable restore
#line 4 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_groupVideoCard.cshtml"
WriteAttributeValue("", 93, Convert.ToBase64String(Model.VideoImage), 93, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n    <h5 class=\"card-title mt-2\">");
#nullable restore
#line 5 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_groupVideoCard.cshtml"
                           Write(Model.GroupVideoName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    <div class=\"card-body\">\r\n        <p class=\"card-text\">\r\n            ");
#nullable restore
#line 8 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_groupVideoCard.cshtml"
       Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 390, "\"", 411, 1);
#nullable restore
#line 12 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_groupVideoCard.cshtml"
WriteAttributeValue("", 397, Model.JoinUrl, 397, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn bg-my-blue mb-2 w-75 h-auto\" >Join</a>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupVideoDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
