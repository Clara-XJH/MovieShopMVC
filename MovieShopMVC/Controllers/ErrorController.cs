using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopMVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccessDeniedError(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("ErrorPage");
        }
        // GET: Error
        public ActionResult GeneralError(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("ErrorPage");
        }
        public ActionResult NotFoundError(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("ErrorPage");
        }
        public ActionResult InternalError(string message)
        {
            ViewBag.ErrorMessage = message;
            return View("ErrorPage");
        }
    }
}