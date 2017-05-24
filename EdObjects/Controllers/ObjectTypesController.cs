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
    public class ObjectTypesController : Controller
    {
        private DBEOEntities db = new DBEOEntities();

        // GET: ObjectTypes
        public ActionResult Index()
        {
            var objectType = db.ObjectType.Include(o => o.ObjectType2);
            return View(objectType.ToList());
        }

        // GET: ObjectTypes/Details/5
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

        // GET: ObjectTypes/Create
        public ActionResult Create()
        {
            ViewBag.BaseType = new SelectList(db.ObjectType, "Id", "Name");
            return View();
        }

        // POST: ObjectTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BaseType")] ObjectType objectType)
        {
            if (ModelState.IsValid)
            {
                db.ObjectType.Add(objectType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaseType = new SelectList(db.ObjectType, "Id", "Name", objectType.BaseType);
            return View(objectType);
        }

        // GET: ObjectTypes/Edit/5
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
            ViewBag.BaseType = new SelectList(db.ObjectType, "Id", "Name", objectType.BaseType);
            return View(objectType);
        }

        // POST: ObjectTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BaseType")] ObjectType objectType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaseType = new SelectList(db.ObjectType, "Id", "Name", objectType.BaseType);
            return View(objectType);
        }

        // GET: ObjectTypes/Delete/5
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

        // POST: ObjectTypes/Delete/5
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
