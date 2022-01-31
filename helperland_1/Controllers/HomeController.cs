using helperland_1.Data;
using helperland_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace helperland_1.Controllers
{
    public class HomeController : Controller
    {

        private readonly helperland_newContext _DbContext;

        public HomeController(helperland_newContext DbContext)
        {
            _DbContext = DbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult faq()
        {
            return View();
        }

        public IActionResult prices()
        {
            return View();
        }

        public IActionResult contactus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult contactus(Contactu contactu)
        {

            if(ModelState.IsValid)
            { 
                 _DbContext.Contactus.Add(contactu);
                 _DbContext.SaveChanges();
                 return RedirectToAction("contactus");
            }

            return View();
        }


        public IActionResult aboutus()
        {
            return View();
        }



        public IActionResult becomeahelper()
        {
            return View();
        }


    }
}
