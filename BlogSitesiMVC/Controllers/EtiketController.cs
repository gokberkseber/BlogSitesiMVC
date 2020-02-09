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
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult EtiketlerWidget()
        {
            return PartialView(context.Etiket.ToList());
        }
    }
}