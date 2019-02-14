using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Only4Agents_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Web Designing, Development, & SEO Company - Only4Agents";
            ViewBag.description = "Only4Agents is a Development & Marketing Company in Brampton, Ontario. We Specialize in offering Web Designing, Development, SEO, & PPC services. Hire Us!";
            ViewBag.keywords = "Only4Agents, Web Designing Company Brampton, SEO Company Brampton";
            return View();
        }
            [HttpPost]
        public ActionResult Index(string username, string Email, string phn, string message)
        {
            bool isSent = SendMail(username, Email, phn, message);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
            public FileResult Download()
            {
                string path = Server.MapPath("../pdf/brochure.pdf");
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                string fileName = "brochure.pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
        public ActionResult About()
        {
            ViewBag.Title = "About Us - Only4Agents Designers & Developers in Brampton";
            ViewBag.description = "Based in Brampton, Only4Agents is 5 years experienced Development & Designing company. To know more, visit our website or contact us here +1 416-844-5725.";
            ViewBag.keywords = "";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Only4Agents for Web Design and Development";
            ViewBag.description = "Contact Only4Agents for world-class IT services that include Web Development, Web Designing, Mobile App Development, PPC & SEO. Call us at +1 416-844-5725.";
            ViewBag.keywords = "";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string username, string Email, string phn, string message)
        {
           SendMail(username, Email, phn, message);
            TempData["Message"] = "Employee Created Successfully";
            return Redirect("/Home/ThankYou");
            //return View("ThankYou");
        }
        public bool SendMail(string Name, string Email, string Phone, string Message)
        {
          
            MailMessage message = new MailMessage();
            message.To.Add(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.Subject = "Contact Mail";
          
            string body = "";
            body = "<p>Person Name : " + Name + "</p>";
            body = body + "<p>Email ID : " + Email + "</p>";
            body = body + "<p>Phone No : " + Phone + "</p>";
            body = body + "<p>Message : " + Message + "</p>";
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;
         
        }
        public ActionResult ThankYou()
        {
            ViewBag.Title = "";
            ViewBag.description = "";
            ViewBag.keywords = "";
            return View();
        }
        public ActionResult InsuranceWebsites()
        {
            ViewBag.Title = "Insurance Websites Designing Company Brampton";
            ViewBag.description = "With a team of passionate designers, we strive to design the best insurance websites to suit your all needs. Contact us online or call us at +1416-844-5725.";
            ViewBag.keywords = "";
            return View();
        }
     
        public ActionResult RealEstateWebsitesDesign()
        {
            ViewBag.Title = "Professional Real Estate Website Design Company Brampton";
            ViewBag.description = "Feel free to contact us for the affordable web design services. Hire Only4Agents Designers with an expertise in delivering end-to-end web design solutions.";
            ViewBag.keywords = "web design Brampton, website design Brampton, real estate website design agency, Brampton web design, Brampton website design, affordable web designing services";
            return View();
        }
        public ActionResult test()
        {
             return View();
        }
        public ActionResult Seoservices()
        {
            ViewBag.Title = "Top Rated SEO Services Brampton - Hire Our SEO Experts";
            ViewBag.description = "Promote your business online with our result-oriented Search engine optimization Services. Only4Agents is an award-winning SEO Company in Brampton, Ontario.";
            ViewBag.keywords = "seo company in Brampton, seo company Brampton, Brampton seo expert, seo services Brampton";
            return View();
        }
        public ActionResult ppcAdvertisingServices()
        {
            ViewBag.Title = "Pay Per Click Management Service Provider Company Toronto";
            ViewBag.description = "Hire Google Certified PPC Experts from award winning Pay Per Click advertising agency in toronto, Only4Agents. To get a quote, call us at +1 416-844-5725.";
            ViewBag.keywords = "pay per click marketing services, PPC services in Toronto, pay per click advertising Toronto, pay per click advertising company, pay per click advertising firm, Toronto PPC agency, Toronto PPC company, PPC management Toronto, PPC management services Toronto, PPC services Toronto";
            return View();
        }
        public ActionResult OtherAppDevelopment()
        {
            ViewBag.Title = "Website Development Service Provider in Brampton Ontario";
            ViewBag.description = "Only4Agents is a web development service provider agency located in Brampton, Ontario. Get the best website development solutions for all your web needs!";
            ViewBag.keywords = "website development Brampton, website development in Brampton, web development Brampton, real estate web development";
            return View();
        }
        public ActionResult MortgageWebsitesDesign()
        {
            ViewBag.Title = "Professional Mortgage Website Design Firm in Brampton ON";
            ViewBag.description = "To design a mortgage website, contact Only4Agents - A professional website design firm in Brampton, ON. Choose your favorite template from the huge list.";
            ViewBag.keywords = "mortgage website design, mortgage broker website designs, mortgage website templates";
            return View();
        }
        public ActionResult MobileAppDevelopment()
        {
            ViewBag.Title = "Mobile App Development Service Provider Brampton Ontario";
            ViewBag.description = "Located in Brampton, Only4Agents is a mobile app development company. Our Developers with vast experience, provide you with great App Development services.";
            ViewBag.keywords = "";
            return View();
        }

        
        public ActionResult Portfolio()
        {
            ViewBag.Title = "Web Development & Website Design Portfolio – Only4Agents";
            ViewBag.description = "View our recent work of Web Development, Web Designing, and Mobile App Development projects. Click here to read about the work we have done for our clients.";
            ViewBag.keywords = "";
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            ViewBag.Title = "Privacy Policy - Only4Agents";
            ViewBag.description = "The page offers information on Only4agents.com privacy policy. Topics covered include third party services, information sharing & disclosure & many more.";
            ViewBag.keywords = "";
            return View();
        }
        public ActionResult Unsubscribe(string EmailId)
        {
            ViewBag.email = EmailId;
            ViewBag.Title = "";
            ViewBag.description = "";
            ViewBag.keywords = "";
            return View();
        }

     
        public ActionResult UnsubscribeUser(string email)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
               SqlCommand cmd = new SqlCommand("Delete from Customer where EmailId='" + email + "'", conn);
                // SqlCommand cmd = new SqlCommand("delete from tblContactUs where Name='';", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                ViewBag.result = "Record Inserted Successfully!";
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.result = "Please try again later!";
                return View();
                //If the message failed at some point, let the user know
                //lblResult.Text = "Your message failed to send, please try again.";
            }
        }
    }
}