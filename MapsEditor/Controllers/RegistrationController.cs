using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MapsEditor.Domain.Models;
using MapsEditor.Domain.Entitties;
using MapsEditor.Domain.Concrete;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace MapsEditor.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                Login user = null;
                using (MapContext db = new MapContext())
                {
                    user = db.Logins.FirstOrDefault(u => u.Name == model.Email);
                }
                if (user == null)
                {

                    using (MapContext db = new MapContext())
                    {
                        db.Logins.Add(new Login { Name = model.Email, Password = model.Password });
                        db.SaveChanges();

                        user = db.Logins.Where(u => u.Name == model.Email && u.Password == model.Password).FirstOrDefault();
                    }

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("MyList", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "sorrySuch user already exists");
                }
            }

            return View(model);

        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("MyList", "Home");
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                Login user = null;
                using (MapContext db = new MapContext())
                {
                     user= db.Logins.FirstOrDefault(u => u.Name == model.Name && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("MyList", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with such login and password is not present");
                }
            }

            return View(model);
        }


    }
}