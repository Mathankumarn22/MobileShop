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
            MobileRespository mobiles = new MobileRespository();
            ViewBag.Mobile = new SelectList(mobiles.Brand(), "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Mobile mobile)
        {
            MobileRespository mobiles = new MobileRespository();
            ViewBag.Mobile = new SelectList(mobiles.Brand(), "BrandId", "BrandName");
            mobiles.Add(mobile);
            return RedirectToAction("");

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
        [HttpGet]
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(Models.Brand brand)
        {
            if(ModelState.IsValid)
            {
                Entity.Brand brandDetails = new Entity.Brand()
                {
                    BrandName = brand.BrandName,
                };
                mobileBL.AddBrand(brandDetails);
                return RedirectToAction("");
            }
    
            return View();
        }
    }
}
