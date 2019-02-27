using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyanTour;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace MyanTour.Controllers
{
    public class Car_BookingController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Car_Booking
        public ActionResult Index()
        {
            var car_Booking = db.Car_Booking.Include(c => c.AspNetUsers).Include(c => c.Car);
            return View(car_Booking.ToList());
        }

        // GET: Car_Booking/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.CustomerID = User.Identity.GetUserId();
            ViewBag.CustomerName = User.Identity.GetUserName();
            ViewBag.BookingID = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Booking car_Booking = db.Car_Booking.Find(id);
            if (car_Booking == null)
            {
                return HttpNotFound();
            }
            return View(car_Booking);
        }
        
        [Authorize]
        // GET: Car_Booking/Create
        public ActionResult Create(string vehid)
        {

            // ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email");
            // ViewBag.VehicalID = new SelectListItem(db.Car, "Id", "Id");
            ViewBag.CustomerID = User.Identity.GetUserId();
            ViewBag.VehicalID = vehid;
            Car_Booking car_Booking = new Car_Booking();
            car_Booking.VehicalID = vehid;
            return View(car_Booking);
        }
        
        // POST: Car_Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Car_Booking car_Booking)
        {
            if (ModelState.IsValid) 
            {
                car_Booking.CustomerID = User.Identity.GetUserId();
                db.Car_Booking.Add(car_Booking);
                db.SaveChanges();
                return RedirectToAction("Details",new {id = car_Booking.Id});
            }
            //ViewBag.CustomerID= User.Identity.GetUserId();
            //ViewBag.VehicalID = 
            //ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", car_Booking.CustomerID);
            //ViewBag.VehicalID = new SelectList(db.Car, "Id", "CarNo", car_Booking.VehicalID);
            return View(car_Booking);
        }

        // GET: Car_Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Booking car_Booking = db.Car_Booking.Find(id);
            if (car_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", car_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Car, "Id", "CarNo", car_Booking.VehicalID);
            return View(car_Booking);
        }

        // POST: Car_Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,VehicalID,StartDate,EndDate,FerryPoint,Loc,Charges,State")] Car_Booking car_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AspNetUsers, "Id", "Email", car_Booking.CustomerID);
            ViewBag.VehicalID = new SelectList(db.Car, "Id", "CarNo", car_Booking.VehicalID);
                return View(car_Booking);
        }

        // GET: Car_Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_Booking car_Booking = db.Car_Booking.Find(id);
            if (car_Booking == null)
            {
                return HttpNotFound();
            }
            return View(car_Booking);
        }

        // POST: Car_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Car_Booking car_Booking = db.Car_Booking.Find(id);
            db.Car_Booking.Remove(car_Booking);
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
