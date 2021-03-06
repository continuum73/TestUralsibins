﻿using System;
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
            try
            {
                using (var db = new FileContext())
                {
                    return View(db.Files.ToArray());
                }
            }
            catch (Exception ex)
            {
                return View(viewName: "Error", model: ex.ToString());
            }
        }
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                try
                {
                    using (var db = new FileContext())
                    {
                        foreach (var upfile in upload)
                        {
                            string fileName = System.IO.Path.GetFileName(upfile.FileName);
                            File file = new File
                            {
                                Name = fileName,
                                Size = upfile.ContentLength,
                                Date = DateTime.Now
                            };
                            db.Files.Add(file);
                            db.SaveChanges();
                            upfile.SaveAs(Server.MapPath("~/Files/" + file.Id + System.IO.Path.GetExtension(upfile.FileName)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    return View(viewName: "Error", model: ex.ToString());
                }
            }
            return RedirectToAction("Index");
        }

    }
}