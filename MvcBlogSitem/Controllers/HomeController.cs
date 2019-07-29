using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlogSitem.Models;
namespace MvcBlogSitem.Controllers
{
    public class HomeController : Controller
    {
        MvcBlogSiteVt context = new MvcBlogSiteVt();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

      public ActionResult MakaleListele()
        {
            var makaleler = context.Makales.ToList();
            return View("MakaleListeleWidget", makaleler);
        }

        public PartialViewResult PopulerMakaleler()
        {
            var makale = context.Makales.OrderByDescending
                (x => x.EklenmeTarihi).Take(3).ToList();
            return PartialView(makale);
        }

        public PartialViewResult SiteHakkinda()
        {
            return PartialView();
        }
    }
}