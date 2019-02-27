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
    public class Flight_BookingController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Flight_Booking
        public ActionResult Index()
        {
            var flight_Booking = db.Flight_Booking.Include(f => f.AspNetUsers).Include(f => f.Flight);
            return View(flight_Booking.ToList());
        }

        // GET: Flight_Booking/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight_Booking flight_Booking = db.Flight_Booking.Find(id);
            if (flight_Booking == null)
            {
                return HttpNotFound();
            }
            return View(flight_Booking);
        }

        // GET: Flight_Booking/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.VehicalID = new SelectList(db.Flight, "Id", "flightCode");
            return View();
        }

        // POST: Flight_Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Flight_Booking flight_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Flight_Booking.Add(flight_Booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", flight_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Flight, "Id", "flightCode", flight_Booking.VehicalID);
            return View(flight_Booking);
        }

        // GET: Flight_Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight_Booking flight_Booking = db.Flight_Booking.Find(id);
            if (flight_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", flight_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Flight, "Id", "flightCode", flight_Booking.VehicalID);
            return View(flight_Booking);
        }

        // POST: Flight_Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Flight_Booking flight_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", flight_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Flight, "Id", "flightCode", flight_Booking.VehicalID);
            return View(flight_Booking);
        }

        // GET: Flight_Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight_Booking flight_Booking = db.Flight_Booking.Find(id);
            if (flight_Booking == null)
            {
                return HttpNotFound();
            }
            return View(flight_Booking);
        }

        // POST: Flight_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight_Booking flight_Booking = db.Flight_Booking.Find(id);
            db.Flight_Booking.Remove(flight_Booking);
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
