using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class MakaleController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Makale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detay(int id)
        {
            var data = context.Makale.FirstOrDefault(x => x.MakaleID == id);
            return View(data);
        }
    }
}