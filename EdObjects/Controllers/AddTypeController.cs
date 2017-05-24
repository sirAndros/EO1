using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdObjects.Controllers
{
    public class AddTypeController : Controller
    {
        // GET: AddType
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Redact()
        {
            return View();
        }
    }
}
