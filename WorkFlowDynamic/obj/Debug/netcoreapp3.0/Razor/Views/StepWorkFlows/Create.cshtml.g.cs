#pragma checksum "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27b96cd40efc7d6a622cfb9d49edf435d2da1c62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StepWorkFlows_Create), @"mvc.1.0.view", @"/Views/StepWorkFlows/Create.cshtml")]
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
#line 1 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\_ViewImports.cshtml"
using WorkFlowDynamic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\_ViewImports.cshtml"
using WorkFlowDynamic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27b96cd40efc7d6a622cfb9d49edf435d2da1c62", @"/Views/StepWorkFlows/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b748540ef9579e24394effefe3851d228a4d0363", @"/Views/_ViewImports.cshtml")]
    public class Views_StepWorkFlows_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WorkFlowDynamic.DataEntityTypes.StepWorkFlowSet>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n\r\n");
            WriteLiteral(@"<style>
    .row_position {
        border-collapse: separate;
        border-spacing: 0 15px;
    }

    table {
        border-collapse: collapse;
    }

    th {
        background-color: white;
        Color: black;
        border: 1px solid black;
    }

    td {
        width: 150px;
        text-align: center;
        border-top: 1px solid black;
        border: 1px solid black;
        padding: 5px;
        background-color: black;
        Color: white;
    }

    .geeks {
        border-right: hidden;
    }
</style>

<h1>WorkFlow: ");
#nullable restore
#line 48 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
         Write(ViewBag.SchemeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"card-body\" style=\"position: -webkit-sticky;\r\n  position: sticky; top: 0px;\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n");
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c627309", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 55 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("            <div class=\"d-inline p-2 bg-primary text-white\">\r\n");
#nullable restore
#line 66 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                  
                    var Activity = "Activité";
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c629361", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 69 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Activity);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6210916", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 70 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Activity);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div id=\"controllerSelected\" class=\"d-inline p-2 bg-dark text-white\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6212703", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 73 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Controller);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6214269", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 74 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Controller);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 74 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.controleurs;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div id=\"ActionSelected\" class=\"d-inline p-2 bg-primary text-white\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6216362", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 77 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Action);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6217924", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 78 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Action);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 78 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.services;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" id=\"SaveStep\" value=\"Enregistrer\" class=\"btn btn-primary\" />\r\n            </div>\r\n");
            WriteLiteral(@"        </div>
        <hr />

        <br /><br /><br />
        <div class=""col-md-12"">
            <div class=""form-group"">
                <input type=""submit"" id=""SaveScheme"" value=""Enregistrer le schéma"" class=""btn btn-primary"" />
            </div>
        </div>
    </div>
</div>
<br />
<div class=""card-body"" style=""z-index: 0;"">
    <h3 class=""text-center"">Liste des activités du workflow</h3>
    <div class=""table-responsive"">
");
            WriteLiteral(@"        <table class=""thead-dark table table-hover"">
            <tr>
                <th>
                    Nom de l'activité
                </th>
                <th>
                    Gestionnaire de Service
                </th>
                <th>
                    Service
                </th>
                <th>
                    Supprimer
                </th>
            </tr>
        </table>
        <table id=""myTable"" class=""row_position thead-dark table table-hover"">
        </table>
");
            WriteLiteral("    </div>\r\n</div>\r\n<br />\r\n<br />\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6221248", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "27b96cd40efc7d6a622cfb9d49edf435d2da1c6222288", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 131 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script type=""text/javascript"">
     $(document).ready(function () {
        // Début de l'initialisation
        $("".row_position"").sortable({
            delay: 150,
            stop: function () {
                var selectedData = new Array();
                $('.row_position>tr').each(function () {
                    selectedData.push($(this).attr(""id""));
                    console.log(""Line selected"");
                    console.log($(this).attr(""id""));
                });
                console.log(selectedData);
                 $.ajax({
                    url:'");
#nullable restore
#line 147 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                    Write(Url.Action("SaveOrderStepScheme", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type:'post',
                    data:{position:selectedData},
                    success:function(){
                        Swal.fire({
                          position: 'bottom-end',
                          icon: 'success',
                          title: 'Changement éffectuer avec succes',
                          showConfirmButton: false,
                          timer: 1500
                        })
                    }

                })
            }
        });

        $(""#SaveStep"").prop('disabled', true);

        RechargerActivites();
        // Fin initialisation

        // Pour gerer les changements automatiques des action en fonction du controleur choisi
        $(""#Controller"").change(function () {
            if ($(""#Controller"").val() != """") {
                $.ajax({
                    url: '");
#nullable restore
#line 173 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                     Write(Url.Action("GetDataActionSelected", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    contentType: 'application/html;charset=utf-8',
                    data: { controllerSelected: $('#Controller').val() },
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        var activityDropDown = $(""#Action"");
                        console.log(result)
                        $(""#Action option"").each(function (index, option) { option.remove() });
                        // activityDropDown.append($(""<option>"", { value: """", text: ""Sélectionner"" }));

                        $.each(result, function (index, obj) {
                            if (obj.action != null) {
                                $(""#SaveStep"").prop('disabled', false);
                                activityDropDown.append($(""<option>"", { value: obj.action, text: obj.description }));
                            }
                        })
                        var ordre = $(""#ordre"").val()
                  ");
                WriteLiteral(@"      if (ordre == """")
                            $(""#ordre"").val(1)
                        else
                            $(""#ordre"").val(parseInt(ordre)+1)
                    },
                    error: function (xhr, status) {

                    }
                })
            }
            else {
                $(""#SaveStep"").prop('disabled', true);
            }
        });

        // Valider une étape choisie
        $('#SaveStep').on('click', function () {
            //Try to get tbody first with jquery children. works faster!
            var tbody = $('#myTable').children('tbody');

            //Then if no tbody just select your table
            var table = tbody.length ? tbody : $('#myTable');
            var action = $(""#Action"").val();
            var controller = $(""#Controller"").val();
            var activity = $(""#Activity"").val();
            var flowModel = JSON.stringify({
                'cible': controller,
                'service': action,
     ");
                WriteLiteral("           \'activity\': activity\r\n            });\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \'");
#nullable restore
#line 223 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                 Write(Url.Action("GarderActivities", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                data: flowModel,
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {
                    console.clear()
                    console.log('In Ajax: Result: ')
                    console.log(result)
                    table.empty()
                    $.each(result, function (index, value) {
                        table.append('<tr id=' + value.id + '><td class=""geeks"">' + value.activity + '</td><td>' + value.cible + '</td><td>' + value.service + '</td>' +
                            '<td><button class=""btn-danger btn-sm"" onclick=SupprimerLigne('+value.id+') id='+value.id+'>Supprimer</button></td></tr>');
                    });

                    //$(""#ListEtape"").empty()
                    //$.each(result, function (index, value) {
                    //    $(""#ListEtape"").append('<div class=""col-sm-3"" style="""">' +
                    //        '<div class= ""card"" style = ""width");
                WriteLiteral(@": 15rem; margin-right: 5px; padding-right: 5px; border: 2px solid #007bff;"">' +
                    //        '<ul class=""list-group list-group-flush"">' +
                    //        '<li class=""list-group-item"">' + value.cible + '</li>' +
                    //        '<li class=""list-group-item"">' + value.service + '</li>' +
                    //        '<li class=""list-group-item"">' + value.ordre + '</li></ul>' +
                    //        '</div></div>')
                    //});

                    // $(""#SaveStep"").prop('disabled', true);
                }
            })
        });

        // Valider le schéma
        $(""#SaveScheme"").on('click', function () {
            $.ajax({
                type: ""GET"",
                url: '");
#nullable restore
#line 257 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                 Write(Url.Action("SaveSchemeInDatabase", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                success: function (result) {
                    console.log(""Resultat save"")
                    console.log(result)
                        location.href = '");
#nullable restore
#line 263 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                                    Write(Url.Action("Index", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'

                },
                error: function (response) {
                    console.log(""Resultat Error"")
                    console.log(response)
                }
            })
        });
    });

    function RechargerActivites() {
        //Try to get tbody first with jquery children. works faster!
        var tbody = $('#myTable').children('tbody');
        //Then if no tbody just select your table
        var table = tbody.length ? tbody : $('#myTable');
        console.log(""Actualisation de la page"");
        $.ajax({
            type: ""GET"",
            url: '");
#nullable restore
#line 282 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
             Write(Url.Action("GarderActivitiesLists", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
            contentType: ""application/json; charset=utf-8"",
            dataType: ""json"",
            success: function (result) {
                console.clear()
                console.log('In Ajax: Result: ')
                console.log(result)
                table.empty()
                $.each(result, function (index, value) {
                    table.append('<tr id=' + value.id + '><td class=""geeks"">' + value.activity + '</td><td>' + value.cible + '</td><td>' + value.service + '</td>' +
                        '<td><button class=""btn-danger btn-sm"" onclick=SupprimerLigne('+value.id+') id='+value.id+'>Supprimer</button></td></tr>');
                });

                //var activityDropDown = $(""#Controller"");
                //activityDropDown.append($(""<option>"", { value: """", text: ""Sélectionner"" }));
                //$(""#Controller"").val(""Sélectionner"");
                //$(""#ListEtape"").empty()
                //$.each(result, function (index, value) {
                //    $");
                WriteLiteral(@"(""#ListEtape"").append('<div class=""col-sm-3"" style="""">' +
                //        '<div class= ""card"" style = ""width: 15rem; margin-right: 5px; padding-right: 5px; border: 2px solid #007bff;"">' +
                //        '<ul class=""list-group list-group-flush"">' +
                //        '<li class=""list-group-item"">' + value.cible + '</li>' +
                //        '<li class=""list-group-item"">' + value.service + '</li>' +
                //        '<li class=""list-group-item"">' + value.ordre + '</li></ul>' +
                //        '</div></div>')
                //});

                //var ordre = $(""#ordre"").val()
                //$(""#ordre"").val(ordre)
            }
        })
    }

    function SupprimerLigne(id)
    {
        console.log(""Id line: "" + id)

        //Try to get tbody first with jquery children. works faster!
        var tbody = $('#myTable').children('tbody');

        //Then if no tbody just select your table
        var table = tbody.length ? tbody");
                WriteLiteral(@" : $('#myTable');
        Swal.fire({
            title: 'Etes-vous sûr?',
            text: ""de supprimé cette ligne"",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Non, annuler!',
            confirmButtonText: 'Oui, supprime-le!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: ""GET"",
                    url: '");
#nullable restore
#line 337 "C:\Users\LENOVO\Documents\WorkFlowEngine\WorkFlowDynamic\WorkFlowDynamic\Views\StepWorkFlows\Create.cshtml"
                     Write(Url.Action("RemoveActivities", "StepWorkFlows"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    data: { setpFlowsId: id },
                    contentType: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    success: function (result) {
                        console.clear()
                        console.log('In Ajax: Result: ')
                        console.log(result)
                        table.empty()
                        $.each(result, function (index, value) {
                            table.append('<tr id=' + value.id + '><td class=""geeks"">' + value.activity + '</td><td>' + value.cible + '</td><td>' + value.service + '</td>' +
                                '<td><button class=""btn-danger btn-sm"" onclick=SupprimerLigne('+value.id+') id='+value.id+'>Supprimer</button></td></tr>');
                        })
                        Swal.fire(
                            'Supprimé!',
                            'Activité supprimée',
                            'success'
                        )
           ");
                WriteLiteral("         }\r\n                })\r\n\r\n            }\r\n        });\r\n    }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WorkFlowDynamic.DataEntityTypes.StepWorkFlowSet> Html { get; private set; }
    }
}
#pragma warning restore 1591
