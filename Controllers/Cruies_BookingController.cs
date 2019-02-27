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
    public class Cruies_BookingController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Cruies_Booking
        public ActionResult Index()
        {
            var cruies_Booking = db.Cruies_Booking.Include(c => c.AspNetUsers).Include(c => c.Cruies);
            return View(cruies_Booking.ToList());
        }

        // GET: Cruies_Booking/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.CustomerID = User.Identity.GetUserId();
            ViewBag.CustomerName = User.Identity.GetUserName();
            ViewBag.BookingID = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies_Booking cruies_Booking = db.Cruies_Booking.Find(id);
            if (cruies_Booking == null)
            {
                return HttpNotFound();
            }
            return View(cruies_Booking);
        }
        [Authorize]
        // GET: Cruies_Booking/Create
        public ActionResult Create(string vehid)
        {
            //ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email");
            //ViewBag.VehicalID = new SelectList(db.Cruies, "Id", "ShipNumber");
            ViewBag.CustomerID = User.Identity.GetUserId();
            ViewBag.VehicalID = vehid;
            Cruies_Booking cruies_Booking = new Cruies_Booking();
            cruies_Booking.VehicalID = vehid;
            return View();
        }

        // POST: Cruies_Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Cruies_Booking cruies_Booking)
        {
            if (ModelState.IsValid)
            {
                cruies_Booking.CustomerID = User.Identity.GetUserId();
                db.Cruies_Booking.Add(cruies_Booking);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = cruies_Booking.Id });
            }

            //ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", cruies_Booking.CustomerID);
            //ViewBag.VehicalID = new SelectList(db.Cruies, "Id", "ShipNumber", cruies_Booking.VehicalID);
            return View(cruies_Booking);
        }

        // GET: Cruies_Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies_Booking cruies_Booking = db.Cruies_Booking.Find(id);
            if (cruies_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", cruies_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Cruies, "Id", "ShipNumber", cruies_Booking.VehicalID);
            return View(cruies_Booking);
        }

        // POST: Cruies_Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Cruies_Booking cruies_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruies_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", cruies_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Cruies, "Id", "ShipNumber", cruies_Booking.VehicalID);
            return View(cruies_Booking);
        }

        // GET: Cruies_Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies_Booking cruies_Booking = db.Cruies_Booking.Find(id);
            if (cruies_Booking == null)
            {
                return HttpNotFound();
            }
            return View(cruies_Booking);
        }

        // POST: Cruies_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cruies_Booking cruies_Booking = db.Cruies_Booking.Find(id);
            db.Cruies_Booking.Remove(cruies_Booking);
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
