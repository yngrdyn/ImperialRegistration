using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImperialRegister.Models;
using ImperialRegister.Security;
using NLog;

namespace ImperialRegister.Controllers
{
    public class SpeciesController : Controller
    {
        private ImperialRegisterEntities db = new ImperialRegisterEntities();
        private Logger _logger = LogManager.GetCurrentClassLogger();

        // GET: Species
        [AuthorizationFilter]
        public ActionResult Index()
        {
            try
            {
                return View(db.Species.ToList());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in SpeciesController Index Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            } 
        }
    }
}
