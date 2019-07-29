using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlogSitem.Models;
using System.Web.Security;
namespace MvcBlogSitem.Controllers
{
    public class KullaniciController : Controller
    {
        MvcBlogSiteVt context = new MvcBlogSiteVt();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullanici kl)
        {
            string ka = ValidateUser(kl.KullaniciAdi, kl.Parola);
            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    kl.KullaniciAdi,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    true, ka, FormsAuthentication.FormsCookiePath);

                HttpCookie ck = new HttpCookie
                    (FormsAuthentication.FormsCookieName);
                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(kl.KullaniciAdi, true);
             
            }
            return RedirectToAction("GirisYap");
        }

        public ActionResult CikisYap(string redirectUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(redirectUrl);
        }
        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(Kullanici kul)
        {
            kul.Yazar = false;
            kul.Onaylandi = true;
            kul.Aktif = true;
            kul.KayitTarihi = DateTime.Now;
            context.Kullanicis.Add(kul);
            context.SaveChanges();
            return RedirectToAction("GirisYap");
            
        }
        string ValidateUser(string kadi, string sifre)
        {
            var kullanc = context.Kullanicis.FirstOrDefault(x=> x.KullaniciAdi == kadi && x.Parola == sifre);
            if (kullanc != null)
            {
                return kullanc.KullaniciAdi;
            }
            else
            {
                return "";
            }
        }
    }
}