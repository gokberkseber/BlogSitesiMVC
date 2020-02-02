using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class KategoriController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(context.Kategori.ToList());
        }
    }
}