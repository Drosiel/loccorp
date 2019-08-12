using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LOC_WebApi.Models;

namespace LOC_WebApi.Controllers
{
    public class UsersController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        public ActionResult UserLadder()
        {
            IEnumerable<ApplicationUser> users = db.Users.OrderByDescending(x => x.UserRating).Take(10).Where(c => c.UserName != "RootLOC");
            ViewBag.Users = users;
            return View();
        }

        public ActionResult UserProfile(string userName)
        {
            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser Users = db.Users.FirstOrDefault(x => x.UserName == userName);

            if (Users == null)
            {
                return HttpNotFound();
            }

            ViewBag.Users = Users;
            return View(Users);
        }
    }
}