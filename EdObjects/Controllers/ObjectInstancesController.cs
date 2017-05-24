using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EdObjects.Models;

namespace EdObjects.Controllers
{
    public class ObjectInstancesController : Controller
    {
        private DBEOEntities db = new DBEOEntities();

        // GET: ObjectInstances
        public ActionResult Index()
        {
            var objectInstance = db.ObjectInstance.Include(o => o.ObjectType).Include(o => o.ObjectInstance2);
            return View(objectInstance.ToList());
        }

        // GET: ObjectInstances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectInstance objectInstance = db.ObjectInstance.Find(id);
            if (objectInstance == null)
            {
                return HttpNotFound();
            }
            return View(objectInstance);
        }

        // GET: ObjectInstances/Create
        public ActionResult Create()
        {
            ViewBag.IdTypeObject = new SelectList(db.ObjectType, "Id", "Name");
            ViewBag.BaseId = new SelectList(db.ObjectInstance, "Id", "DisplayName");
            return View();
        }

        // POST: ObjectInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTypeObject,BaseId,DisplayName,CreateDate,ChangeDate")] ObjectInstance objectInstance)
        {
            if (ModelState.IsValid)
            {
                db.ObjectInstance.Add(objectInstance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTypeObject = new SelectList(db.ObjectType, "Id", "Name", objectInstance.IdTypeObject);
            ViewBag.BaseId = new SelectList(db.ObjectInstance, "Id", "DisplayName", objectInstance.BaseId);
            return View(objectInstance);
        }

        // GET: ObjectInstances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectInstance objectInstance = db.ObjectInstance.Find(id);
            if (objectInstance == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTypeObject = new SelectList(db.ObjectType, "Id", "Name", objectInstance.IdTypeObject);
            ViewBag.BaseId = new SelectList(db.ObjectInstance, "Id", "DisplayName", objectInstance.BaseId);
            return View(objectInstance);
        }

        // POST: ObjectInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTypeObject,BaseId,DisplayName,CreateDate,ChangeDate")] ObjectInstance objectInstance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectInstance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTypeObject = new SelectList(db.ObjectType, "Id", "Name", objectInstance.IdTypeObject);
            ViewBag.BaseId = new SelectList(db.ObjectInstance, "Id", "DisplayName", objectInstance.BaseId);
            return View(objectInstance);
        }

        // GET: ObjectInstances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectInstance objectInstance = db.ObjectInstance.Find(id);
            if (objectInstance == null)
            {
                return HttpNotFound();
            }
            return View(objectInstance);
        }

        // POST: ObjectInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectInstance objectInstance = db.ObjectInstance.Find(id);
            db.ObjectInstance.Remove(objectInstance);
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
