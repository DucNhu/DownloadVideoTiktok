#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f38ad638b03b4ba932ebdad2b95f79c2b07a46a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogDetail), @"mvc.1.0.view", @"/Views/Blog/BlogDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f38ad638b03b4ba932ebdad2b95f79c2b07a46a5", @"/Views/Blog/BlogDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f6b5a8999198514143dc6b0d3737eb92b834de", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_BlogDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.Article>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
  
    ViewData["Title"] = Model.Name;
    ViewData["MetaTitle"] = Model.SEOTitle;
    ViewData["MetaDes"] = Model.SEODescrition;
    ViewData["MetaKeyword"] = Model.SEOKeywords;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header class=\"masthead\">\r\n    <div class=\"overlay\"></div>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-8 col-md-10 mx-auto\">\r\n                <div class=\"post-heading\">\r\n                    ");
#nullable restore
#line 16 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
               Write(await Html.PartialAsync("~/Views/Shared/_EditContentPartial.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <h1>");
#nullable restore
#line 17 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <h2 class=\"subheading\">");
#nullable restore
#line 18 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
                                      Write(Model.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <span class=\"meta\">\r\n                        Posted by\r\n                        <a href=\"/\">videodownhd.com</a>\r\n                        on ");
#nullable restore
#line 22 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
                      Write(Model.DateCreated.Value.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</header>\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-8 col-md-10 mx-auto\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\BlogDetail.cshtml"
       Write(Html.Raw(Model.Detail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
