#pragma checksum "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37068c7020f9934580441f34602397c6e7e79833"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Matches_All), @"mvc.1.0.view", @"/Views/Matches/All.cshtml")]
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
#line 1 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\_ViewImports.cshtml"
using FootballPredictor.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\_ViewImports.cshtml"
using FootballPredictor.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
using FootballPredictor.Data.Repositories;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37068c7020f9934580441f34602397c6e7e79833", @"/Views/Matches/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96dfabdd470cad22f4070607fecb3db59464921c", @"/Views/_ViewImports.cshtml")]
    public class Views_Matches_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FootballPredictor.Web.ViewModels.Matches.ListOfLeaguesViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37068c7020f9934580441f34602397c6e7e798333336", async() => {
                WriteLiteral("\r\n    <style>\r\n        h1 {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<h1> Games this week</h1>\r\n<br />\r\n\r\n");
#nullable restore
#line 14 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
 foreach (var league in Model.Leagues)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"d-flex justify-content-left\">\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37068c7020f9934580441f34602397c6e7e798334750", async() => {
                WriteLiteral("\r\n        <style>\r\n            h2 {\r\n                text-align: center;\r\n            }\r\n        </style>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("    <h2>");
#nullable restore
#line 26 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
   Write(league.LeagueName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
    <table class=""table table-hover table-bordered mb-9"">
        <thead>
            <tr>
                <th scope=""col"">Home</th>
                <th scope=""col""></th>
                <th scope=""col"">Away</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 37 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
             foreach (var match in league.Matches)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"table-light table-bordered mb-6\">\r\n                    <td>");
#nullable restore
#line 41 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
                   Write(match.HomeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td> : </td>\r\n                    <td>");
#nullable restore
#line 43 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
                   Write(match.AwayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a class=\"btn btn-block btn-primary mb-3 text-white mb-3\"");
            BeginWriteAttribute("href", " href=\"", 1174, "\"", 1214, 3);
            WriteAttributeValue("", 1181, "/Predictions/Create?id=", 1181, 23, true);
#nullable restore
#line 44 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
WriteAttributeValue("", 1204, match.Id, 1204, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1213, "", 1214, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Create a prediction</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 46 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <br />\r\n");
#nullable restore
#line 50 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\All.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FootballPredictor.Web.ViewModels.Matches.ListOfLeaguesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
