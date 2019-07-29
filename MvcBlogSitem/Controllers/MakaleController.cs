using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBlogSitem.App_Classes;
using MvcBlogSitem.Models;
namespace MvcBlogSitem.Controllers
{
    [Authorize]
    public class MakaleController : Controller
    {
        MvcBlogSiteVt context = new MvcBlogSiteVt();
        // GET: Makale
        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult Index()
        {

            return View();
        }
        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult Makalelerim()
        {
            int yzrId = context.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).KullaniciId;
            var makalelerim = context.Makales.Where(x => x.Kullanici.KullaniciId == yzrId).ToList();
            return View(makalelerim);
        }
        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult Duzenle(int id)
        {
            var makale = context.Makales.Find(id);
            ViewBag.KategoriID = new SelectList(context.Kategoris, "KategoriId", "Adi", makale.KategoriID);
            return View(makale);
        }
        [Authorize(Roles = "Admin,Yazar")]
        [HttpPost]
        public ActionResult Duzenle(Makale makale, HttpPostedFileBase resim)
        {
            var makaleedit = context.Makales.Find(makale.MakaleId);
            if (makaleedit != null)
            {
                if (resim != null)
                {
                    Image img = Image.FromStream(resim.InputStream);
                    Bitmap kckResim = new Bitmap(img, Settings.ResimKucukBoyut);
                    Bitmap ortResim = new Bitmap(img, Settings.ResimOrtaBoyut);
                    Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);

                    kckResim.Save(Server.MapPath("/Content/MakaleResim/KucukBoyut/" + resim.FileName));
                    ortResim.Save(Server.MapPath("/Content/MakaleResim/OrtaBoyut/" + resim.FileName));
                    bykResim.Save(Server.MapPath("/Content/MakaleResim/BuyukBoyut/" + resim.FileName));
                    Resim rsm = new Resim();
                    rsm.KucukBoyut = "/Content/MakaleResim/KucukBoyut/" + resim.FileName;
                    rsm.OrtaBoyut = "/Content/MakaleResim/OrtaBoyut/" + resim.FileName;
                    rsm.BuyukBoyut = "/Content/MakaleResim/BuyukBoyut/" + resim.FileName;
                    context.Resims.Add(rsm);
                    context.SaveChanges();
                    makale.ResimID = rsm.ResimId;
                    makale.EklenmeTarihi = DateTime.Now;
                    makale.GoruntulenmeSayisi = 0;
                    makale.BegeniSayisi = 0;
                    int yzrId = context.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).KullaniciId;
                    makaleedit.YazarID = yzrId;
                    context.Makales.Add(makale);
                    context.SaveChanges();
                }
                makaleedit.Baslik = makale.Baslik;
                makaleedit.Icerik = makale.Icerik;
                makaleedit.KategoriID = makale.KategoriID;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(makale);
        }
        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult Detay(int id)
        {
            var makale = context.Makales.FirstOrDefault(i => i.MakaleId == id);
            makale.GoruntulenmeSayisi++;
            context.SaveChanges();
            return View(makale);
        }
        [Authorize(Roles = "Admin,Yazar")]
        [HttpGet]
        public ActionResult Sil(int? id)
        {

            var makale = context.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }

            return View(makale);
        }
        [Authorize(Roles = "Admin,Yazar")]
        [HttpPost]
        public ActionResult Sil(int id)
        {
            var makale = context.Makales.Find(id);
            if (System.IO.File.Exists(Server.MapPath(makale.Resim.OrtaBoyut)))
            {
                System.IO.File.Delete(Server.MapPath(makale.Resim.OrtaBoyut));
            }
            if (System.IO.File.Exists(Server.MapPath(makale.Resim.KucukBoyut)))
            {
                System.IO.File.Delete(Server.MapPath(makale.Resim.KucukBoyut));
            }
            if (System.IO.File.Exists(Server.MapPath(makale.Resim.BuyukBoyut)))
            {
                System.IO.File.Delete(Server.MapPath(makale.Resim.BuyukBoyut));
            }
            context.Makales.Remove(makale);
            context.SaveChanges();
            return RedirectToAction("Makalelerim");
        }


        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult MakaleEkle()
        {
            ViewBag.KategoriID = new SelectList(context.Kategoris, "KategoriId", "Adi");
            return View();
        }
        [Authorize(Roles = "Admin,Yazar")]
        [HttpPost]
        public ActionResult MakaleEkle(Makale makale, HttpPostedFileBase resim)
        {
            if (resim != null)
            {
                Image img = Image.FromStream(resim.InputStream);
                Bitmap kckResim = new Bitmap(img, Settings.ResimKucukBoyut);
                Bitmap ortResim = new Bitmap(img, Settings.ResimOrtaBoyut);
                Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);

                kckResim.Save(Server.MapPath("/Content/MakaleResim/KucukBoyut/" + resim.FileName));
                ortResim.Save(Server.MapPath("/Content/MakaleResim/OrtaBoyut/" + resim.FileName));
                bykResim.Save(Server.MapPath("/Content/MakaleResim/BuyukBoyut/" + resim.FileName));
                Resim rsm = new Resim();
                rsm.KucukBoyut = "/Content/MakaleResim/KucukBoyut/" + resim.FileName;
                rsm.OrtaBoyut = "/Content/MakaleResim/OrtaBoyut/" + resim.FileName;
                rsm.BuyukBoyut = "/Content/MakaleResim/BuyukBoyut/" + resim.FileName;
                context.Resims.Add(rsm);
                context.SaveChanges();
                makale.ResimID = rsm.ResimId;
                makale.EklenmeTarihi = DateTime.Now;
                makale.GoruntulenmeSayisi = 0;
                makale.BegeniSayisi = 0;
                int yzrId = context.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).KullaniciId;
                makale.YazarID = yzrId;
                context.Makales.Add(makale);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.KategoriID = new SelectList(context.Kategoris, "KategoriId", "Adi");
            return View(makale);
        }

        [Authorize(Roles = "Admin,Yazar,Üye")]
        public string Begen(int id)
        {
            var makale = context.Makales.SingleOrDefault(x => x.MakaleId == id);
            makale.BegeniSayisi++;
            context.SaveChanges();
            return makale.BegeniSayisi.ToString();
        }

    }
}