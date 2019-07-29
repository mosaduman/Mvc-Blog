using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlogSitem.Models;

namespace MvcBlogSitem.Controllers
{
    public class KategoriController : Controller
    {
         MvcBlogSiteVt context = new MvcBlogSiteVt();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult KategoriListeleWidget()
        {
            return PartialView(context.Kategoris.ToList());
        }
        public ActionResult KategoriMakaleListele(int id)
        {
            var makaleler = context.Makales.Where(i => i.KategoriID == id).ToList();
            return View("MakaleListeleWidget", makaleler);
        }

        public ActionResult KategoriIndex()
        {
            var kategori = context.Kategoris.ToList();
            return View(kategori);
        }
        [HttpPost]
        public string Sil(int? id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return "";
            
        }
    }
}