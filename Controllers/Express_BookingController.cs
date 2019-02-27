using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyanTour;
using Microsoft.AspNet.Identity;

namespace MyanTour.Controllers
{
    public class Express_BookingController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Express_Booking
        public ActionResult Index()
        {
            var express_Booking = db.Express_Booking.Include(e => e.AspNetUsers).Include(e => e.Express);
            return View(express_Booking.ToList());
        }

        // GET: Express_Booking/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express_Booking express_Booking = db.Express_Booking.Find(id);
            if (express_Booking == null)
            {
                return HttpNotFound();
            }
            return View(express_Booking);
        }

        // GET: Express_Booking/Create
        public ActionResult Create(string vehid)
        {
            ViewBag.CustomerID = User.Identity.GetUserId();
            ViewBag.VehicalID = vehid;
            Express_Booking express_Booking = new Express_Booking();
            express_Booking.VehicalID = vehid;
            //ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email");
            //ViewBag.VehicalID = new SelectList(db.Express, "Id", "CarNo");
            return View(express_Booking);
        }

        // POST: Express_Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Express_Booking express_Booking)
        {
            if (ModelState.IsValid)
            {
                express_Booking.CustomerID = User.Identity.GetUserId();
                db.Express_Booking.Add(express_Booking);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = express_Booking.Id });
            }

            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", express_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Express, "Id", "CarNo", express_Booking.VehicalID);
            return View(express_Booking);
        }

        // GET: Express_Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express_Booking express_Booking = db.Express_Booking.Find(id);
            if (express_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", express_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Express, "Id", "CarNo", express_Booking.VehicalID);
            return View(express_Booking);
        }

        // POST: Express_Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Express_Booking express_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(express_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", express_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Express, "Id", "CarNo", express_Booking.VehicalID);
            return View(express_Booking);
        }

        // GET: Express_Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Express_Booking express_Booking = db.Express_Booking.Find(id);
            if (express_Booking == null)
            {
                return HttpNotFound();
            }
            return View(express_Booking);
        }

        // POST: Express_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Express_Booking express_Booking = db.Express_Booking.Find(id);
            db.Express_Booking.Remove(express_Booking);
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
