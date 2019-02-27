using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyanTour;
using System.IO;

namespace MyanTour.Controllers
{
    public class CarsController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Car.ToList());
        }
        public ActionResult Choose(string id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Create", "Car_Booking", new { vehid = id });        
        }
        public ActionResult Search(string searchString)
        {
            var car = from m in db.Car
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(s => s.DriverName.Contains(searchString));
            }

            return View(car);
        }
        // GET: Cars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CarNo,DriverName,Model,Pic,Seat,State")] Car car)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["file"];            
                byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageBytes = reader.ReadBytes((int)file.ContentLength);
                // car.Pic = ConvertToBytes(file);
                car.Pic = imageBytes;
                db.Car.Add(car);    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
        //convert image to byte
        //public byte[] ConvertToBytes(HttpPostedFileBase image)

        //{

        //    byte[] imageBytes = null;

        //    BinaryReader reader = new BinaryReader(image.InputStream);

        //    imageBytes = reader.ReadBytes((int)image.ContentLength);

        //    return imageBytes;

        //}

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarNo,DriverName,Model,Pic,Seat,State")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Car car = db.Car.Find(id);
            db.Car.Remove(car);
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
