using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ispitnaa.Models;

namespace ispitnaa.Controllers
{
    public class AbsencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator,Director,Employee")]
        // GET: Absences
        public ActionResult Index()
        {
            var absences = db.Absences.Include(a => a.Employee);
            return View(absences.ToList());
        }


        [Authorize(Roles = "Director")]
        [HttpPost]
        public ActionResult Potvrdi(int id)
        {
            var absence = db.Absences.Find(id);
            absence.isApproved = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Absences");
        }

        [Authorize(Roles = "Administrator,Director,Employee")]
        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Include(a => a.Employee).Where(a => a.AbsenceId == id).First();
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        [Authorize(Roles = "Administrator,Director")]
        // GET: Absences/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            return View();
        }


        [Authorize(Roles = "Administrator,Director")]
        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AbsenceId,Name,EmployeeId")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Absences.Add(absence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", absence.EmployeeId);
            return View(absence);
        }


        [Authorize(Roles = "Administrator,Director")]
        // GET: Absences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", absence.EmployeeId);
            return View(absence);
        }


        [Authorize(Roles = "Administrator,Director")]
        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AbsenceId,Name,EmployeeId")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(absence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", absence.EmployeeId);
            return View(absence);
        }


        [Authorize(Roles = "Administrator,Director")]
        // GET: Absences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }


        [Authorize(Roles = "Administrator,Director")]
        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Absence absence = db.Absences.Find(id);
            db.Absences.Remove(absence);
            db.SaveChanges();
            return RedirectToAction("Index");
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
