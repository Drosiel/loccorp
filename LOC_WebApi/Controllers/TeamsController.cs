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
    public class TeamsController : Controller
    {
        TeamsDBContext db = new TeamsDBContext();

        public ActionResult TeamLadder()
        {
            IEnumerable<Teams> teams = db.Teams.OrderByDescending(x => x.Rating).Take(10);
            ViewBag.Teams = teams;
            return View();
        }

        public ActionResult TeamProfile(Guid? guid)
        {
            if (guid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Teams Teams = db.Teams.FirstOrDefault(x => x.Guid == guid);

            if (Teams == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Teams = Teams;
            return View(Teams);
        }

        public ActionResult Index()
        {
            return HttpNotFound();
        }

        [HttpGet]
        [Authorize]
        public ActionResult TeamCreated()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult TeamCreated([Bind(Include = "Name,ShortName")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teams);
                teams.Rating = 2000;
                db.SaveChanges();
                return RedirectToAction("TeamProfile", new { teams.Guid });
            }

            return View(teams);
        }

        [Authorize]
        public ActionResult TeamDelete(Guid? guid)
        {
            if (guid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Teams teams = db.Teams.FirstOrDefault(x => x.Guid == guid);
            if (teams == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teams = teams;
            return View(teams);
        }

        // POST: Web_API___MVC_5/Delete/5
        [HttpPost, ActionName("TeamDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid? guid)
        {
            Teams teams = db.Teams.FirstOrDefault(x => x.Guid == guid);
            db.Teams.Remove(teams);
            db.SaveChanges();
            return RedirectToAction("TeamLadder");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
