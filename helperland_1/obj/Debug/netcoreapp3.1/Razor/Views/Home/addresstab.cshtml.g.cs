#pragma checksum "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aabda841d181f55421b87923a697b4cf53b833a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_addresstab), @"mvc.1.0.view", @"/Views/Home/addresstab.cshtml")]
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
#line 1 "D:\Tatva_Helperland\helperland_1\Views\_ViewImports.cshtml"
using helperland_1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Tatva_Helperland\helperland_1\Views\_ViewImports.cshtml"
using helperland_1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Tatva_Helperland\helperland_1\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aabda841d181f55421b87923a697b4cf53b833a5", @"/Views/Home/addresstab.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8995312fe45941a1721dc7e861d85656cb9d2e70", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_addresstab : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<helperland_1.Models.UserAddress>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div id=""myAddressesTable"">
    <table class=""table tablee1 tb1"">
        <thead>
            <tr>
                <th scope=""col"">Addresses</th>
                <th scope=""col"" width=""100"">Actions</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <p class=\"mb-1\"><b>Address:</b><span>");
#nullable restore
#line 25 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
                                                    Write(item.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>,<span>");
#nullable restore
#line 25 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
                                                                                    Write(item.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>  </p>\r\n                    <p class=\"mb-1\"><b>Phone Number:</b>");
#nullable restore
#line 26 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
                                                   Write(item.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </td>\r\n                <td>\r\n                    <a data-toggle=\"modal\" id=\"editaddress\" data-target=\"#editAddressModal\" role=\"button\" data-id=\"");
#nullable restore
#line 29 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
                                                                                                              Write(item.AddressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <i class=\'fas fa-edit\' style=\'font-size:24px\'></i>\r\n                    </a>\r\n                    <a data-toggle=\"modal\" role=\"button\" data-target=\"#deleteAdressModal\" class=\"abc\" data-id=\"");
#nullable restore
#line 32 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
                                                                                                          Write(item.AddressId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                       \r\n                        <i class=\'fas fa-trash-alt\' style=\'font-size:24px\'></i>\r\n                    </a>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "D:\Tatva_Helperland\helperland_1\Views\Home\addresstab.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <a href=""#addNewAddressModal"" data-toggle=""modal"" role=""button"" class=""reschedule-btn rounded-pill text-light text-decoration-none px-2"">Add New address </a>
</div>
<!-- ---------------------------Add New Address PopUp Modal----------------------- -->
<div class=""modal fade"" id=""addNewAddressModal"" aria-hidden=""true"" aria-labelledby=""addNewAddressModalLabel2"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title me-3 clrr"" id=""addNewAddressModalLabel2"">Add New Address</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aabda841d181f55421b87923a697b4cf53b833a58129", async() => {
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-sm-6 mb-4"">
                            <div class=""form-group d-flex flex-column"">
                                <label for=""streetname"">Street Name</label>
                                <input type=""text"" placeholder=""Street Name"" id=""AddressLine1"" class=""bll ht pdd w-100"">
                            </div>
                        </div>
                        <div class=""col-sm-6 mb-4"">
                            <div class=""form-group d-flex flex-column"">
                                <label for=""housenumber"">House number</label>
                                <input type=""text"" placeholder=""House Number"" id=""AddressLine2"" name=""housenumber"" class=""bll ht pdd w-100"">
                            </div>
                        </div>
                        <div class=""col-sm-6 mb-4"">
                            <div class=""form-group d-flex flex-column"">
                                <label for=""posta");
                WriteLiteral(@"lcode"">Postal Code</label>
                                <input type=""text"" placeholder=""Postal Code""  id=""PostalCode"" name=""postalcode"" class=""bll ht pdd w-100"">
                            </div>
                        </div>
                        <div class=""col-sm-6"">
                            <div class=""form-group d-flex flex-column"">
                                <label for=""city"">City</label>
                                <div class=""d-inline-block"">
                                    <input type=""text"" id=""City"" placeholder=""City"" class=""ht bll pdd w-100"" />
                                    
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-6 mb-4"">
                            <div class=""form-group d-flex flex-column"">
                                <label for=""phonenumber"">Phone Number</label>
                                <div class=""d-flex"">
                        ");
                WriteLiteral(@"            <input type=""text"" name=""phonecode"" class=""bll ht pdd"" value=""+49"" disabled style=""max-width: 55px;"">
                                    <input type=""text"" placeholder=""Phone Number"" id=""Mobile"" name=""phonenumber"" class=""bll ht pdd"">
                                </div>
                            </div>
                        </div>
                    </div>
                    <button type=""button"" id=""addnewaddress"" data-dismiss=""modal"" class=""reschedule-btn rounded-pill bll text-light px-3 pdd"">
                        Add
                    </button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<!-- ------------------------Edit Address PopUp modal-------------------- -->
<div class=""modal fade"" id=""editAddressModal"" aria-hidden=""true"" aria-labelledby=""editAddressModalLabel2"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title me-3 clrr"" id=""editAddressModalLabel2"">Edit Address</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
");
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<!-- ------------------------Delete Address PopUp Modal---------------------------- -->
<div class=""modal fade"" id=""deleteAdressModal"" aria-hidden=""true"" aria-labelledby=""deleteAdressModalLabel2"" tabindex=""-1"">
    <div class=""modal-dialog modal-dialog-centered modal-md"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title me-3 clrr"" id=""deleteAdressModalLabel2"">Delete Address</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aabda841d181f55421b87923a697b4cf53b833a513859", async() => {
                WriteLiteral(@"
                    <p class=""mb-3 clrr"">Are You sure you want to delete this address?</p>
                    <button type=""button"" id=""deletebtn"" data-dismiss=""modal"" class=""mt-2 reschedule-btn rounded-pill bll text-light px-3 pdd"">
                        Delete
                    </button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<helperland_1.Models.UserAddress>> Html { get; private set; }
    }
}
#pragma warning restore 1591
