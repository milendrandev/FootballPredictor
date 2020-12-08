#pragma checksum "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2868616fe2a88aa71f3d596d7456f05ec07a60f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_Rankings), @"mvc.1.0.view", @"/Views/Players/Rankings.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2868616fe2a88aa71f3d596d7456f05ec07a60f6", @"/Views/Players/Rankings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96dfabdd470cad22f4070607fecb3db59464921c", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_Rankings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FootballPredictor.Web.ViewModels.Players.ListOfRankigsViewModel>
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
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2868616fe2a88aa71f3d596d7456f05ec07a60f63194", async() => {
                WriteLiteral("\r\n        <style>\r\n            h1 {\r\n                text-align: center;\r\n                color: aliceblue;\r\n            }\r\n        </style>\r\n    ");
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
            WriteLiteral("\r\n\r\n<h1>Top Scorers</h1>\r\n<hr/>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2868616fe2a88aa71f3d596d7456f05ec07a60f64357", async() => {
                WriteLiteral("\r\n    <style>\r\n        h2 {\r\n            text-align: center;\r\n            color: aliceblue;\r\n        }\r\n    </style>\r\n");
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
            WriteLiteral(@"

<div>
    <style>
        table {
            counter-reset: rowNumber;
        }

            table tr > td:first-child {
                counter-increment: rowNumber;
            }

            table tr td:first-child::before {
                content: counter(rowNumber);
                min-width: 1em;
                margin-right: 0.5em;
            }
    </style>
</div>

");
#nullable restore
#line 42 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
 foreach (var league in Model.Leagues)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 44 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
   Write(league.LeagueName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th scope=""col"" class=""whiteColor"">Place</th>
                <th scope=""col"" class=""whiteColor"">Name</th>
                <th scope=""col"" class=""whiteColor"">Team</th>
                <th scope=""col"" class=""whiteColor"">Goals</th>
                <th scope=""col"" class=""whiteColor"">Played Matches</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 56 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
             foreach (var player in league.Players)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"table-light\">\r\n                <td></td>\r\n                <th scope=\"row\">");
#nullable restore
#line 60 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
                           Write(player.Neam);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 61 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
               Write(player.TeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <th scope=\"row\">");
#nullable restore
#line 62 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
                           Write(player.ScoredGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 63 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
               Write(player.MatchesPlayed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 65 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <br />\r\n");
#nullable restore
#line 69 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Players\Rankings.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FootballPredictor.Web.ViewModels.Players.ListOfRankigsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
