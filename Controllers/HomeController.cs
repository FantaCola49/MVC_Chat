using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVC_Chat.Models.DBContext;
using MVC_Chat.Models;

namespace MVC_Chat.Controllers
{
    public class HomeController : Controller
    {
        PictureContext db = new PictureContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pics()
        {
            return View(db.Pictures);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Picture pic, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] ImageData = null;
                // считал байты
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    ImageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                //установка массива файлов
                pic.Image = ImageData;

                db.Pictures.Add(pic);
                db.SaveChanges();
                return RedirectToAction("Pics");
            }
            return View(pic);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}