using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    [Authorize]
    public class MakaleController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Makale
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = context.Makale.FirstOrDefault(x => x.MakaleID == id);
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MakaleEkle()
        {
            return View();
        }

        [AllowAnonymous]
        public string Begen(int id)
        {
            Makale mkl = context.Makale.FirstOrDefault(x => x.MakaleID == id);
            mkl.Begeni++;
            context.SaveChanges();
            return mkl.Begeni.ToString();
        }
    }
}