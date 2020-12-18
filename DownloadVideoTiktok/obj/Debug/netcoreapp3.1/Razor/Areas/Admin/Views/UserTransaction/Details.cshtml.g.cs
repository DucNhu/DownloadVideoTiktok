#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "483ecce2b9c7c4b493168f0ff081db213211b7c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_UserTransaction_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/UserTransaction/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"483ecce2b9c7c4b493168f0ff081db213211b7c3", @"/Areas/Admin/Views/UserTransaction/Details.cshtml")]
    public class Areas_Admin_Views_UserTransaction_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.UserTransaction>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
            <h6 class=""m-0 font-weight-bold text-primary"">Detail user transaction</h6>
            <div>
                <a href=""/admin/usertransaction"" class=""d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm""><i class=""fa fa-arrow-left fa-sm text-white-50""></i> Back</a>
            </div>
        </div>
        <div class=""card-body"">
            <div>
                <h4>User transaction</h4>
                <hr />
                <dl class=""row"">
                    <dt class=""col-sm-2"">
                        ");
#nullable restore
#line 22 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 25 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 28 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 31 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 34 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 37 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 43 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.TransactionId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 46 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.ReferenceCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 49 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.ReferenceCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 52 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 55 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.IsPlus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 61 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.IsPlus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 64 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 67 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 70 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 73 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 76 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 79 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\UserTransaction\Details.cshtml"
                   Write(Html.DisplayFor(model => model.IsDeleted));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.UserTransaction> Html { get; private set; }
    }
}
#pragma warning restore 1591