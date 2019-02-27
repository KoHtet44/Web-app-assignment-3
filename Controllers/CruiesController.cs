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
    public class CruiesController : Controller
    {
        private MyanTourEntities db = new MyanTourEntities();

        // GET: Cruies
        public ActionResult Index()
        {
            return View(db.Cruies.ToList());
        }
        public ActionResult Choose(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Create", "Cruies_Booking", new { vehid = id });
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

        // GET: Cruies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies cruies = db.Cruies.Find(id);
            if (cruies == null)
            {
                return HttpNotFound();
            }
            return View(cruies);
        }

        // GET: Cruies/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShipNumber,Captain,Model,Pic,Seat,AvailableSeat,State")] Cruies cruies)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["file"];
                byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageBytes = reader.ReadBytes((int)file.ContentLength);
                // car.Pic = ConvertToBytes(file);
                cruies.Pic = imageBytes;
                db.Cruies.Add(cruies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cruies);
        }

        // GET: Cruies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies cruies = db.Cruies.Find(id);
            if (cruies == null)
            {
                return HttpNotFound();
            }
            return View(cruies);
        }

        // POST: Cruies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShipNumber,Captain,Model,Pic,Seat,AvailableSeat,State")] Cruies cruies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cruies);
        }

        // GET: Cruies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruies cruies = db.Cruies.Find(id);
            if (cruies == null)
            {
                return HttpNotFound();
            }
            return View(cruies);
        }

        // POST: Cruies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cruies cruies = db.Cruies.Find(id);
            db.Cruies.Remove(cruies);
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
