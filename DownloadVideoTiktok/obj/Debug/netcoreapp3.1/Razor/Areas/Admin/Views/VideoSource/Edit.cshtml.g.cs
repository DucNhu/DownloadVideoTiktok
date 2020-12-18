#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91745edebc9e647f38de2ffc750ef92e036150a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_VideoSource_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/VideoSource/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91745edebc9e647f38de2ffc750ef92e036150a5", @"/Areas/Admin/Views/VideoSource/Edit.cshtml")]
    public class Areas_Admin_Views_VideoSource_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.VideoSource>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <form id=\"submitForm\" method=\"post\" asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 264, "\"", 288, 1);
#nullable restore
#line 13 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 279, Model.Id, 279, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" enctype=\"multipart/form-data\">\r\n        ");
#nullable restore
#line 14 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                <h6 class=""m-0 font-weight-bold text-primary"">Edit article</h6>
                <div>
                    <a href=""/admin/videosource"" class=""d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm""><i class=""fa fa-arrow-left fa-sm text-white-50""></i> Back</a>
                    <button type=""submit"" class=""d-none d-sm-inline-block btn btn-sm btn-success shadow-sm""><i class=""fa fa-check fa-sm text-white-50""></i> Submit</button>
                </div>
            </div>
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""Name""");
            WriteLiteral(" class=\"control-label\">Name</label>\r\n                            <input asp-for=\"Name\" name=\"Name\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1497, "\"", 1516, 1);
#nullable restore
#line 31 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 1505, Model.Name, 1505, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""Name"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""IsActive"" class=""control-label"">Active</label>
                            <select class=""form-control"" asp-for=""IsActive"" name=""IsActive"">
                                <option value=""true"" ");
#nullable restore
#line 39 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                 Write(Model.IsActive == true ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Active</option>\r\n                                <option value=\"false\" ");
#nullable restore
#line 40 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                  Write(Model.IsActive != true ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Unactive</option>
                            </select>
                            <span asp-validation-for=""IsActive"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""HasLink"" class=""control-label"">HasLink</label>
                            <select class=""form-control"" asp-for=""HasLink"" name=""HasLink"">
                                <option");
            BeginWriteAttribute("value", " value=\"", 2711, "\"", 2799, 1);
#nullable restore
#line 49 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 2719, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT, 2719, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 49 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                             Write(Model.HasLink == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">No support</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 2987, "\"", 3072, 1);
#nullable restore
#line 50 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 2995, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING, 2995, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                          Write(Model.HasLink == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Running</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 3254, "\"", 3337, 1);
#nullable restore
#line 51 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 3262, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR, 3262, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 51 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                        Write(Model.HasLink == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Error</option>
                            </select>
                            <span asp-validation-for=""HasLink"" class=""text-danger""></span>
                        </div>
                        <div class=""form-group"">
                            <input asp-for=""UrlCheckLink"" name=""UrlCheckLink"" placeholder=""UrlCheckLink"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 3814, "\"", 3841, 1);
#nullable restore
#line 56 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 3822, Model.UrlCheckLink, 3822, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""UrlCheckLink"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""HasUser"" class=""control-label"">HasUser</label>
                            <select class=""form-control"" asp-for=""HasUser"" name=""HasUser"">
                                <option");
            BeginWriteAttribute("value", " value=\"", 4321, "\"", 4409, 1);
#nullable restore
#line 64 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 4329, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT, 4329, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 64 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                             Write(Model.HasUser == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">No support</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 4597, "\"", 4682, 1);
#nullable restore
#line 65 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 4605, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING, 4605, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 65 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                          Write(Model.HasUser == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Running</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 4864, "\"", 4947, 1);
#nullable restore
#line 66 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 4872, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR, 4872, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 66 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                        Write(Model.HasUser == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Error</option>
                            </select>
                            <span asp-validation-for=""HasUser"" class=""text-danger""></span>
                        </div>
                        <div class=""form-group"">
                            <input asp-for=""UrlCheckUser"" name=""UrlCheckUser"" placeholder=""UrlCheckUser"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 5424, "\"", 5451, 1);
#nullable restore
#line 71 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 5432, Model.UrlCheckUser, 5432, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""UrlCheckUser"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""HasChanel"" class=""control-label"">HasChanel</label>
                            <select class=""form-control"" asp-for=""HasChanel"" name=""HasChanel"">
                                <option");
            BeginWriteAttribute("value", " value=\"", 5939, "\"", 6027, 1);
#nullable restore
#line 79 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 5947, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT, 5947, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 79 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                             Write(Model.HasChanel == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">No support</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 6217, "\"", 6302, 1);
#nullable restore
#line 80 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 6225, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING, 6225, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 80 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                          Write(Model.HasChanel == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Running</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 6486, "\"", 6569, 1);
#nullable restore
#line 81 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 6494, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR, 6494, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 81 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                        Write(Model.HasChanel == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Error</option>
                            </select>
                            <span asp-validation-for=""HasChanel"" class=""text-danger""></span>
                        </div>
                        <div class=""form-group"">
                            <input asp-for=""UrlCheckChanel"" name=""UrlCheckChanel"" placeholder=""UrlCheckChanel"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 7056, "\"", 7085, 1);
#nullable restore
#line 86 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 7064, Model.UrlCheckChanel, 7064, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""UrlCheckChanel"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""HasPlaylist"" class=""control-label"">HasPlaylist</label>
                            <select class=""form-control"" asp-for=""HasPlaylist"" name=""HasPlaylist"">
                                <option");
            BeginWriteAttribute("value", " value=\"", 7583, "\"", 7671, 1);
#nullable restore
#line 94 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 7591, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT, 7591, 80, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 94 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                             Write(Model.HasPlaylist == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.NO_SUPPORT ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">No support</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 7863, "\"", 7948, 1);
#nullable restore
#line 95 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 7871, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING, 7871, 77, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 95 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                          Write(Model.HasPlaylist == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.RUNNING ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Running</option>\r\n                                <option");
            BeginWriteAttribute("value", " value=\"", 8134, "\"", 8217, 1);
#nullable restore
#line 96 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 8142, (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR, 8142, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 96 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
                                                                                                                        Write(Model.HasPlaylist == (int)DownloadVideoTiktok.Infrastructure.WebEnums.StatusVideoSource.ERROR ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Error</option>
                            </select>
                            <span asp-validation-for=""HasPlaylist"" class=""text-danger""></span>
                        </div>
                        <div class=""form-group"">
                            <input asp-for=""UrlCheckPlaylist"" name=""UrlCheckPlaylist"" placeholder=""UrlCheckPlaylist"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 8714, "\"", 8745, 1);
#nullable restore
#line 101 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
WriteAttributeValue("", 8722, Model.UrlCheckPlaylist, 8722, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <span asp-validation-for=\"UrlCheckPlaylist\" class=\"text-danger\"></span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 112 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\VideoSource\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script>\r\n\r\n        $(document).ready(function () {\r\n\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.VideoSource> Html { get; private set; }
    }
}
#pragma warning restore 1591
