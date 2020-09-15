using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admTarea1._1.Models;

namespace admTarea1._1.Controllers
{
    public class nunezsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: nunezs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.nunezs.ToList());
        }

        // GET: nunezs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nunez nunez = db.nunezs.Find(id);
            if (nunez == null)
            {
                return HttpNotFound();
            }
            return View(nunez);
        }

        // GET: nunezs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: nunezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nunezID,Friendofnunez,Place,Email,Birthdate")] nunez nunez)
        {
            if (ModelState.IsValid)
            {
                db.nunezs.Add(nunez);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nunez);
        }

        // GET: nunezs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nunez nunez = db.nunezs.Find(id);
            if (nunez == null)
            {
                return HttpNotFound();
            }
            return View(nunez);
        }

        // POST: nunezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nunezID,Friendofnunez,Place,Email,Birthdate")] nunez nunez)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nunez).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nunez);
        }

        // GET: nunezs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nunez nunez = db.nunezs.Find(id);
            if (nunez == null)
            {
                return HttpNotFound();
            }
            return View(nunez);
        }

        // POST: nunezs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nunez nunez = db.nunezs.Find(id);
            db.nunezs.Remove(nunez);
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
