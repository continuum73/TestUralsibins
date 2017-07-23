using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUralsibins.Models;

namespace TestUralsibins.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            using (var db = new FileContext())
            {
                return View(db.Files.ToArray());
            }
        }
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                using (var db = new FileContext())
                {
                    foreach (var upfile in upload)
                    {
                        string fileName = System.IO.Path.GetFileName(upfile.FileName);
                        db.Files.Add(new File() { Name = fileName, Size = upfile.ContentLength, Date = DateTime.Now });
                        upfile.SaveAs(Server.MapPath("~/Files/" + fileName));
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}