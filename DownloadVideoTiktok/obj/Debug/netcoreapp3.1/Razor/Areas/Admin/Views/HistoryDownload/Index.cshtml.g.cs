#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c7d2431a1b7e1887e845952706ab0b430e5ef10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_HistoryDownload_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/HistoryDownload/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c7d2431a1b7e1887e845952706ab0b430e5ef10", @"/Areas/Admin/Views/HistoryDownload/Index.cshtml")]
    public class Areas_Admin_Views_HistoryDownload_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.PageListModel<DownloadVideoTiktok.Models.HistoryDownload>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n\r\n    <!-- Page Heading -->\r\n");
            WriteLiteral("    <div class=\"card shadow mb-4\">\r\n        <div class=\"card-header py-3 d-flex flex-row align-items-center justify-content-between\">\r\n            <h6 class=\"m-0 font-weight-bold text-primary\">List history downloads (");
#nullable restore
#line 14 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                                                                             Write(Model.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h6>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
       Write(await Html.PartialAsync("~/Areas/Admin/Views/Shared/_TableHeadPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th>
                            No.
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            User ID
                        </th>
                        <th>
                            Source
                        </th>
                        <th>
                            DateCreate
                        </th>
                        <th>
                            Status
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 43 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                     foreach (var item in Model.List.Select((v, i) => new { Index = i, Value = v }))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                        Write(item.Index + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Value.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 53 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Value.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Value.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Value.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 62 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                             if (item.Value.IsActive.HasValue && item.Value.IsActive.Value)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-success\">Active</span>\r\n");
#nullable restore
#line 65 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-warning\">Unactive</span>\r\n");
#nullable restore
#line 69 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2776, "\"", 2828, 2);
            WriteAttributeValue("", 2783, "/admin/historydownload/details/", 2783, 31, true);
#nullable restore
#line 72 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
WriteAttributeValue("", 2814, item.Value.Id, 2814, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-circle btn-sm\">\r\n                                <i class=\"fa fa-search\"></i>\r\n                            </a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 77 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n            ");
#nullable restore
#line 80 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\HistoryDownload\Index.cshtml"
       Write(await Html.PartialAsync("~/Views/Shared/_PagingPartial.cshtml", Model.Paging));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.PageListModel<DownloadVideoTiktok.Models.HistoryDownload>> Html { get; private set; }
    }
}
#pragma warning restore 1591
