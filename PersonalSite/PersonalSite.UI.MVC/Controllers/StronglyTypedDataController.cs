using PersonalSite.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit; //Added for access to MimeMessage class
using MailKit.Net.Smtp; //Added for access to SmtpClient class
using System.Configuration;
using NuGet.Configuration;
using System.Net.Mail;

namespace PersonalSite.UI.MVC.Controllers
{
    public class StronglyTypedDataController : Controller
    {
        //We won't be using an Index Action/View for this Controller,
        //so we can simply comment out/de,ete the one that is provided. 

        //public IActionResult Index()
        //{
        //    return View();
        //}

        

        private readonly IConfiguration _config;

        
        public StronglyTypedDataController(IConfiguration config) // the values in the config parameter will be assigned to the _config field when the app runs.
        {
            _config = config;
        }
        
        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)//we need a special annotation to say "hey, this one is handling the POSTs"
        {
            //When a class has validation attributes, taht validation should be checked
            //BEFORE attempting to process any of the data they provided.

            if (!ModelState.IsValid)
            {
                //Send the user back to the form. We can pass the object to the View
                //so the form will contain the original information they provided. 

                return View(cvm);//this allows the form to repopulate with the info if the user put in invalid info.
            }


            string message = $"You have received a new email from your site's contact form!<br />" +
                $"Sender: {cvm.Name}<br />Email: {cvm.Email}<br />Subject: {cvm.Subject}<br />Message: {cvm.Message}";

           
            var mm = new MimeMessage();

            
            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            
            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            
            mm.Subject = cvm.Subject;

            
            mm.Body = new TextPart("HTML") { Text = message };

            
            mm.Priority = MessagePriority.Urgent;

            

            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

           
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                
                client.Authenticate(

                    
                    _config.GetValue<string>("Credentials:Email:User"),


                    
                    _config.GetValue<string>("Credentials:Email:Password")

                    );
               

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    
                    ViewBag.ErrorMessage = $"There was an error processing your request. " +
                        $"Pleae try again later.<br />Error Message: {ex.StackTrace}";

                    
                    return View(cvm);
                }
            }


            

            return View("EmailConfirmation", cvm);
        }
    }
}
