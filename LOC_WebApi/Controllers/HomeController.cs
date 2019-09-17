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
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace LOC_WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
