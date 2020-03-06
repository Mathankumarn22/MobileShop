using System.Collections.Generic;
using OnlineMobileShop.Entity;
using OnlineMobileShop.Respository;
using System.Web.Mvc;
using System.Data;
using OnlineMobileShop.BL;
using OnlineMobileShop.Models;

namespace OnlineMobileShop.Controllers
{  
    public class MobileController : Controller
    {
        // GET: Mobile
        MobileRespository repository = new MobileRespository();
        MobileBL mobileBL = new MobileBL();
        Mobile mobiles = new Mobile();
        public ActionResult RunMaster()
        {
            return View();
        }
        public ActionResult MobileDetails()
        {
            IEnumerable<Mobile> mobile = mobileBL.MobileDetails();            
            TempData["mobile"] = mobile;
            return View(mobile);
        }
      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Mobile mobile)
        {
           
            if (ModelState.IsValid)
            {
                mobile.Brand = mobile.Brand;
                mobile.Model = mobile.Model;
                mobile.Battery = mobile.Battery;
                mobile.RAM = mobile.RAM;
                mobile.ROM = mobile.ROM;
                mobile.Price = mobile.Price;
                if(mobileBL.Add(mobile)>0)
                {
                    ViewBag.message = "Successfull";
                    return RedirectToAction("MobileDetails");
                }
                ViewBag.message = "falied";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AddMobiles addMobiles = new AddMobiles();
            mobiles=mobileBL.Edit(id);
            return View(addMobiles);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            mobileBL.Delete(id);
            return RedirectToAction("MobileDetails");
        }
        [HttpPost]
        public ActionResult Update(AddMobiles addMobiles)
        {
            if (ModelState.IsValid)
            {
                Mobile mobile = new Mobile();
                mobile.Brand = mobile.Brand;
                mobile.Model = mobile.Model;
                mobile.Battery = mobile.Battery;
                mobile.RAM = mobile.RAM;
                mobile.ROM = mobile.ROM;
                mobile.Price = mobile.Price;
    
                mobileBL.update(mobile);
            }
            return View();

        

        }

    }
}
