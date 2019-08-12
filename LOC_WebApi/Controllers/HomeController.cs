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
using Microsoft.AspNet.SignalR;

namespace LOC_WebApi.Controllers
{
    public class HomeController : Controller
    {
        TeamsDBContext db = new TeamsDBContext();

        public ActionResult Index()
        {
            IEnumerable<Teams> teams = db.Teams.OrderByDescending(x => x.Rating).Take(3);
            ViewBag.Teams = teams;
            return View();
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
