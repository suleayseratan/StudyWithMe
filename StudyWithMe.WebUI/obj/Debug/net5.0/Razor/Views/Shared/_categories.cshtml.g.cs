#pragma checksum "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\Shared\_categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9947e71faa073a35d764e2a0cb15c290fca380a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__categories), @"mvc.1.0.view", @"/Views/Shared/_categories.cshtml")]
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
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "H:\My-Github-Projects\StudyWithMe\StudyWithMe.WebUI\Views\_ViewImports.cshtml"
using StudyWithMe.WebUI.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9947e71faa073a35d764e2a0cb15c290fca380a3", @"/Views/Shared/_categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b54657acc42eebbdf3311780921b3333c121774", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <div class=""input-group"">
        <input class=""form-control border-0 border-bottom"" type=""search"" value=""search"" id=""category-search-input"">
        <span class=""input-group-append"">
            <button class=""btn btn-outline-secondary bg-white border-0 border-bottom border ms-n5"" type=""button"">
                <i class=""fa fa-search""></i>
            </button>
        </span>
    </div>
</div>
<div id=""categories-list"" class=""list-group list-group-flush border-0 scrollbar overflow-auto""
    style=""margin:0; font-size:small; height: 300px; overflow-x: hidden !important;"">
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 777, "\"", 785, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                All

            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 1226, "\"", 1234, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                Programming
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 1681, "\"", 1689, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                Math
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 2129, "\"", 2137, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 2580, "\"", 2588, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3031, "\"", 3039, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3482, "\"", 3490, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 3933, "\"", 3941, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
    <div class=""list-group-item list-group-item-action"">
        <div class=""form-check justify-content-between"">
            <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 4384, "\"", 4392, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                English
            </label>
            <span class=""badge bg-primary rounded-pill"" style=""float:right !important;"">4</span>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
