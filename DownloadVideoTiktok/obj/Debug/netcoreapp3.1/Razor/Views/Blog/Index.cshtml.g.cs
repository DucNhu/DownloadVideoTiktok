#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35ab3d0df899fdd9cfec1d8f0322069b77413cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35ab3d0df899fdd9cfec1d8f0322069b77413cc8", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f6b5a8999198514143dc6b0d3737eb92b834de", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.PageListModel<DownloadVideoTiktok.Models.Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Blogs";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<header class=""masthead"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8 col-md-10 mx-auto"">
                <div class=""site-heading"">
                    <h1>Blogs</h1>
                    <span class=""subheading"">A Blog by Videodownhd</span>
                </div>
            </div>
        </div>
    </div>
</header>


");
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row box-blog\">\r\n");
#nullable restore
#line 25 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
         foreach (var item in Model.List)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-4 col-sm-6\">\r\n                <div class=\"post-preview\">\r\n                    ");
#nullable restore
#line 29 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
               Write(await Html.PartialAsync("~/Views/Shared/_EditContentPartial.cshtml", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <a href=\"/blogs/how-to-download-tiktok-videos-without-watermark\">\r\n                        <h4 class=\"post-title\">\r\n                            ");
#nullable restore
#line 32 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </h4>
                        <p class=""post-subtitle"">
                            <img src=""https://yoodownload.com/img/youtube-video-downloader.png"" alt=""Alternate Text"" class=""float-left m-2"" style=""max-width: 48px"" />
                            ");
#nullable restore
#line 36 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
                       Write(Html.Raw(item.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </a>\r\n                    <p class=\"post-meta\">\r\n                        Posted by\r\n                        <a href=\"/\">videodownhd.com</a>\r\n                        on ");
#nullable restore
#line 42 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
                      Write(item.DateCreated.Value.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"clearfix\">\r\n");
#nullable restore
#line 49 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
         if (Model.CurrentPage < Model.TotalPage)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"btn button--sub float-right\"");
            BeginWriteAttribute("href", " href=\"", 1823, "\"", 1866, 2);
            WriteAttributeValue("", 1830, "/blogs?page=", 1830, 12, true);
#nullable restore
#line 51 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1842, Model.CurrentPage + 1, 1842, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Older Posts →</a>\r\n");
#nullable restore
#line 52 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
         if (Model.CurrentPage > 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"btn button--sub float-left\"");
            BeginWriteAttribute("href", " href=\"", 1997, "\"", 2040, 2);
            WriteAttributeValue("", 2004, "/blogs?page=", 2004, 12, true);
#nullable restore
#line 56 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
WriteAttributeValue("", 2016, Model.CurrentPage - 1, 2016, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">← Newer Posts</a>\r\n");
#nullable restore
#line 57 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Views\Blog\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.PageListModel<DownloadVideoTiktok.Models.Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591