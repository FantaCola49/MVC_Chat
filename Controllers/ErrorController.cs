using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Chat.Models.DBContext;

namespace MVC_Chat.Controllers
{
    public class ErrorController : Controller
    {
        PictureContext db = new PictureContext();
        // GET: Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View(db.Pictures);
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View(db.Pictures.Find());
        }
    }
}