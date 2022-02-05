using helperland_1.Data;
using helperland_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace helperland_1.Controllers
{
    public class HomeController : Controller
    {

        private readonly Helperland_newContext _DbContext;

        public HomeController(Helperland_newContext DbContext)
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

            if (ModelState.IsValid)
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

        public IActionResult account()
        {
            return View();
        }

        [HttpPost]
        public IActionResult account(User user)
        {

            if (ModelState.IsValid)
            {
                User u = new User();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Mobile = user.Mobile;
                u.UserTypeId = 1;
                _DbContext.Users.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("faq");
            }

            return View();

        }

        [HttpPost]
        public IActionResult becomeahelper(User user)
        {
            if (ModelState.IsValid)
            {
                User u = new User();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Mobile = user.Mobile;
                u.UserTypeId = 2;
                _DbContext.Users.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("faq");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(user.Email) && p.Password.Equals(user.Password));
            if (get_user != null)
            {
                return RedirectToAction("aboutus");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult ForgotPassword(User model)
        {

            string resetCode = Guid.NewGuid().ToString();
            var verifyUrl = "/Account/ResetPassword/" + resetCode;
            // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var X = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(model.Email)).UserId;
            string baseUrl = string.Format("{0}://{1}",
                       HttpContext.Request.Scheme, HttpContext.Request.Host);
            var activationUrl = $"{baseUrl}/home/resetpassword?UserId={X}";

            var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(model.Email));
            if (get_user != null)
            {
                MailMessage ms = new MailMessage();
                ms.To.Add(model.Email);
                ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
                ms.Subject = "hello";
                ms.Body = activationUrl;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;


                NetworkCredential NetworkCred = new NetworkCredential("180320107554.ce.vraj@gmail.com", "vraj@2000");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Send(ms);
                ViewBag.Message = "mail has been sent successfully ";

                return RedirectToAction("index");
            }
            else
            {
                ViewBag.Message = "verify your email";
                return RedirectToAction("aboutus");
            }

        }


        public IActionResult resetpassword(int UserId) 
        {
            User user = _DbContext.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult resetpassword(User user)
        {


          //  var get_user = _DbContext.Users.Where(p => p.Email == user.Email).FirstOrDefault();

                
            
               
                _DbContext.Users.Update(user);
                _DbContext.SaveChanges();
                return RedirectToAction("aboutus");
            



            //using ()
            //{
            //    var user = context.RegisterUsers.Where(a => a.ResetPasswordCode == user.ResetCode).FirstOrDefault();
            //    if (user != null)
            //    {
            //        you can encrypt password here, we are not doing it
            //        user.Password = user.NewPassword;
            //        make resetpasswordcode empty string now
            //        user.ResetPasswordCode = "";
            //        to avoid validation issues, disable it
            //        context.Configuration.ValidateOnSaveEnabled = false;  
            //        context.SaveChanges();
            //        MailMessage = "New password updated successfully";
            //    }
            //}
            //
            //    using (User u = new User())
            //{
            //    var user = dc.Users.Where(a => a.ResetPasswordCode == u.ResetCode).FirstOrDefault();
            //    if (user != null)
            //    {
            //        user.Password = Crypto.Hash(model.NewPassword);
            //        user.ResetPasswordCode = "";
            //        dc.Configuration.ValidateOnSaveEnabled = false;
            //        dc.SaveChanges();
            //        message = "New password updated successfully";
            //    }
            //}
        }


    }
}
