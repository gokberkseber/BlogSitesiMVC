using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class EtiketController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult EtiketlerWidget()
        {
            return PartialView(context.Etiket.ToList());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = context.Makale.Where(x => x.Etiket.Any(y => y.EtiketID == id)).ToList();
            return View("MakaleListeleWidget", data);
        }

    }
}