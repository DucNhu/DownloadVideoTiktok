#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed20381bb7b2844e4ec630b82c375a869a96fbda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account__AccountMenuPartial), @"mvc.1.0.view", @"/Views/Account/_AccountMenuPartial.cshtml")]
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
#line 1 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\_ViewImports.cshtml"
using DownloadVideoTiktok;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\_ViewImports.cshtml"
using DownloadVideoTiktok.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed20381bb7b2844e4ec630b82c375a869a96fbda", @"/Views/Account/_AccountMenuPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f6b5a8999198514143dc6b0d3737eb92b834de", @"/Views/_ViewImports.cshtml")]
    public class Views_Account__AccountMenuPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-center\">\r\n    <h4>Menu</h4>\r\n    <hr />\r\n    <nav class=\"nav flex-column nav-pills\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 113, "\"", 213, 2);
            WriteAttributeValue("", 121, "nav-link", 121, 8, true);
#nullable restore
#line 5 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml"
WriteAttributeValue(" ", 129, Context.Request.Path.Value.Contains("change-password") ? "active" : string.Empty, 130, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/change-password\">Change password</a>\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 270, "\"", 367, 2);
            WriteAttributeValue("", 278, "nav-link", 278, 8, true);
#nullable restore
#line 6 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml"
WriteAttributeValue(" ", 286, Context.Request.Path.Value.Contains("transactions") ? "active" : string.Empty, 287, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/transactions\">Transactions</a>\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 418, "\"", 519, 2);
            WriteAttributeValue("", 426, "nav-link", 426, 8, true);
#nullable restore
#line 7 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml"
WriteAttributeValue(" ", 434, Context.Request.Path.Value.Contains("history-download") ? "active" : string.Empty, 435, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/history-download\">History download</a>\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 578, "\"", 672, 2);
            WriteAttributeValue("", 586, "nav-link", 586, 8, true);
#nullable restore
#line 8 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml"
WriteAttributeValue(" ", 594, Context.Request.Path.Value.Contains("reference") ? "active" : string.Empty, 595, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/reference\">Reference</a>\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 717, "\"", 809, 2);
            WriteAttributeValue("", 725, "nav-link", 725, 8, true);
#nullable restore
#line 9 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Account\_AccountMenuPartial.cshtml"
WriteAttributeValue(" ", 733, Context.Request.Path.Value.Contains("upgrade") ? "active" : string.Empty, 734, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/upgrade\">Upgrade</a>\r\n    </nav>\r\n</div>\r\n");
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
