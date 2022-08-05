using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoAncillariesLimited.Models;

namespace AutoAncillariesLimited.Controllers
{
    public class PartsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Parts
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.CarBrand).Include(p => p.Category).Include(p => p.Manufacturer).Include(p => p.Supplier);
            return View(parts.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "CarBrandId", "Country");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "PartId,Name,CarBrandId,SupplierId,ManufacturerId,CategoryId,CarName,UnitPrice,Description,Conditon,Image,Image1,Image2,QtyInStock")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarBrandId = new SelectList(db.CarBrands, "CarBrandId", "Country", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", part.SupplierId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "CarBrandId", "Country", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", part.SupplierId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,Name,CarBrandId,SupplierId,ManufacturerId,CategoryId,CarName,UnitPrice,Description,Conditon,Image,Image1,Image2,QtyInStock")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "CarBrandId", "Country", part.CarBrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", part.CategoryId);
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "ManufacturerId", "Name", part.ManufacturerId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", part.SupplierId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
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
