﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class YazarController : Controller
    {
        // GET: Yazar
        BlogDBContext context = new BlogDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarOl(Kullanici kl,string rdBay,string rdBayan)
        {
            if (!string.IsNullOrEmpty(rdBay))
                kl.Cinsiyet = true;
            if (!string.IsNullOrEmpty(rdBayan))
                kl.Cinsiyet = false;
            kl.Yazar = true;
            kl.Onaylandi = false;
            kl.Aktif = true;
            kl.KayitTarihi = DateTime.Now;
            context.Kullanici.Add(kl);
            context.SaveChanges();

            Rol yazar = context.Rol.FirstOrDefault(x => x.RolAdi == "Yazar");

            KullaniciRol kr = new KullaniciRol();
            kr.RolID = yazar.RolID;
            kr.KullaniciID = kl.KullaniciID;
            context.KullaniciRol.Add(kr);
            context.SaveChanges();
            return RedirectToAction("Index","Home");

        }
    }
}