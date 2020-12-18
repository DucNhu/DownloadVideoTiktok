#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56f8680f0dbd9d7bfb9a917d1a03beb99359b24e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_VideoSource_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/VideoSource/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56f8680f0dbd9d7bfb9a917d1a03beb99359b24e", @"/Areas/Admin/Views/VideoSource/Delete.cshtml")]
    public class Areas_Admin_Views_VideoSource_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.VideoSource>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <form method=\"post\" asp-action=\"Delete\">\r\n        ");
#nullable restore
#line 10 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                <h6 class=""m-0 font-weight-bold text-primary"">Delete video source</h6>
                <div>
                    <a href=""/admin/videosource"" class=""d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm""><i class=""fa fa-arrow-left fa-sm text-white-50""></i> Back</a>
                    <button type=""submit"" class=""d-none d-sm-inline-block btn btn-sm btn-danger shadow-sm""><i class=""fa fa-check fa-sm text-white-50""></i> Submit</button>
                </div>
            </div>
            <div class=""card-body"">
                <h3>Are you sure you want to delete this?</h3>
                <div>
                    <h4>Video source</h4>
                    <hr />
                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            ");
#nullable restore
#line 26 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 29 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 32 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 35 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 38 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.HasLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 41 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.HasLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 44 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.HasUser));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 47 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.HasUser));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 50 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.HasChanel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 53 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.HasChanel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 56 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.HasPlaylist));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 59 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.HasPlaylist));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 62 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 65 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 68 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 71 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
#nullable restore
#line 74 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 77 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.VideoSource> Html { get; private set; }
    }
}
#pragma warning restore 1591
