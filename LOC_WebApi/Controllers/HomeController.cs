using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LOC_WebApi.Models;
using Microsoft.AspNet.SignalR;

namespace LOC_WebApi.Controllers
{
    public class HomeController : Controller
    {
        TeamsDBContext db = new TeamsDBContext();

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Index()
        {
            IEnumerable<Teams> teams = db.Teams.OrderByDescending(x => x.Rating).Take(3);
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel model)
        {
            if (ModelState.IsValid) //валидность модели
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        public ActionResult Tournament()
        {
            IEnumerable<Teams> teams = db.Teams;
            ViewBag.Teams = teams;
            return View(teams);
        }
        public ActionResult Rating()
        {
            return View();
        }


        [System.Web.Mvc.Authorize]
        public ActionResult Chat()
        {
            
            return View();
        }
        public ActionResult B()
        {
            return View();
        }
    }
}
