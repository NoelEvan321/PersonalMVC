using PersonalSite.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
//using MimeKit; //Added for access to MimeMessage class
//using MailKit.Net.Smtp; //Added for access to SmtpClient class
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

        #region Adding Credentials to appsettings.json

        //Before creating any Actions or Views related to this Controller,
        //we will add a Credentials section to the appsettings.json file.
        //This lets us store the (sensitive) login information for our 
        //email account in that file so it does not have to be written here.

        //If you are using source control, you can then add the following line
        //to your .gitignore file to prevent the appsettings.json from being
        //pushed to the remote repo:

        // /CORE1/appsettings.json

        #endregion

        //Add a field for the Configuration settings in our appsettings.json. 
        //Our controllers cannot see the appsettings.json by default.

        private readonly IConfiguration _config;

        //Add a constructor for our Controller that accepts the config infor as a parameter
        public StronglyTypedDataController(IConfiguration config) // the values in the config parameter will be assigned to the _config field when the app runs.
        {
            _config = config;
        }
        //Controller Actions are meant to handle certain tyes of requests.
        //The most common request is GET, whcih is used to request info to load a page.
        //We will also create actions to handle POST requests, which are used to send info
        //to the application for processing.

        //GET is the default request type to be handled, so no extra info is needed here.
        public IActionResult Contact()
        {

            return View();

            #region Code Generation Steps

            //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
            //2. Go to the Browse tab and search for Microsoft.VisualStudio.Web
            //3. Click Microsoft.VisualStudio.Web.CodeGeneration.Design
            //4. On the right, check the box next to the CORE1 project, then click "Install"
            //5. Once installed, return here and right click the Contact action
            //6. Select Add View, then select the Razor View template and click "Add"
            //7. Enter the following settings:
            //      - View Name: Contact
            //      - Template: Create
            //      - Model Class: ContactViewModel
            //8. Leave all other settings as-is and click "Add"

            #endregion

        }

        //Now we need to handle what to do when the user submits the form.
        //we will make another Contact Action, this time intended to handle the POST request.
        //The user asks and receives a view from us...now the user wants to give us (POST) some information to us. What do we want them to give us?
    }
}
