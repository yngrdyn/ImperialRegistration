using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;


namespace ImperialRegister.Controllers
{
    public class ErrorPageController : Controller
    {

        private Logger _logger = LogManager.GetCurrentClassLogger();

        // GET: ErrorPage
        public ActionResult ErrorMessage()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in  ErrorPageController  ErrorMessage  Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }
    }
}