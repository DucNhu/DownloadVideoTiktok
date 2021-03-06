#pragma checksum "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e318bbe1d75c2da879afc7e0e59f20d0c15f85a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Article_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Article/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e318bbe1d75c2da879afc7e0e59f20d0c15f85a", @"/Areas/Admin/Views/Article/Edit.cshtml")]
    public class Areas_Admin_Views_Article_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DownloadVideoTiktok.Models.Article>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/area/vendor/ckeditor/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/area/vendor/bs-custom-file-input/bs-custom-file-input.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
  
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
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 260, "\"", 284, 1);
#nullable restore
#line 13 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 275, Model.Id, 275, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" enctype=\"multipart/form-data\">\r\n        ");
#nullable restore
#line 14 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div class=""card shadow mb-4"">
            <div class=""card-header py-3 d-flex flex-row align-items-center justify-content-between"">
                <h6 class=""m-0 font-weight-bold text-primary"">Edit article</h6>
                <div>
                    <a href=""/admin/article"" class=""d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm""><i class=""fa fa-arrow-left fa-sm text-white-50""></i> Back</a>
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
                            <label asp-for=""Name"" cla");
            WriteLiteral("ss=\"control-label\">Name</label>\r\n                            <input asp-for=\"Name\" name=\"Name\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 1489, "\"", 1508, 1);
#nullable restore
#line 31 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 1497, Model.Name, 1497, 11, false);

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
                            <label asp-for=""Code"" class=""control-label"">Code</label>
                            <input asp-for=""Code"" name=""Code"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 1925, "\"", 1944, 1);
#nullable restore
#line 38 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 1933, Model.Code, 1933, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""Code"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""TypeCode"" class=""control-label"">Type</label>
                            <select class=""form-control"" asp-for=""TypeCode"" name=""TypeCode"">
                                <option value=""BLOG"" ");
#nullable restore
#line 46 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                 Write(Model.TypeCode == "BLOG" ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Blog</option>\r\n                                <option value=\"FAQ\" ");
#nullable restore
#line 47 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                Write(Model.TypeCode == "FAQ" ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Faq</option>\r\n                                <option value=\"GUIDE\" ");
#nullable restore
#line 48 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                  Write(Model.TypeCode == "GUIDE" ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Guide</option>\r\n                                <option value=\"CONTENT\" ");
#nullable restore
#line 49 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                    Write(Model.TypeCode == "CONTENT" ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">Content</option>
                            </select>
                            <span asp-validation-for=""TypeCode"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""Language"" class=""control-label"">Language</label>
                            <select class=""form-control"" asp-for=""Language"" name=""Language"">
                                <option value=""en"" ");
#nullable restore
#line 58 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                               Write(Model.Language == "en" ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(@">English</option>
                            </select>
                            <span asp-validation-for=""Language"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""IsActive"" class=""control-label"">Active</label>
                            <select class=""form-control"" asp-for=""IsActive"" name=""IsActive"">
                                <option value=""true"" ");
#nullable restore
#line 67 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                 Write(Model.IsActive == true ? "selected" : string.Empty);

#line default
#line hidden
#nullable disable
            WriteLiteral(">Active</option>\r\n                                <option value=\"false\" ");
#nullable restore
#line 68 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
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
                            <label asp-for=""DisplayOrder"" class=""control-label"">DisplayOrder</label>
                            <input asp-for=""DisplayOrder"" type=""number"" name=""DisplayOrder"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 4702, "\"", 4729, 1);
#nullable restore
#line 76 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 4710, Model.DisplayOrder, 4710, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""DisplayOrder"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""Picture"" class=""control-label"">Picture</label>
");
#nullable restore
#line 83 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                             if (!string.IsNullOrEmpty(Model.UrlPicture))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"mt-3 mb-3\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 5281, "\"", 5304, 1);
#nullable restore
#line 86 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 5287, Model.UrlPicture, 5287, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 5305, "\"", 5328, 1);
#nullable restore
#line 86 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 5311, Model.UrlPicture, 5311, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\">\r\n                                </div>\r\n");
#nullable restore
#line 88 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"custom-file\">\r\n                                <input type=\"file\" name=\"Picture\" class=\"custom-file-input\" id=\"pictureFile\">\r\n                                <label class=\"custom-file-label\" for=\"pictureFile\">");
#nullable restore
#line 91 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                                               Write(string.IsNullOrEmpty(Model.UrlPicture) ? "Choose file" : Model.UrlPicture);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                            </div>
                            <span asp-validation-for=""Picture"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <label asp-for=""Summary"" class=""control-label"">Summary</label>
");
            WriteLiteral("                            <div id=\"summary\" style=\"height:350px;\">");
#nullable restore
#line 100 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                               Write(Html.Raw(Model.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            <input type=""hidden"" name=""Summary"" />
                            <span asp-validation-for=""Summary"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""form-group"">
                            <label asp-for=""Detail"" class=""control-label"">Detail</label>
                            <div id=""editor"" style=""height:350px;"">");
#nullable restore
#line 108 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
                                                              Write(Html.Raw(Model.Detail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <input type=\"hidden\" name=\"Detail\" />\r\n");
            WriteLiteral(@"                            <span asp-validation-for=""Detail"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""SEOTitle"" class=""control-label"">SEOTitle</label>
                            <input asp-for=""SEOTitle"" name=""SEOTitle"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 7483, "\"", 7506, 1);
#nullable restore
#line 117 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 7491, Model.SEOTitle, 7491, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""SEOTitle"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""SEODescrition"" class=""control-label"">SEODescrition</label>
                            <input asp-for=""SEODescrition"" name=""SEODescrition"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 7963, "\"", 7991, 1);
#nullable restore
#line 124 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 7971, Model.SEODescrition, 7971, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                            <span asp-validation-for=""SEODescrition"" class=""text-danger""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <div class=""form-group"">
                            <label asp-for=""SEOKeywords"" class=""control-label"">SEOKeywords</label>
                            <input asp-for=""SEOKeywords"" name=""SEOKeywords"" class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 8445, "\"", 8471, 1);
#nullable restore
#line 131 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
WriteAttributeValue("", 8453, Model.SEOKeywords, 8453, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <span asp-validation-for=\"SEOKeywords\" class=\"text-danger\"></span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 142 "C:\Users\Pc\Documents\GitHub\DownloadVideoTiktok\DownloadVideoTiktok\Areas\Admin\Views\Article\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e318bbe1d75c2da879afc7e0e59f20d0c15f85a19835", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e318bbe1d75c2da879afc7e0e59f20d0c15f85a20935", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>

        if (CKEDITOR.env.ie && CKEDITOR.env.version < 9)
            CKEDITOR.tools.enableHtml5Elements(document);

        CKEDITOR.config.height = 350;
        CKEDITOR.config.width = 'auto';
        CKEDITOR.config.allowedContent = true;

        $(document).ready(function () {
            CKEDITOR.replace('editor', {
                filebrowserUploadUrl: '/upload-editor'
            });
            CKEDITOR.replace('summary', {
                filebrowserUploadUrl: '/upload-editor'
            });
            bsCustomFileInput.init();
        });

        document.querySelector('#submitForm').onsubmit = function () {
            var detail = document.querySelector('input[name=Detail]');
            detail.value = CKEDITOR.instances.editor.getData();
            var summary = document.querySelector('input[name=Summary]');
            summary.value = CKEDITOR.instances.summary.getData();
            return true;
        };
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DownloadVideoTiktok.Models.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
