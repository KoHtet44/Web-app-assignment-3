using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyanTour;

namespace MyanTour.Controllers
{
    public class ExpressesController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Expresses
        public ActionResult Index()
        {
            return View(db.Express.ToList());
        }
        public ActionResult Choose(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Create", "Express_Booking", new { vehid = id });

        }
        // GET: Expresses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express express = db.Express.Find(id);
            if (express == null)
            {
                return HttpNotFound();
            }
            return View(express);
        }
        [Authorize(Roles = "Admin")]
        // GET: Expresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarNo,DriverName,Model,Pic,Seat,AvailableSeat,State")] Express express)
        {
            if (ModelState.IsValid)
            {
                db.Express.Add(express);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(express);
        }
        [Authorize(Roles = "Admin")]
        // GET: Expresses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express express = db.Express.Find(id);
            if (express == null)
            {
                return HttpNotFound();
            }
            return View(express);
        }

        // POST: Expresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarNo,DriverName,Model,Pic,Seat,AvailableSeat,State")] Express express)
        {
            if (ModelState.IsValid)
            {
                db.Entry(express).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(express);
        }
        [Authorize(Roles = "Admin")]
        // GET: Expresses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express express = db.Express.Find(id);
            if (express == null)
            {
                return HttpNotFound();
            }
            return View(express);
        }

        // POST: Expresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Express express = db.Express.Find(id);
            db.Express.Remove(express);
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
