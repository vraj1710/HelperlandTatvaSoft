#pragma checksum "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28be032527bcc22d59f96fe30026e2c692d1603b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__firsttabpopup), @"mvc.1.0.view", @"/Views/Shared/_firsttabpopup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28be032527bcc22d59f96fe30026e2c692d1603b", @"/Views/Shared/_firsttabpopup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8995312fe45941a1721dc7e861d85656cb9d2e70", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__firsttabpopup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<helperland_1.Models.upcomingservicelist>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-sm-6\">\r\n    <div class=\"vr\">\r\n        <p class=\"m-0 font-weight-bold\">");
#nullable restore
#line 5 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                   Write(Model.ServiceStartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Duration : </span> ");
#nullable restore
#line 6 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                               Write(Model.ServiceHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hrs</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>ServiceId : </span> ");
#nullable restore
#line 9 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                Write(Model.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 11 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
          

            int num = Model.ServiceExtraId;
            String s = num.ToString();
            String vr = "";
            for (int i = 0; i < 5; i++)
            {

                String ch = s.Substring(i, 1);
                int xx = int.Parse(ch);
                Console.WriteLine(ch);
                Console.WriteLine(xx);

                switch (xx)
                {
                    case 0:
                        vr = vr + "    ";
                        break;

                    case 1:
                        vr = vr + "   " + "Inside-cabinets";
                        break;

                    case 2:
                        vr = vr + "   " + "Inside-fridge";
                        break;
                    case 3:
                        vr = vr + "   " + "Inside-oven";
                        break;
                    case 4:
                        vr = vr + "  " + "Laundry-wash & dry";
                        break;
                    case 5:
                        vr = vr + "   " + "Interior-windows";
                        break;
                    default:
                        vr = "error";
                        break;
                }


            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p><span>Extras : ");
#nullable restore
#line 55 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                     Write(vr);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></p>\r\n        <p><span>Total Payment : </span>$");
#nullable restore
#line 56 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                    Write(Model.SubTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>Customer Name : </span>");
#nullable restore
#line 59 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                   Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 59 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                                    Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Service Address : </span>");
#nullable restore
#line 60 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                     Write(Model.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 60 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
                                                          Write(Model.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Distance : </span>27m</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>comments</span></p>\r\n        <p>");
#nullable restore
#line 65 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
      Write(Model.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"justify-content-start my-2 d-flex\">\r\n        <button type=\"button\" class=\"btn-accept btn-complete acceptbtn\"");
            BeginWriteAttribute("srid", " srid=\"", 2211, "\"", 2241, 1);
#nullable restore
#line 68 "D:\Tatva_Helperland\helperland_1\Views\Shared\_firsttabpopup.cshtml"
WriteAttributeValue("", 2218, Model.ServiceRequestId, 2218, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Accept</button>
    </div>
</div>
<div class=""col-sm-6"">
    <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3671.697915724384!2d72.49824711400726!3d23.034861321651203!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395e8352e403437b%3A0xdc9d4dae36889fb9!2sTatvaSoft!5e0!3m2!1sen!2sin!4v1646805036684!5m2!1sen!2sin""
            width=""100%"" height=""400px"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2643, "\"", 2661, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"></iframe>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<helperland_1.Models.upcomingservicelist> Html { get; private set; }
    }
}
#pragma warning restore 1591
