using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhaleShockBlogEngine.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: /Admin/Posting/?id
        public ActionResult Posting(int? id)
        {
            return View();
        }
    }
}
