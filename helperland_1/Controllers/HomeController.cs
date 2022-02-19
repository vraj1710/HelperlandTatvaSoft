using helperland_1.Data;
using helperland_1.Models;
using Microsoft.AspNetCore.Http;
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

        private readonly helperlandContext _DbContext;

        public HomeController(helperlandContext DbContext)
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
        public IActionResult contactus(ContactU contactu)
        {

            if (ModelState.IsValid)

            {
                _DbContext.ContactUs.Add(contactu);
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
            var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(user.Email));
            if (ModelState.IsValid && get_user == null)
            {
                User u = new User();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                u.Password = user.Password;
                u.Mobile = user.Mobile;
                u.UserTypeId = 1;
                u.CreatedDate = user.CreatedDate;
                _DbContext.Users.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("faq");
            }
            else
            {
                ViewBag.Error = TempData["error"];
                return View();
            }

        }

        [HttpPost]
        public IActionResult becomeahelper(User user)
        {
            var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(user.Email));
            if (ModelState.IsValid && get_user==null)
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
            else
            {
                ViewBag.Error = TempData["error"];
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(user.Email) && p.Password.Equals(user.Password));
            if (get_user != null)
            {
              //  HttpContext.Session.SetInt32("userid",get_user.UserId);
                return RedirectToAction("aboutus");
            }
            else
            {
                TempData["error"]="wrong user id and password";
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

            User userData = _DbContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            userData.Password = user.Password;
            _DbContext.Users.Update(userData);
            _DbContext.SaveChanges();
            return RedirectToAction("aboutus");

        }

        public IActionResult bookservice()
        {
            //var userid = HttpContext.Session.GetInt32("userid");
            //if (userid != null)
            //{
                return View();
            //}
            //return RedirectToAction("index");
         
        }


        public IActionResult address()
        {

            List<UserAddress> u = _DbContext.UserAddresses.Where(x => x.UserId == 3).ToList();
            System.Threading.Thread.Sleep(2000);
            return View(u);
        }

        [HttpPost]
        public string address([FromBody] UserAddress address)
        {
            address.UserId = 3;
            _DbContext.UserAddresses.Add(address);
            _DbContext.SaveChanges();
            return "true";
        }

        [HttpPost]
        public string Zipcode(string zip)
        {
            var isvalid = _DbContext.Users.Where(x => x.ZipCode == zip).FirstOrDefault();
            string a;
            if (isvalid != null)
            {
                 a = "true";
            }
            else
            {
                 a = "false";
            }
            return a;
        }

       
        public string savebooking([FromBody] ServiceRequest book)
        {
            book.UserId = 3;
            book.ServiceId = 8211;
            
            _DbContext.ServiceRequests.Add(book);
            _DbContext.SaveChanges();
            string message = "true";
            return message;
           
        }
     
      

    }
}
