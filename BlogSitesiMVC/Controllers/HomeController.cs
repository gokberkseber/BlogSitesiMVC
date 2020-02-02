using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesiMVC.Controllers
{
    using Models;
    public class HomeController : Controller
    {
        BlogDBContext context = new BlogDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MakaleListeleWidget()
        {
            return PartialView(context.Makale.ToList());
        }
    }
}