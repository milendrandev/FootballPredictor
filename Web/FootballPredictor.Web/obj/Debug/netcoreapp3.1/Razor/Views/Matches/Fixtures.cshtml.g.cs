#pragma checksum "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aef87e4f7993cf424b9512d3eb30bf483fd543b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Matches_Fixtures), @"mvc.1.0.view", @"/Views/Matches/Fixtures.cshtml")]
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
#line 1 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
using FootballPredictor.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aef87e4f7993cf424b9512d3eb30bf483fd543b4", @"/Views/Matches/Fixtures.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96dfabdd470cad22f4070607fecb3db59464921c", @"/Views/_ViewImports.cshtml")]
    public class Views_Matches_Fixtures : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FootballPredictor.Web.ViewModels.Matches.ListOfLeaguesViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Fixtures", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
   
    this.ViewData["Title"] = "Fixtures";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b44388", async() => {
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
            WriteLiteral("\r\n\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination justify-content-center\">\r\n        <li");
            BeginWriteAttribute("class", " class=\"", 368, "\"", 435, 3);
            WriteAttributeValue("", 376, "page-item", 376, 9, true);
            WriteAttributeValue(" ", 385, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 17 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                              if (Model.PageNumber==1){

#line default
#line hidden
#nullable disable
                WriteLiteral("disabled");
#nullable restore
#line 17 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                            }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 386, 48, false);
            WriteAttributeValue(" ", 434, "", 435, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b46645", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                         WriteLiteral(Model.PreviousPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 20 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
         if (Model.PageNumber != 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b49215", async() => {
#nullable restore
#line 22 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                                                           Write(Model.PreviousPage);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                               WriteLiteral(Model.PreviousPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b412014", async() => {
#nullable restore
#line 24 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                                                     Write(Model.PageNumber);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                           WriteLiteral(Model.PageNumber);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 25 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
         if (!Model.LastPage)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b414837", async() => {
#nullable restore
#line 28 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                                                       Write(Model.NextPage);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                               WriteLiteral(Model.NextPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 29 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("class", " class=\"", 1093, "\"", 1157, 3);
            WriteAttributeValue("", 1101, "page-item", 1101, 9, true);
            WriteAttributeValue(" ", 1110, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 30 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                              if (Model.LastPage) { 

#line default
#line hidden
#nullable disable
                WriteLiteral("disabled");
#nullable restore
#line 30 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                                         }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 1111, 45, false);
            WriteAttributeValue(" ", 1156, "", 1157, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b418683", async() => {
                WriteLiteral("Next");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                         WriteLiteral(Model.NextPage);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </li>\r\n    </ul>\r\n</nav>\r\n");
#nullable restore
#line 35 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
 if (this.User.Identity.IsAuthenticated && Model.ThisUserPredictionsCount > GlobalConstants.PredictionsLimit)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger text-center\" rolse=\"alert\">*You reached the maximum number of predictions made!</div>\r\n");
#nullable restore
#line 38 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 40 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
 if (this.TempData.ContainsKey("Message"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success text-center\" rolse=\"alert\"> ");
#nullable restore
#line 42 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                           Write(this.TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 43 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1> Games in Gameweek : ");
#nullable restore
#line 45 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                    Write(Model.Gameweek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<hr />\r\n<br />\r\n\r\n");
#nullable restore
#line 49 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
 foreach (var league in Model.Leagues)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"d-flex justify-content-left\">\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aef87e4f7993cf424b9512d3eb30bf483fd543b423067", async() => {
                WriteLiteral("\r\n        <style>\r\n            h2 {\r\n                text-align: center;\r\n                color: aliceblue;\r\n            }\r\n        </style>\r\n    ");
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
#line 62 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
   Write(league.LeagueName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th scope=""col"" class=""whiteColor text-center"">Home</th>
                <th scope=""col"" class=""whiteColor text-center"">Result</th>
                <th scope=""col"" class=""whiteColor text-center"">Away</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 73 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
             foreach (var match in league.Matches)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"table-light\">\r\n                    <td class=\"td-4 text-right\">");
#nullable restore
#line 77 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                           Write(match.HomeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"td-4 text-center\">");
#nullable restore
#line 78 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                            Write(match.HomeGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 78 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                                               Write(match.AwayGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"td-4\">");
#nullable restore
#line 79 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                                Write(match.AwayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 80 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                     if (this.User.Identity.IsAuthenticated)
                    {
                        if (!match.PredictionCreated)
                        {
                            if (Model.ThisUserPredictionsCount <= GlobalConstants.PredictionsLimit && match.GameweekId == GlobalConstants.CurrentWeek)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"td-4\"><a class=\"btn btn-block btn-primary text-white\"");
            BeginWriteAttribute("href", " href=\"", 3231, "\"", 3271, 3);
            WriteAttributeValue("", 3238, "/Predictions/Create?id=", 3238, 23, true);
#nullable restore
#line 86 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
WriteAttributeValue("", 3261, match.Id, 3261, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3270, "", 3271, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Create a prediction</a></td>\r\n");
#nullable restore
#line 87 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td></td>\r\n");
#nullable restore
#line 91 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                            }
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td scope=\"row\" class=\"td-4 text-center\">Prediction Created</td>\r\n");
#nullable restore
#line 96 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 99 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <br />\r\n");
#nullable restore
#line 103 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Matches\Fixtures.cshtml"
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
