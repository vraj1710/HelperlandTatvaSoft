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
                u.IsActive = true;
                u.CreatedDate = user.CreatedDate;
                _DbContext.Users.Add(u);
                _DbContext.SaveChanges();
                return RedirectToAction("index");
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
                u.IsActive = false;
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
                if (get_user.UserTypeId == 1 && get_user.IsActive == true)
                {
                    HttpContext.Session.SetInt32("userid", get_user.UserId);
                    HttpContext.Session.SetString("username", get_user.FirstName + " " + get_user.LastName);
                    HttpContext.Session.SetInt32("usertypeid", get_user.UserTypeId);
                    return RedirectToAction("index");
                }
                else if (get_user.UserTypeId == 2 && get_user.IsActive == true)
                {
                    HttpContext.Session.SetInt32("userid", get_user.UserId);
                    HttpContext.Session.SetString("username", get_user.FirstName + " " + get_user.LastName);
                    HttpContext.Session.SetInt32("usertypeid", get_user.UserTypeId);
                    return RedirectToAction("upcomingsetting");
                }
                else if (get_user.UserTypeId == 3 && get_user.IsActive == true)
                {
                    HttpContext.Session.SetInt32("userid", get_user.UserId);
                    HttpContext.Session.SetString("username", get_user.FirstName + " " + get_user.LastName);
                    HttpContext.Session.SetInt32("usertypeid", get_user.UserTypeId);
                    return RedirectToAction("adminUM");
                }

                else
                {
                    TempData["error"] = "you cannot sign in as your account is deactivated ";
                    return RedirectToAction("Index");
                }
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
            var a = (int)HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            address.UserId = a;
            address.Email = u.Email;
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
            //var xx = book.Date;
            //DateTime newDateTime = Convert.ToDateTime(book.Date).Add(TimeSpan.Parse(book.Time));
            //book.ServiceStartDate = newDateTime;
            // DateTime orderDateTime = xx.ToDateTime(book.Time);
            book.UserId = (int)HttpContext.Session.GetInt32("userid");
            book.ServiceId = 8211;
            book.ServiceStartDate = DateTime.Parse(book.Date);
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
            var a = HttpContext.Session.GetInt32("userid");

            //custommodal var1 = new custommodal();
            //var1.userAddresses = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            //var1.serviceRequests = _DbContext.ServiceRequests.Where(x => x.UserId == a).ToList();
            //var1.users = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            //List<UserAddress> u = _DbContext.UserAddresses.Where(x => x.UserId == a).ToList();
            if (a != null)
            {
                //List<ServiceRequest> x = _DbContext.ServiceRequests.Where(x => x.UserId == a && (x.Status == null || x.Status == 2) && x.ServiceStartDate > DateTime.Now).ToList();
                //return View(x);

                var query = from ServiceRequest in _DbContext.ServiceRequests
                            join User in _DbContext.Users
                            on ServiceRequest.ServiceProviderId equals User.UserId into abc
                            from rate in abc.DefaultIfEmpty()
                            where ServiceRequest.UserId == a && (ServiceRequest.Status == null || ServiceRequest.Status == 2) && ServiceRequest.ServiceStartDate > DateTime.Now
                            select new upcomingservicelist
                            {
                                FirstName = rate.FirstName,
                                LastName = rate.LastName,
                                ServiceId = ServiceRequest.ServiceId,
                                ServiceStartDate = ServiceRequest.ServiceStartDate,
                                SubTotal = ServiceRequest.SubTotal,
                                ServiceRequestId = ServiceRequest.ServiceRequestId,
                                ServiceProviderId=ServiceRequest.ServiceProviderId
                            };

                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }


        public IActionResult SRservicehistory()
        {
            var a = HttpContext.Session.GetInt32("userid");
            //List<ServiceRequest> x = _DbContext.ServiceRequests.Where(x => x.UserId == a && x.Status != null).ToList();

            if (a != null)
            {
                var query = from sr in _DbContext.ServiceRequests
                            join user in _DbContext.Users on sr.ServiceProviderId equals user.UserId into x
                            from user in x.DefaultIfEmpty()
                            join r in _DbContext.Ratings on sr.ServiceRequestId equals r.ServiceRequestId into abc
                            from rate in abc.DefaultIfEmpty()
                            where sr.UserId == a  &&( sr.ServiceStartDate<DateTime.Now || sr.Status==1) /*&& sr.Status != null*/
                            select new Ratingcustom
                            {
                                ServiceId = sr.ServiceId,
                                ServiceStartDate = sr.ServiceStartDate,
                                Ratings = rate == null ? 0 : rate.Ratings,
                                TotalCost = sr.TotalCost,
                                Status = sr.Status,
                                ServiceProviderId = sr.ServiceProviderId,
                                ServiceRequestId = sr.ServiceRequestId,
                                FirstName = user == null ? "" : user.FirstName,
                                LastName = user == null ? "" : user.LastName
                            };
                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }

        public IActionResult myseetings()
        {
            var a = HttpContext.Session.GetInt32("userid");
            if (a != null)
            {
                User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
                return View(u);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }


        public string savechanges([FromBody] User book)
        {

            var a = (int)HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            u.FirstName = book.FirstName;
            u.LastName = book.LastName;
            u.Mobile = book.Mobile;
            u.DateOfBirth = book.DateOfBirth;
            _DbContext.Users.Update(u);
            _DbContext.SaveChanges();

            HttpContext.Session.SetString("username", u.FirstName + " " + u.LastName);
            return "true";
        }


        public string changepassword([FromBody] User pass)
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
            var a = HttpContext.Session.GetInt32("userid");
            if (a != null)
            {
                var query = (from user in _DbContext.Users
                             join FavoriteAndBlocked in _DbContext.FavoriteAndBlockeds
                             on user.UserId equals FavoriteAndBlocked.UserId      
                             where FavoriteAndBlocked.TargetUserId == a
                             select new blockcustom
                             {
                                 Id = FavoriteAndBlocked.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 IsBlocked = FavoriteAndBlocked.IsBlocked,
                                 UserId = user.UserId,
                                 Ratings= (from Rating in _DbContext.Ratings where Rating.RatingTo.Equals(user.UserId) select Rating.Ratings).Average(),
                                 totalconunt= (from Rating in _DbContext.Ratings where Rating.RatingTo.Equals(user.UserId) select Rating.Ratings).Count()
                             }).ToList();
                return View(query);
                
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }

        }

        public IActionResult Detailsmodal(int zip)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddresses on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join ServiceRequestExtra in _DbContext.ServiceRequestExtras on ServiceRequest.ServiceRequestId equals ServiceRequestExtra.ServiceRequestId
                         where ServiceRequest.ServiceRequestId == zip
                         select new custommodal
                         {
                             //spFirstName = spuser == null ? "" : spuser.FirstName,
                             ServiceExtraId = (int)(ServiceRequestExtra == null ? 0 : ServiceRequestExtra.ServiceExtraId),
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
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

            //"Hello " + _objuserdetail.FirstName + ",\n\nYour can reset your password by clicking the link below \n" +
            //    ResetUrl + "\nThank you for visiting Helperland \n\nRegards,\nHelperland Team";

            var query = from u in _DbContext.Users
                        where u.UserTypeId == 2
                        select u.Email;

            MailMessage ms = new MailMessage();

            ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
            ms.Subject = "cancel";
            ms.Body = "service request " + detail.ServiceId + " has been cancelled by the customer " + "\nThank you for visiting Helperland \n\nRegards,\nHelperland Team";
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

        public string rescheduleSR([FromBody] ServiceRequest book)
        {

            ServiceRequest detail = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            int result = DateTime.Compare(DateTime.Now, DateTime.Parse(book.Date));
            if (result == -1)
            {
                detail.ServiceStartDate = DateTime.Parse(book.Date);
                _DbContext.ServiceRequests.Update(detail);
                _DbContext.SaveChanges();
                return "true";
            }
            else if (result == 0)
            {
                return "false";
            }
            else
            {
                return "false";
            }

        }

        public IActionResult calender()
        {
            return View();
        }

        public JsonResult calenderapi()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");

            var query = (from sr in _DbContext.ServiceRequests
                         join u in _DbContext.Users
                         on sr.UserId equals u.UserId
                         where sr.ServiceProviderId == a && sr.Status!=1 && sr.ServiceStartDate>DateTime.Now
                         select new calender
                         {
                             id = sr.ServiceRequestId,
                             title = u.FirstName + " "+u.LastName,
                             start = sr.ServiceStartDate.ToString("yyyy/MM/dd"),
                             end = sr.ServiceStartDate.ToString("yyyy/MM/dd"),
                             color = "#17a2b8",
                             textColor = "white",

                         }).ToList();

            return Json(query);
        }
        public IActionResult upcomingservice()
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();


            if (u != null && u.UserTypeId == 2)
            {
                //var query = (from ServiceRequest in _DbContext.ServiceRequests
                //             join ServiceRequestAddress in _DbContext.ServiceRequestAddresses on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                //             where ServiceRequest.ServiceRequestId == zip
                //             select new custommodal
                //join r in _DbContext.Ratings on sr.ServiceRequestId equals r.ServiceRequestId into abc
                //            from rate in abc.DefaultIfEmpty()
                //from sr in _db.ServiceRequests
                //join sraddress in _db.ServiceRequestAddresses on sr.ServiceRequestId equals sraddress.ServiceRequestId into srad
                //from Sra in srad.DefaultIfEmpty()
                //join user in _db.Users on sr.UserId equals user.UserId
                //join f in _db.FavoriteAndBlockeds on sr.UserId equals f.TargetUserId into fav
                //from f in fav.DefaultIfEmpty()
                //where sp.ZipCode == sr.ZipCode && sr.Status == 0 && (f.UserId == (int)HttpContext.Session.GetInt32("UserID_Session") || f.UserId == null) && (f.IsBlocked != true || f.IsBlocked == null)

                //var query = (from ServiceRequest in _DbContext.ServiceRequests
                //             join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                //             on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                //             join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                //             join fav in _DbContext.FavoriteAndBlockeds on ServiceRequest.UserId equals fav.TargetUserId into abc
                //             from favourite in abc.DefaultIfEmpty()
                //             where ServiceRequest.ZipCode == u.ZipCode && ServiceRequest.ServiceProviderId == null && (favourite.IsBlocked != true || favourite.IsBlocked==null) && (favourite.UserId==a || favourite.UserId==null)
                //             select new upcomingservicelist
                //             {
                //                 ServiceRequestId = ServiceRequest.ServiceRequestId,
                //                 ServiceId = ServiceRequest.ServiceId,
                //                 ServiceStartDate = ServiceRequest.ServiceStartDate,
                //                 FirstName = user.FirstName,
                //                 LastName = user.LastName,
                //                 AddressLine1 = ServiceRequestAddress.AddressLine1,
                //                 AddressLine2 = ServiceRequestAddress.AddressLine2,
                //                 ZipCode = ServiceRequest.ZipCode,
                //                 SubTotal = ServiceRequest.SubTotal,
                //                 City = ServiceRequestAddress.City
                //             }).ToList();

                //                join f in _db.FavoriteAndBlockeds on new { Uid = sr.UserId, SPid = id } equals new { Uid = f.TargetUserId, SPid = f.UserId } into abc
                //                from f in abc.DefaultIfEmpty()
                //                where sr.ZipCode == sp.ZipCode && sr.Status == 0 && (f.IsBlocked == false || f.IsBlocked == null)
                var query = from sr in _DbContext.ServiceRequests
                            join sa in _DbContext.ServiceRequestAddresses on sr.ServiceRequestId equals sa.ServiceRequestId
                            join ua in _DbContext.Users on sr.UserId equals ua.UserId
                            join f in _DbContext.FavoriteAndBlockeds on new { cid = sr.UserId, vi = a } equals new { cid = f.TargetUserId, vi = f.UserId } into abc
                            from f in abc.DefaultIfEmpty()
                            where sr.ZipCode == u.ZipCode && sr.Status == null && (f.IsBlocked == false || f.IsBlocked == null) && sr.ServiceStartDate >= DateTime.Now
                            select new upcomingservicelist
                            {
                                ServiceRequestId = sr.ServiceRequestId,
                                ServiceId = sr.ServiceId,
                                ServiceStartDate = sr.ServiceStartDate,
                                SubTotal = sr.SubTotal,

                                FirstName = ua.FirstName,
                                LastName = ua.LastName,

                                AddressLine1 = sa == null ? "" : sa.AddressLine1,
                                AddressLine2 = sa == null ? "" : sa.AddressLine2,
                                PostalCode = sa == null ? "" : sa.PostalCode,
                                City = sa == null ? "" : sa.City
                            };
                //var query = (from sr in _DbContext.ServiceRequests
                //             join sa in _DbContext.ServiceRequestAddresses on sr.ServiceRequestId equals sa.ServiceRequestId
                //             join us in _DbContext.Users on sr.UserId equals us.UserId
                //             join f in _DbContext.FavoriteAndBlockeds on new { Uid  =sr.UserId, SPid = u.UserId } equals new { Uid = f.TargetUserId, SPid = f.UserId } into abc
                //             from f in abc.DefaultIfEmpty()
                //             where sr.ZipCode == u.ZipCode && sr.Status == 0 && (f.IsBlocked == false || f.IsBlocked == null)
                //             select new upcomingservicelist
                //             {
                //                 ServiceRequestId = sr.ServiceRequestId,
                //                 ServiceId = sr.ServiceId,
                //                 ServiceStartDate = sr.ServiceStartDate,
                //                 SubTotal = sr.SubTotal,

                //                 FirstName = us.FirstName,
                //                 LastName = us.LastName,

                //                 AddressLine1 = sa == null ? "" : sa.AddressLine1,
                //                 AddressLine2 = sa == null ? "" : sa.AddressLine2,
                //                 PostalCode = sa == null ? "" : sa.PostalCode,
                //                 City = sa == null ? "" : sa.City
                //             });


                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }

        public IActionResult _firsttabpopup(int id)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join ServiceRequestExtra in _DbContext.ServiceRequestExtras
                         on ServiceRequest.ServiceRequestId equals ServiceRequestExtra.ServiceRequestId
                         join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceRequestId == id
                         select new upcomingservicelist
                         {
                             ServiceExtraId = (int)(ServiceRequestExtra == null ? 0 : ServiceRequestExtra.ServiceExtraId),
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).Single();

            return PartialView(query);

        }


        //0 = cancel
        //1 = complete
        //2 = pending
        public string acceptservice(int id)
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            User user = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            // var x = user.Email;
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            sr.ServiceProviderId = a;
            sr.Status = 2;
            sr.SpacceptedDate = DateTime.Now;
            _DbContext.ServiceRequests.Update(sr);
            _DbContext.SaveChanges();

            var query = from u in _DbContext.Users
                        where u.UserTypeId == 2 && u.Email != user.Email && u.ZipCode == sr.ZipCode
                        select u.Email;

            MailMessage ms = new MailMessage();

            ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
            ms.Subject = "accept";
            ms.Body = "service request " + sr.ServiceId + " has been accepted and bo more available " + "\nThank you for visiting Helperland \n\nRegards,\nHelperland Team";
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

            return "true";
        }

        public IActionResult upcomingsetting()
        {
            var a = HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();

            if (a != null && u.UserTypeId == 2)
            {
                USmysetting var1 = new USmysetting();
                var1.Users = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
                var1.UserAddresses = _DbContext.UserAddresses.Where(x => x.UserId == a).FirstOrDefault();
                return View(var1);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }
        [HttpPost]
        public IActionResult upcomingsetting(USmysetting detail)
        {
            var a = (int)HttpContext.Session.GetInt32("userid");
            //var y = HttpContext.Request.Form["radioInput"];
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();
            //u.Gender = Int16.Parse(y);
            u.Gender = detail.Users.Gender;
            u.FirstName = detail.Users.FirstName;
            u.LastName = detail.Users.LastName;
            u.Mobile = detail.Users.Mobile;
            u.ZipCode = detail.UserAddresses.PostalCode;
            u.DateOfBirth = detail.Users.DateOfBirth;
            _DbContext.Users.Update(u);
            _DbContext.SaveChanges();



            UserAddress add = _DbContext.UserAddresses.Where(x => x.UserId == a).FirstOrDefault();
            if (add != null)
            {

                add.AddressLine1 = detail.UserAddresses.AddressLine1;
                add.AddressLine2 = detail.UserAddresses.AddressLine2;
                add.City = detail.UserAddresses.City;
                add.PostalCode = detail.UserAddresses.PostalCode;
                add.Mobile = detail.Users.Mobile;
                _DbContext.UserAddresses.Update(add);
                _DbContext.SaveChanges();
            }
            else
            {
                UserAddress ua = new UserAddress();
                ua.UserId = a;
                ua.AddressLine1 = detail.UserAddresses.AddressLine1;
                ua.AddressLine2 = detail.UserAddresses.AddressLine2;
                ua.City = detail.UserAddresses.City;
                ua.PostalCode = detail.UserAddresses.PostalCode;
                ua.Mobile = detail.Users.Mobile;
                ua.Email = u.Email;
                _DbContext.UserAddresses.Add(ua);
                _DbContext.SaveChanges();

            }

            HttpContext.Session.SetString("username", u.FirstName + " " + u.LastName);
            TempData["error"] = "updated";
            return View();

            //userData.Password = user.Password;s
            //_DbContext.Users.Update(userData);
            //_DbContext.SaveChanges();
        }

        public string USchangepassword([FromBody] User pass)
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

        public IActionResult upcomingservicetab()
        {
            var a = HttpContext.Session.GetInt32("userid");
            User u = _DbContext.Users.Where(x => x.UserId == a).FirstOrDefault();

            if (a != null && u.UserTypeId == 2)
            {
                var query = (from ServiceRequest in _DbContext.ServiceRequests
                             join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                             on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                             join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                             where ServiceRequest.ServiceProviderId == a && ServiceRequest.Status == 2 && ServiceRequest.ServiceStartDate >= DateTime.Now
                             select new upcomingservicelist
                             {
                                 ServiceRequestId = ServiceRequest.ServiceRequestId,
                                 ServiceId = ServiceRequest.ServiceId,
                                 ServiceStartDate = ServiceRequest.ServiceStartDate,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 AddressLine1 = ServiceRequestAddress.AddressLine1,
                                 AddressLine2 = ServiceRequestAddress.AddressLine2,
                                 ZipCode = ServiceRequest.ZipCode,
                                 SubTotal = ServiceRequest.SubTotal,
                                 City = ServiceRequestAddress.City
                             }).ToList();
                return View(query);
            }
            else
            {
                TempData["error"] = "not a valid user";
                return RedirectToAction("index");
            }
        }


        public string cancelservicerequest(int id)
        {
            // var a = (int)HttpContext.Session.GetInt32("userid");
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            sr.ServiceProviderId = null;
            sr.SpacceptedDate = DateTime.Now;
            sr.Status = null;
            _DbContext.ServiceRequests.Update(sr);
            _DbContext.SaveChanges();

            return "true";
        }

        public IActionResult blockcustomer()
        {
            var a = HttpContext.Session.GetInt32("userid");

            if (a != null)
            {
                //var query = (from ServiceRequest in _DbContext.ServiceRequests
                //             join User in _DbContext.Users
                //             on ServiceRequest.UserId equals User.UserId 
                //             where ServiceRequest.ServiceProviderId == a
                //             select new blockcustom
                //             {
                //                 FirstName=User.FirstName,
                //                 LastName=User.LastName
                //             }).ToList();
                //return View(query);

                //var query = (from ServiceRequest in _DbContext.ServiceRequests
                //             join User in _DbContext.Users
                //             on ServiceRequest.UserId equals User.UserId
                //             join FavoriteAndBlocked in _DbContext.FavoriteAndBlockeds
                //             on ServiceRequest.UserId equals FavoriteAndBlocked.TargetUserId into abc
                //             from FavoriteAndBlocked in abc.DefaultIfEmpty()
                //             where ServiceRequest.ServiceProviderId == a
                //             select new blockcustom
                //             {
                //                 FirstName = User.FirstName,
                //                 LastName = User.LastName,
                //                 IsBlocked = FavoriteAndBlocked.IsBlocked,
                //                 UserId = User.UserId

                //             }).ToList();

                var query = (from user in _DbContext.Users
                             join FavoriteAndBlocked in _DbContext.FavoriteAndBlockeds
                             on user.UserId equals FavoriteAndBlocked.TargetUserId
                             where FavoriteAndBlocked.UserId == a
                             select new blockcustom
                             {
                                 Id = FavoriteAndBlocked.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 IsBlocked = FavoriteAndBlocked.IsBlocked,
                                 UserId = user.UserId
                             }).ToList();

                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }
        public IActionResult USservicehistory()
        {
            var a = HttpContext.Session.GetInt32("userid");

            if (a != null)
            {

                var query = (from ServiceRequest in _DbContext.ServiceRequests
                             join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                             on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                             join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                             where ServiceRequest.ServiceProviderId == a && ServiceRequest.Status == 1
                             select new upcomingservicelist
                             {
                                 ServiceRequestId = ServiceRequest.ServiceRequestId,
                                 ServiceId = ServiceRequest.ServiceId,
                                 ServiceStartDate = ServiceRequest.ServiceStartDate,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 AddressLine1 = ServiceRequestAddress.AddressLine1,
                                 AddressLine2 = ServiceRequestAddress.AddressLine2,
                                 ZipCode = ServiceRequest.ZipCode,
                                 SubTotal = ServiceRequest.SubTotal,
                                 City = ServiceRequestAddress.City
                             }).ToList();
                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }

        public IActionResult _upcomingshpopup(int id)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceRequestId == id
                         select new upcomingservicelist
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).Single();

            return PartialView(query);

        }
        public IActionResult ratings()
        {
            var a = HttpContext.Session.GetInt32("userid");
            if (a != null)
            {
                var query = (from User in _DbContext.Users
                             join Rating in _DbContext.Ratings
                             on User.UserId equals Rating.RatingFrom
                             join ServiceRequest in _DbContext.ServiceRequests
                             on Rating.ServiceRequestId equals ServiceRequest.ServiceRequestId
                             where Rating.RatingTo == a
                             select new Ratingcustom
                             {
                                 ServiceId = ServiceRequest.ServiceId,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 RatingDate = (DateTime)Rating.RatingDate,
                                 Ratings = Rating.Ratings,
                                 Comments = Rating.Comments
                             }).ToList();

                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }

        public IActionResult _popup(int id)
        {
            //UserAddress getaddress = _DbContext.UserAddresses.Where(x => x.AddressId == id).FirstOrDefault();
            //return View(getaddress);
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         join ServiceRequestExtra in _DbContext.ServiceRequestExtras on ServiceRequest.ServiceRequestId equals ServiceRequestExtra.ServiceRequestId
                         join user in _DbContext.Users on ServiceRequest.UserId equals user.UserId
                         where ServiceRequest.ServiceRequestId == id
                         select new upcomingservicelist
                         {
                             ServiceExtraId = (int)(ServiceRequestExtra == null ? 0 : ServiceRequestExtra.ServiceExtraId),
                             ServiceRequestId = ServiceRequest.ServiceRequestId,
                             ServiceId = ServiceRequest.ServiceId,
                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,
                             SubTotal = ServiceRequest.SubTotal,
                             City = ServiceRequestAddress.City
                         }).Single();

            return PartialView(query);
        }

        public string completeservice(int id)
        {
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            sr.Status = 1;
            _DbContext.ServiceRequests.Update(sr);
            _DbContext.SaveChanges();

            var aa = _DbContext.FavoriteAndBlockeds.Where(x => x.UserId == sr.ServiceProviderId && x.TargetUserId == sr.UserId).FirstOrDefault();

            if (aa == null)
            {
                FavoriteAndBlocked fav = new FavoriteAndBlocked();
                fav.UserId = (int)sr.ServiceProviderId;
                fav.TargetUserId = sr.UserId;
                fav.IsFavorite = false;
                fav.IsBlocked = false;
                _DbContext.FavoriteAndBlockeds.Add(fav);
                _DbContext.SaveChanges();
            }


            return "true";
        }

        public IActionResult blockcust(int id)
        {
            var b = _DbContext.FavoriteAndBlockeds.Where(x => x.Id == id).FirstOrDefault();
            b.IsBlocked = true;
            _DbContext.FavoriteAndBlockeds.Update(b);
            _DbContext.SaveChanges();
            return RedirectToAction("blockcustomer");
        }

        public IActionResult unblockcust(int id)
        {
            var b = _DbContext.FavoriteAndBlockeds.Where(x => x.Id == id).FirstOrDefault();
            b.IsBlocked = false;
            _DbContext.FavoriteAndBlockeds.Update(b);
            _DbContext.SaveChanges();
            return RedirectToAction("blockcustomer");

        }

        public IActionResult _ratespmodel(int spid)
        {
            User u = _DbContext.Users.Where(x => x.UserId == spid).FirstOrDefault();
            return PartialView(u);
        }

        public string rateserviceprovider([FromBody] Rating rate)
        {

            var a = (int)HttpContext.Session.GetInt32("userid");
            Rating r = _DbContext.Ratings.Where(x => x.ServiceRequestId == rate.ServiceRequestId).FirstOrDefault();

            if (r != null)
            {
                r.Ratings = rate.Ratings;
                r.Comments = rate.Comments;
                r.Friendly = rate.Friendly;
                r.OnTimeArrival = rate.OnTimeArrival;
                r.QualityOfService = rate.QualityOfService;
                r.RatingDate = DateTime.Now;
                _DbContext.Ratings.Update(r);
            }
            else
            {
                rate.RatingFrom = a;
                rate.RatingDate = DateTime.Now;
                _DbContext.Ratings.Add(rate);
            }
            _DbContext.SaveChanges();
            return "true";
        }

        public IActionResult adminUM()
        {
            var a = HttpContext.Session.GetInt32("userid");
            if (a != null)
            {
                List<User> x = _DbContext.Users.Where(x => x.UserTypeId != 3).ToList();
                return View(x);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }


        public IActionResult adminSR()
        {
            var a = HttpContext.Session.GetInt32("userid");

            if (a != null)
            {
                //var query = (from ServiceRequest in _DbContext.ServiceRequests
                //             join User in _DbContext.Users
                //             on ServiceRequest.UserId equals User.UserId
                //             join FavoriteAndBlocked in _DbContext.FavoriteAndBlockeds
                //             on ServiceRequest.UserId equals FavoriteAndBlocked.TargetUserId into abc
                //             from FavoriteAndBlocked in abc.DefaultIfEmpty()
                //             where ServiceRequest.ServiceProviderId == a
                //             select new blockcustom
                //             {
                //                 FirstName = User.FirstName,
                //                 LastName = User.LastName,
                //                 IsBlocked = FavoriteAndBlocked.IsBlocked,
                //                 UserId = User.UserId

                //             }).ToList();
                var query = from ServiceRequest in _DbContext.ServiceRequests
                            join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                            on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                            join user in _DbContext.Users
                            on ServiceRequest.UserId equals user.UserId
                            join Rating in _DbContext.Ratings
                            on ServiceRequest.ServiceRequestId equals Rating.ServiceRequestId into abc
                            from Rating in abc.DefaultIfEmpty()
                            join spuser in _DbContext.Users
                            on ServiceRequest.ServiceProviderId equals spuser.UserId into xyz
                            from spuser in xyz.DefaultIfEmpty()
                            select new upcomingservicelist
                            {
                                ServiceRequestId = ServiceRequest.ServiceRequestId,
                                ServiceId = ServiceRequest.ServiceId,
                                ServiceHours = ServiceRequest.ServiceHours,
                                ServiceStartDate = ServiceRequest.ServiceStartDate,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Comments = ServiceRequest.Comments,
                                AddressLine1 = ServiceRequestAddress.AddressLine1,
                                AddressLine2 = ServiceRequestAddress.AddressLine2,
                                ZipCode = ServiceRequest.ZipCode,
                                SubTotal = ServiceRequest.SubTotal,
                                City = ServiceRequestAddress.City,
                                Ratings = Rating == null ? 0 : Rating.Ratings,
                                Status = ServiceRequest.Status,
                                spFirstName = spuser == null ? "" : spuser.FirstName,
                                spLastName = spuser == null ? "" : spuser.LastName,
                                usertypeid = user.UserTypeId
                            };

                return View(query);
            }
            else
            {
                TempData["error"] = "please login first";
                return RedirectToAction("index");
            }
        }

        public IActionResult active(int id)
        {
            User u = _DbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            u.IsActive = true;
            _DbContext.Users.Update(u);
            _DbContext.SaveChanges();
            return RedirectToAction("adminUM");
        }

        public IActionResult inactive(int id)
        {
            User u = _DbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            u.IsActive = false;
            _DbContext.Users.Update(u);
            _DbContext.SaveChanges();
            return RedirectToAction("adminUM");
        }

        public IActionResult _admineditandreschedule(int id)
        {
            var query = (from ServiceRequest in _DbContext.ServiceRequests
                         join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
                         on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
                         where ServiceRequest.ServiceRequestId == id
                         select new upcomingservicelist
                         {
                             ServiceRequestId = ServiceRequest.ServiceRequestId,

                             ServiceHours = ServiceRequest.ServiceHours,
                             ServiceStartDate = ServiceRequest.ServiceStartDate,

                             Comments = ServiceRequest.Comments,
                             AddressLine1 = ServiceRequestAddress.AddressLine1,
                             AddressLine2 = ServiceRequestAddress.AddressLine2,
                             ZipCode = ServiceRequest.ZipCode,

                             City = ServiceRequestAddress.City
                         }).Single();
            return PartialView(query);
        }

        public string adminsavechanges([FromBody] upcomingservicelist book)
        {
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            sr.ServiceStartDate = DateTime.Parse(book.Date);
            sr.Comments = book.Comments;
            sr.ZipCode = book.PostalCode;
            _DbContext.ServiceRequests.Update(sr);
            _DbContext.SaveChanges();

            ServiceRequestAddress srd = _DbContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            srd.AddressLine1 = book.AddressLine1;
            srd.AddressLine2 = book.AddressLine2;
            srd.City = book.City;
            srd.PostalCode = book.PostalCode;

            _DbContext.ServiceRequestAddresses.Update(srd);
            _DbContext.SaveChanges();

            //var query = (from ServiceRequest in _DbContext.ServiceRequests
            //             join ServiceRequestAddress in _DbContext.ServiceRequestAddresses
            //             on ServiceRequest.ServiceRequestId equals ServiceRequestAddress.ServiceRequestId
            //             join user in _DbContext.Users
            //             on ServiceRequest.UserId equals user.UserId
            //             join sipuser in _DbContext.Users
            //             on ServiceRequest.ServiceProviderId equals sipuser.UserId into xyz
            //             from sipuser in xyz.DefaultIfEmpty()
            //             where ServiceRequest.ServiceRequestId == book.ServiceRequestId
            //             select new User
            //             {
            //                 extraEmail = sipuser == null ? null : sipuser.Email,
            //                 Email = user.Email
            //             }).Single();

            //MailMessage ms = new MailMessage();

            //ms.From = new MailAddress("180320107554.ce.vraj@gmail.com");
            //ms.Subject = "cancel";
            //ms.Body = "service request " + sr.ServiceId + " has been updated by the admin " + "\nThank you for visiting Helperland \n\nRegards,\nHelperland Team";

            //ms.To.Add(new MailAddress(query.Email));
            //ms.To.Add(new MailAddress(query.extraEmail));

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.EnableSsl = true;
            //smtp.Port = 587;

            //NetworkCredential NetworkCred = new NetworkCredential("180320107554.ce.vraj@gmail.com", "vraj@2000");
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = NetworkCred;
            //smtp.Send(ms);

            return "true";
        }

        public IActionResult _refund(int id)
        {
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == id).FirstOrDefault();
            return PartialView(sr);
        }

        public string refundchanges([FromBody] ServiceRequest book)
        {
            ServiceRequest sr = _DbContext.ServiceRequests.Where(x => x.ServiceRequestId == book.ServiceRequestId).FirstOrDefault();
            sr.Comments = book.Comments;
            sr.RefundedAmount = book.RefundedAmount;
            _DbContext.ServiceRequests.Update(sr);
            _DbContext.SaveChanges();
            return "true";
        }
    }
}
