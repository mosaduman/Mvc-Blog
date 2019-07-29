using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlogSitem.Models;
namespace MvcBlogSitem.Controllers
{
    public class EtiketController : Controller
    {
        MvcBlogSiteVt context = new MvcBlogSiteVt();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult EtiketListeleWidget()
        {
            return PartialView(context.Etikets.ToList());
        }
        public ActionResult EtiketMakaleListele(int id)
        {
            var makaleler = context.Makales.Where(i => i.Etikets.Any
            (j => j.EtiketId == id)).ToList();
            return View("MakaleListeleWidget", makaleler);
        }
    }
}