#pragma checksum "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c1c4ef3102dafe3e945fb6788d262211656d90b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
#line 1 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\_ViewImports.cshtml"
using HeThongQuanLyCongTacKhaoThi.AdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\_ViewImports.cshtml"
using HeThongQuanLyCongTacKhaoThi.AdminApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c1c4ef3102dafe3e945fb6788d262211656d90b", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"661a494f297b12d153d796cf927a0da9a8e40a81", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<AccountViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c1c4ef3102dafe3e945fb6788d262211656d90b4402", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Mã giảng viên / sinh viên
            </th>
            <th>
                Tên đăng nhập
            </th>
            <th>
                Tên hiển thị
            </th>
            <th>
                Email
            </th>
            <th>
                Ngày sinh
            </th>
            <th>
                Giới tính
            </th>
            <th>
                Số điện thoại
            </th>
            <th>
                Mã lớp
            </th>
            <th>
                Địa chỉ
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 48 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
         foreach (var item in Model.Items)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Student_TeacherID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ClassID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 80 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 81 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 84 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi.AdminApp\Views\Account\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<AccountViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
