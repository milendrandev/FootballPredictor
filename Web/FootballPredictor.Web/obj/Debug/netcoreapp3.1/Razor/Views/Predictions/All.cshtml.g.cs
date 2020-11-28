#pragma checksum "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fab56a534bae3ee2b81e91cef453186c690cded7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Predictions_All), @"mvc.1.0.view", @"/Views/Predictions/All.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fab56a534bae3ee2b81e91cef453186c690cded7", @"/Views/Predictions/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96dfabdd470cad22f4070607fecb3db59464921c", @"/Views/_ViewImports.cshtml")]
    public class Views_Predictions_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FootballPredictor.Web.ViewModels.Predictions.ListOfPredictionsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
  
    this.ViewData["Title"] = "Predictions";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex justify-content-center"">
    <a class=""btn btn-block btn-primary text-white mb-3"" href=""/Predictions/Create"">Create a prediction</a>
</div>
<table class=""table table-hover"">
    <thead>
        <tr>
            <th scope=""col"">Home</th>
            <th scope=""col"">Predicte Result</th>
            <th scope=""col"">Away</th>
            <th scope=""col"">User</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
         foreach (var prediction in Model.Predictions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"table-light\">\r\n                <td>");
#nullable restore
#line 22 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
               Write(prediction.HomeTeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
               Write(prediction.HomeTeamGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 23 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
                                           Write(prediction.AwayTeamGoals);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
               Write(prediction.AwayTeamName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
               Write(prediction.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr class=\" table-light\">\r\n                <th scope=\"row\">Description</th>\r\n                <td> ");
#nullable restore
#line 29 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
                Write(prediction.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "D:\IT course\FootballPredictor\Web\FootballPredictor.Web\Views\Predictions\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n    <br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FootballPredictor.Web.ViewModels.Predictions.ListOfPredictionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
