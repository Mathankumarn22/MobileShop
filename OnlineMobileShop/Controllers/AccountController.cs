using OnlineMobileShop.BL;
using OnlineMobileShop.Entity;
using OnlineMobileShop.Models;
using OnlineMobileShop.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMobileShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 30)]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUp signUp)
        {
            Account account = new Account();
            if (ModelState.IsValid ) 
            {
                account.Name = signUp.Name;
                account.PhoneNumber =signUp.PhoneNumber;
                account.Gender =(signUp.Gender).ToString();
                account.MailID = signUp.MailID;
                account.Password = signUp.Password;
                UserRespo.Add(account);
                return RedirectToAction("LogIn");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn([Bind(Include = "MailID, Password")]Account account)
        {
            if (MobileBL.LogIn(account.MailID,account.Password)==true)
            {
                return RedirectToAction("MobileDetails", "Mobile");
            }
            return View();
        }
        public ActionResult DisplayUserDetails()
        {
            UserRespo userRespo = new UserRespo();
            List<Account> UserDetails = userRespo.GetUser();
            return View(UserDetails);
        }
    }   
}