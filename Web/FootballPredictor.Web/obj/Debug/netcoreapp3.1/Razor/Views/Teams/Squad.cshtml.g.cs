#pragma checksum "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ac0a8884db64b65fdf4cad3a85ca0a2031af99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teams_Squad), @"mvc.1.0.view", @"/Views/Teams/Squad.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ac0a8884db64b65fdf4cad3a85ca0a2031af99", @"/Views/Teams/Squad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96dfabdd470cad22f4070607fecb3db59464921c", @"/Views/_ViewImports.cshtml")]
    public class Views_Teams_Squad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FootballPredictor.Web.ViewModels.Players.ListOfPlayerViewModel>
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
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9ac0a8884db64b65fdf4cad3a85ca0a2031af993164", async() => {
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
            WriteLiteral("\r\n<h1> ");
#nullable restore
#line 10 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
Write(Model.TeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div>
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th scope=""col"" class=""whiteColor""> Number</th>
                <th scope=""col"" class=""whiteColor"">Name</th>
                <th scope=""col"" class=""whiteColor""> Goals Scored</th>
                <th scope=""col"" class=""whiteColor""> Played Matches</th>
                <th scope=""col"" class=""whiteColor"">Age</th>
                <th scope=""col"" class=""whiteColor"">Birth Date</th>
                <th scope=""col"" class=""whiteColor"">Height</th>
                <th scope=""col"" class=""whiteColor"">weight</th>
                <th scope=""col"" class=""whiteColor"">Nationality</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 28 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
             foreach (var player in this.Model.Players)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"table-light\">\r\n                <th scope=\"row\">");
#nullable restore
#line 32 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
                           Write(player.SquadNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"row\">");
#nullable restore
#line 33 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
                           Write(player.ShortName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"row\">");
#nullable restore
#line 34 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
                           Write(player.ScoredGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"row\">");
#nullable restore
#line 35 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
                           Write(player.MatchesPlayed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 36 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
               Write(player.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
               Write(player.DateOfBirth.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
               Write(player.HeightCm);

#line default
#line hidden
#nullable disable
            WriteLiteral(" cm</td>\r\n                <td>");
#nullable restore
#line 39 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
               Write(player.WeightKg);

#line default
#line hidden
#nullable disable
            WriteLiteral(" kg</td>\r\n                <td>");
#nullable restore
#line 40 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
               Write(player.Nationality);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Teams\Squad.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FootballPredictor.Web.ViewModels.Players.ListOfPlayerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
