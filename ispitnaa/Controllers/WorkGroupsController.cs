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
    [Authorize(Roles = "Administrator")]
    public class WorkGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkGroups
        public ActionResult Index()
        {
            return View(db.WorkGroups.ToList());
        }

        // GET: WorkGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // GET: WorkGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkGroupId,Name")] WorkGroup workGroup)
        {
            if (ModelState.IsValid)
            {
                db.WorkGroups.Add(workGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workGroup);
        }

        // GET: WorkGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // POST: WorkGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkGroupId,Name")] WorkGroup workGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workGroup);
        }

        // GET: WorkGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkGroup workGroup = db.WorkGroups.Find(id);
            if (workGroup == null)
            {
                return HttpNotFound();
            }
            return View(workGroup);
        }

        // POST: WorkGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkGroup workGroup = db.WorkGroups.Find(id);
            db.WorkGroups.Remove(workGroup);
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
