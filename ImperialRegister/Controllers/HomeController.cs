using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImperialRegister.Models;
using NLog;

namespace ImperialRegister.Controllers
{
    public class HomeController : Controller
    {
        private ImperialRegisterEntities db = new ImperialRegisterEntities();
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {

            try
            {
                ViewBag.backToRole = -1;
                ViewBag.role_id = new SelectList(db.Roles, "Id", "name");
                ViewBag.species_id = new SelectList(db.Species, "Id", "name");
                return View();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in HomeController Index Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }
    }
}