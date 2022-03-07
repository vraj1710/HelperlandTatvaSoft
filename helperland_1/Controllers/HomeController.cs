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
            if (ModelState.IsValid && get_user == null)
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
            //  var get_user = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(user.Email) && p.Password.Equals(user.Password));
            var get_user = _DbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (get_user != null)
            {
                HttpContext.Session.SetInt32("userid", get_user.UserId);
                HttpContext.Session.SetString("username", get_user.FirstName + " " + get_user.LastName);
                return RedirectToAction("aboutus");
            }
            else
            {
                TempData["error"] = "wrong user id and password";
                return RedirectToAction("Index");
            }
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("userid");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ForgotPassword(User model)
        {
            var get_user = _DbContext.Users.Where(p => p.Email == model.Email).FirstOrDefault();
            if (get_user != null)
            {

                string resetCode = Guid.NewGuid().ToString();
                var verifyUrl = "/Account/ResetPassword/" + resetCode;
                // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                var X = _DbContext.Users.FirstOrDefault(p => p.Email.Equals(model.Email)).UserId;
                string baseUrl = string.Format("{0}://{1}",
                           HttpContext.Request.Scheme, HttpContext.Request.Host);
                var activationUrl = $"{baseUrl}/home/resetpassword?UserId={X}";



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
                TempData["error"] = "wrong email";
                //ViewBag.Message = "verify your email";
                return RedirectToAction("index");
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
            var userid = HttpContext.Session.GetInt32("userid");
            if (userid != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "please login first";

                return RedirectToAction("index");
            }
        }




        public IActionResult address()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");

            List<UserAddress> u = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            System.Threading.Thread.Sleep(2000);
            return View(u);
        }

        [HttpPost]
        public string address([FromBody] UserAddress address)
        {
            address.UserId = (int)HttpContext.Session.GetInt32("userid");
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
            //string one = "2019-02-06";
            //string two = book.Time;
            //DateTime newDateTime = Convert.ToDateTime(book.Date).Add(TimeSpan.Parse(book.Time));
            //book.ServiceStartDate = newDateTime;
            book.UserId = (int)HttpContext.Session.GetInt32("userid");
            book.ServiceId = 8211;
            _DbContext.ServiceRequests.Add(book);
            _DbContext.SaveChanges();

            var address = _DbContext.UserAddresses.Where(x => x.AddressId == book.AddId).FirstOrDefault();
            var email = _DbContext.Users.Where(x => x.UserId == book.UserId).FirstOrDefault();

            ServiceRequestAddress u = new ServiceRequestAddress();
            u.ServiceRequestId = book.ServiceRequestId;
            u.AddressLine1 = address.AddressLine1;
            u.AddressLine2 = address.AddressLine2;
            u.City = address.City;
            u.Email = email.Email;
            u.Mobile = address.Mobile;
            u.State = address.State;
            u.PostalCode = address.PostalCode;
            _DbContext.ServiceRequestAddresses.Add(u);
            _DbContext.SaveChanges();

            book.ServiceId = 1000 + book.ServiceRequestId;
            _DbContext.ServiceRequests.Update(book);
            _DbContext.SaveChanges();


            ServiceRequestExtra extra = new ServiceRequestExtra();
            extra.ServiceRequestId = book.ServiceRequestId;
            extra.ServiceExtraId = book.extraId;
            _DbContext.ServiceRequestExtras.Add(extra);
            _DbContext.SaveChanges();


            var query = from p in _DbContext.Users
                        where p.UserTypeId == 2
                        select p.Email;

            MailMessage ms = new MailMessage();

            ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
            ms.Subject = "cancel";
            ms.Body = "service request is cancelles";
            foreach (var item in query)
            {
                ms.To.Add(new MailAddress(item));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;


            NetworkCredential NetworkCred = new NetworkCredential("180320107554.ce.vraj@gmail.com", "vraj@2000");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Send(ms);


            //  string message = "true";
            return book.ServiceId.ToString();

        }



        public IActionResult servicehistory()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");

            //custommodal var1 = new custommodal();
            //var1.userAddresses = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            //var1.serviceRequests = _DbContext.ServiceRequests.Where(x => x.UserId == a).ToList();
            //var1.users = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            //List<UserAddress> u = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            List<ServiceRequest> x = _DbContext.ServiceRequests.Where(x => x.UserId == a && x.Status== null ).ToList();                                                                                                     
            return View(x);
        }


        public IActionResult SRservicehistory()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            List<ServiceRequest> x = _DbContext.ServiceRequests.Where(x => x.UserId == a && x.Status != null).ToList();
            return View(x);
          
        }

        public IActionResult myseetings()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            return View(u);
        }


        public string savechanges([FromBody] User book)
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            u.FirstName = book.FirstName;
            u.LastName = book.LastName;
            u.Mobile = book.Mobile;
            _DbContext.Users.Update(u);
            _DbContext.SaveChanges();

            HttpContext.Session.SetString("username", u.FirstName + " " + u.LastName);
            return "true";
        }


        public string changepassword([FromBody] User pass)
        {
            if (ModelState.IsValid)
            {
                var a = (int)HttpContext.Session.GetInt32("userid");
                User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
                if (u.Password == pass.Password)
                {
                    u.Password = pass.Newpassword;
                    _DbContext.Users.Update(u);
                    _DbContext.SaveChanges();
                    return "true";
                }
                return "false";

            }
            return "false";
        }


        public IActionResult addresstab()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            List<UserAddress> u = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            System.Threading.Thread.Sleep(2000);
            return View(u);
        }

        public string deleteaddress(int del)
        {
            UserAddress getaddress = _DbContext.UserAddresses.Where(x => x.AddressId == del).FirstOrDefault();
            _DbContext.UserAddresses.Remove(getaddress);
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult editaddress(int edit)
        {
            UserAddress getaddress = _DbContext.UserAddresses.Where(x => x.AddressId == edit).FirstOrDefault();
            return View(getaddress);
        }

        public string updateaddress([FromBody] UserAddress change)
        {
            UserAddress getaddress = _DbContext.UserAddresses.Where(x => x.AddressId == change.AddressId).FirstOrDefault();

            getaddress.AddressLine1 = change.AddressLine1;
            getaddress.AddressLine2 = change.AddressLine2;
            getaddress.PostalCode = change.PostalCode;
            getaddress.City = change.City;
            getaddress.Mobile = change.Mobile;
            _DbContext.UserAddresses.Update(getaddress);
            _DbContext.SaveChanges();
            return "true";

        }

        public IActionResult favpros()
        {
            return View();
        }

        public IActionResult Detailsmodal(int zip)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                        join ServiceRequestAddress in _DbContext.ServiceRequestAddresses on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                        where ServiceRequest.ServiceRequestId == zip
                        select new custommodal
                        {
                           ServiceRequestId = ServiceRequest.ServiceRequestId,
                           ServiceStartDate= ServiceRequest.ServiceStartDate,
                           SubTotal = ServiceRequest.SubTotal,
                           AddressLine1 = ServiceRequestAddress.AddressLine1,
                           AddressLine2 = ServiceRequestAddress.AddressLine2,
                           Email = ServiceRequestAddress.Email,
                           Mobile = ServiceRequestAddress.Mobile,
                           ServiceHours = ServiceRequest.ServiceHours,
                           HasPets = ServiceRequest.HasPets

                        }).Single();


            return View(query);
        }

        public object cancelSR([FromBody] ServiceRequest book)
        {
            ServiceRequest detail = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            detail.Status = 0;
            detail.Comments = book.Comments;
            _DbContext.ServiceRequests.Update(detail);
            _DbContext.SaveChanges();


             var query = from u in _DbContext.Users
                        where u.UserTypeId == 2
                        select u.Email;

            MailMessage ms = new MailMessage();

            ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
            ms.Subject = "cancel";
            ms.Body = "service request is cancelles";
            foreach (var item in query)
            {
                ms.To.Add(new MailAddress(item));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;


            NetworkCredential NetworkCred = new NetworkCredential("180320107554.ce.vraj@gmail.com", "vraj@2000");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Send(ms);

            return query;
        }

    }
}
