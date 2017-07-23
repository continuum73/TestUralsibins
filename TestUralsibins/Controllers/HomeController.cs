using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUralsibins.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var upfile in upload)
                {
                    string fileName = System.IO.Path.GetFileName(upfile.FileName);
                    upfile.SaveAs(Server.MapPath("~/Files/" + fileName));
                }
            }
            return RedirectToAction("Index");
        }

    }
}