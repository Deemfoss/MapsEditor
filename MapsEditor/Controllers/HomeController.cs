using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MapsEditor.Domain.Entitties;
using MapsEditor.Domain.Concrete;
using Newtonsoft.Json;
using System.Collections.Specialized;
using MapsEditor.Domain.Models;
using MapsEditor.Domain.IRepository;

namespace MapsEditor.Controllers
{
    public class HomeController : Controller
    {
        IMapRepository maprep;
        
        public HomeController()
        {
            maprep = new IMapRepository();
            
        }

        [Authorize]
        public ActionResult Create()
        {
         
           
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(MapModel model)
        {
            if (ModelState.IsValid)
            {
                var UserName = User.Identity.Name.ToString();
                Map map = new Map {Id=model.Id,Name=model.Name,UserName=UserName,Description=model.Description };
                maprep.Maps.Create(map);
                maprep.Maps.Save();
                ViewBag.j = map.Description;
            }
           
            

            return RedirectToAction("MyList","Home");
        }

        [Authorize]
        public ActionResult MyList()
        {

            var UserName = User.Identity.Name.ToString();
            var c = maprep.Maps.Find(UserName);
           
            ViewBag.User = UserName;
            return View(c);
        }
        [Authorize]
     
        public ActionResult DetailMap(int id)
        {

            var map=maprep.Maps.Get(id);
            ViewBag.GeoJson= map.Description;
            ViewBag.Id = id;
            return View();
        }

       [Authorize]
        public ActionResult Edit(int id)
        {

            var res = maprep.Maps.Get(id);
            return View(res);
        }
        [Authorize]

        [HttpPost]
        public ActionResult Edit(Map map)
        {
            

            
            if (ModelState.IsValid)
            {
                maprep.Maps.Update(map);
               maprep.Maps.Save();
            }
            
          return  RedirectToAction("MyList","Home");
        }
        [Authorize]
      
        public ActionResult Delete(int id)
        {

            

            if (ModelState.IsValid)
            {

                maprep.Maps.Delete(id);
                maprep.Maps.Save();
            }

            return RedirectToAction("MyList", "Home");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Searching(string Name)
        {


            var c = maprep.Maps.Search(Name);

       
            return View(c);
        }
    }
}