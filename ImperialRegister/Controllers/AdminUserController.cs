using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImperialRegister.Models;
using ImperialRegister.Security;
using NLog;

namespace ImperialRegister.Controllers
{
    public class AdminUserController : Controller
    {
        private ImperialRegisterEntities db = new ImperialRegisterEntities();
        private Logger _logger = LogManager.GetCurrentClassLogger();


        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in AdminUserController Login View Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
            
        }

        public ActionResult Logout()
        {
            try
            {
                Session["username"] = null;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in AdminUserController Logout Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "name,password")] SystemUser u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (db)
                    {
                        var obj = db.SystemUsers.Where(a => a.name.Equals(u.name) && a.password.Equals(u.name)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["username"] = obj.name.ToString();
                            return RedirectToAction("AdminDashboard");
                        }
                    }
                }
                return View(u);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in AdminUserController Login Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        [AuthorizationFilter]
        public ActionResult AdminDashboard()
        {

            try
            {
                if (Session["username"] != null)
                {
                    return View(db.Users.Where(x => x.status_id == null));
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in AdminUserController AdminDashboard Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }
    }
}