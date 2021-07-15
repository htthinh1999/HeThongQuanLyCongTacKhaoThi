#pragma checksum "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ac1bfe231fa84a66f8b45b18f14a7705f7fba47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\_ViewImports.cshtml"
using HeThongQuanLyCongTacKhaoThi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\_ViewImports.cshtml"
using HeThongQuanLyCongTacKhaoThi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ac1bfe231fa84a66f8b45b18f14a7705f7fba47", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ae0c213c530959af4fa3ef25e8c2bc633c2a4cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
   
    ViewData["Title"] = "Trang chủ";
    var subjectsNotJoined = new List<SubjectViewModel>();
    if (User.Identity.Name != null)
    {
        var accoutSubjectsNotJoinedJson = Context.Session.GetString("AccoutSubjectsNotJoined");
        subjectsNotJoined = JsonConvert.DeserializeObject<List<SubjectViewModel>>(accoutSubjectsNotJoinedJson);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 16 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
 if(User.Identity.Name != null && !User.IsInRole(Roles.Student))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"alert-msg\" class=\"alert alert-danger\" role=\"alert\">\r\n        <b>Bạn chưa được cấp quyền!</b> Vui lòng liên hệ với <b>\"Quản trị viên\"</b> để được cấp quyền sử dụng!\r\n    </div>\r\n");
#nullable restore
#line 21 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4 font-weight-normal\">Chào mừng bạn đến với</h1>\r\n    <h2 class=\"display-3 text-gray-700 font-weight-bold\">Hệ thống quản lý công tác khảo thí</h2>\r\n</div>\r\n\r\n");
#nullable restore
#line 28 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
 if(User.Identity.Name != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"h4 mt-5 mb-0 text-gray-800 font-weight-bold\">Các môn học chưa tham gia</h2>\r\n    <hr />\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 33 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
         foreach(var subjectNotJoined in subjectsNotJoined){

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-xl-3 col-md-6 mb-4"">
                <a class=""subject-not-joined text-decoration-none"" href=""#"" data-toggle=""modal"" data-target=""#registerSubjectModal"">
                    <div class=""card border-primary shadow py-2"">
                        <div class=""card-body align-items-center d-flex justify-content-center"">
                            <div");
            BeginWriteAttribute("id", " id=\"", 1626, "\"", 1651, 1);
#nullable restore
#line 38 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
WriteAttributeValue("", 1631, subjectNotJoined.ID, 1631, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"subject-name h5 mb-0 font-weight-bold text-gray-800\">\r\n                                ");
#nullable restore
#line 39 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
                           Write(subjectNotJoined.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n                            </div>\r\n                        </div>\r\n                        <div class=\"card-body pt-0 pb-0 text-sm font-weight-bold text-primary text-uppercase mb-1\">\r\n                            Mã môn học: ");
#nullable restore
#line 43 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
                                   Write(subjectNotJoined.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                            Số tiết học: ");
#nullable restore
#line 44 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
                                    Write(subjectNotJoined.LessonCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                            Số tín chỉ: ");
#nullable restore
#line 45 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
                                   Write(subjectNotJoined.CreditCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </a>\r\n            </div>\r\n");
#nullable restore
#line 50 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral(@"    <!-- Register Subject Modal-->
    <div class=""modal fade"" id=""registerSubjectModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Tham gia môn học?</h5>
                    <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                </div>
                <div class=""modal-body"">Bạn có muốn tham gia môn học subjectNotJoined.Name?</div>
                <div class=""modal-footer"">
                    <button class=""btn btn-secondary"" type=""button"" data-dismiss=""modal"">Huỷ</button>
                    <a class=""btn btn-primary"" href=""JoinSubject/subjectNotJoined.ID"">Tham gia môn học</a>
                </div>
            </div>
 ");
            WriteLiteral("       </div>\r\n    </div>\r\n");
#nullable restore
#line 73 "F:\Projects\.NET_Core\HeThongQuanLyCongTacKhaoThi\HeThongQuanLyCongTacKhaoThi\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $("".subject-not-joined"").on(""click"", function(){
                var subjectName = $(this).find(""div.subject-name"").text();
                $(""#registerSubjectModal"").find(""div.modal-body"").text(""Bạn có muốn tham gia môn học "" + subjectName + ""?"");

                var subjectID = $(this).find(""div.subject-name"").attr(""id"");
                $(""#registerSubjectModal"").find(""a.btn"").attr(""href"", ""JoinSubject/"" + subjectID);
            });
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
