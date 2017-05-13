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
    public class EDObjectController : Controller
    {
        private DBEOEntities db = new DBEOEntities();

        // GET: EDObject
        public ActionResult Index()
        {
            return View(db.ObjectType.ToList());
        }

        // GET: EDObject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectType objectType = db.ObjectType.Find(id);
            if (objectType == null)
            {
                return HttpNotFound();
            }
            return View(objectType);
        }

        // GET: EDObject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EDObject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ObjectType objectType)
        {
            if (ModelState.IsValid)
            {
                db.ObjectType.Add(objectType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objectType);
        }

        // GET: EDObject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectType objectType = db.ObjectType.Find(id);
            if (objectType == null)
            {
                return HttpNotFound();
            }
            return View(objectType);
        }

        // POST: EDObject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ObjectType objectType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objectType);
        }

        // GET: EDObject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectType objectType = db.ObjectType.Find(id);
            if (objectType == null)
            {
                return HttpNotFound();
            }
            return View(objectType);
        }

        // POST: EDObject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectType objectType = db.ObjectType.Find(id);
            db.ObjectType.Remove(objectType);
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
