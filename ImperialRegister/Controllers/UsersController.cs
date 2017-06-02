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
    public class UsersController : Controller
    {
        private ImperialRegisterEntities db = new ImperialRegisterEntities();
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public RedirectToRouteResult Create()
        {
            throw new NotImplementedException();
        }

        // GET: Users
        [AuthorizationFilter]
        public ActionResult Index()
        {
            try
            {
                var users = db.Users.Include(u => u.Role).Include(u => u.Species).Include(u => u.Status);
                return View(users.ToList());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Index Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        // GET: Users/Details/5
        [AuthorizationFilter]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Details Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        // GET: Users/Create
        public ActionResult CreateForm(int? id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.role_id = new SelectList(db.Roles, "Id", "name");
                    ViewBag.backToRole = -1;
                }
                else
                {
                    ViewBag.role_id = new SelectList(db.Roles.Where(r => r.Id == id), "Id", "name");
                    ViewBag.backToRole = id;
                }
                ViewBag.species_id = new SelectList(db.Species, "Id", "name");
                ViewBag.status_id = new SelectList(db.Status, "Id", "name");
                return View("Create");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Create Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }


        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,username,role_id,species_id,status_id,create_date,update_date")] User user, int backToRole, int? backToHome)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    if (backToRole > 0)
                    {
                        return RedirectToAction("Details", "Roles", new { id = backToRole });
                    }
                    else if (backToHome != null)
                    {
                        TempData["Message"] = "You were successfully registered!";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.role_id = new SelectList(db.Roles, "Id", "name", user.role_id);
                ViewBag.species_id = new SelectList(db.Species, "Id", "name", user.species_id);
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Create Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        // GET: Users/Edit/5
        [AuthorizationFilter]
        public ActionResult Edit(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.role_id = new SelectList(db.Roles, "Id", "name", user.role_id);
                ViewBag.species_id = new SelectList(db.Species, "Id", "name", user.species_id);
                ViewBag.status_id = new SelectList(db.Status, "Id", "name", user.status_id);
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Edit Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }
        }

        // POST: Users/Edit/5
        [AuthorizationFilter]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,username,role_id,species_id,status_id,create_date,update_date")] User user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    callRegisterRebelWS(user.username, "Tatooine");

                    return RedirectToAction("Index");
                }
                ViewBag.role_id = new SelectList(db.Roles, "Id", "name", user.role_id);
                ViewBag.species_id = new SelectList(db.Species, "Id", "name", user.species_id);
                ViewBag.status_id = new SelectList(db.Status, "Id", "name", user.status_id);
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Edit Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }

        // GET: Users/Delete/5
        [AuthorizationFilter]
        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController Delete Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }

        // POST: Users/Delete/5
        [AuthorizationFilter]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error occured in UsersController DeleteConfirmed Action");
                return RedirectToAction("ErrorMessage", "ErrorPage");
            }

        }

        public ActionResult RegisterRebelWS(string username, string planet)
        {
            callRegisterRebelWS(username, planet);
            return RedirectToAction("Index", "Home");

        }

        private ServiceReference1.RegisterRebelResponse callRegisterRebelWS(string username, string planet)
        {
            ServiceReference1.ServiceClient obj = new ServiceReference1.ServiceClient();
            ImperialRegistration_API.DataContractTypes.RebelRegisterRequest request = new ImperialRegistration_API.DataContractTypes.RebelRegisterRequest();
            request.username = username;
            request.planet = planet;
            ServiceReference1.RegisterRebelResponse response = obj.registerRebel(request);
            return response;
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
