using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class AdminController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOnaylari()
        {
            var data = context.Kullanici.Where(x => x.Yazar == true && x.Onaylandi == false).ToList();
            return View(data);
        }
        public ActionResult OnayVer(int id)
        {
            Kullanici kl = context.Kullanici.FirstOrDefault(x => x.KullaniciID == id);
            kl.Onaylandi = true;
            context.SaveChanges();
            return RedirectToAction("YazarOnaylari");
        }
    }
}