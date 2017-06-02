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
    public class RolesController : Controller
    {
        private ImperialRegisterEntities db = new ImperialRegisterEntities();
        private Logger _logger = LogManager.GetCurrentClassLogger();

        // GET: Roles
        [AuthorizationFilter]
        public ActionResult Index()
        {

            try
            {
                return View(db.Roles.ToList());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Index Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }

        // GET: Roles/Details/5
        [AuthorizationFilter]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Details Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }


        }

        // GET: Roles/Create
        [AuthorizationFilter]
        public ActionResult Create()
        {

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Create View Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
            
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Create([Bind(Include = "name,description")] Role role)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Create Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }


        }

        // GET: Roles/Edit/5
        [AuthorizationFilter]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Edit Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }


        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult Edit([Bind(Include = "Id,name,description,create_date,update_date")] Role role)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    role.update_date = new DateTime();
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Edit Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            } 

        }

        // GET: Roles/Delete/5
        [AuthorizationFilter]
        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController Delete Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }


        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizationFilter]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                Role role = db.Roles.Find(id);
                db.Roles.Remove(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in RolesController DeleteConfirmed Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
