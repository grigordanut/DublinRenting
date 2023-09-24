using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DublinRenting.Models;

namespace DublinRenting.Controllers
{
    public class PropertyForRentsController : Controller
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: PropertyForRents
        public async Task<ActionResult> Index()
        {
            return View(await db.PropertyForRents.ToListAsync());
        }

        //GET: PropertyForRents/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: PropertyForRents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            if (propertyForRent == null)
            {
                return HttpNotFound();
            }
            return View(propertyForRent);
        }

        // GET: PropertyForRents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyForRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PropertyForRentID,Street,Area,City,Post_Code,Type,Rooms,Rent,BranchID,OwnerID,StaffID")] PropertyForRent propertyForRent)
        {
            if (ModelState.IsValid)
            {
                db.PropertyForRents.Add(propertyForRent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(propertyForRent);
        }

        // GET: PropertyForRents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            if (propertyForRent == null)
            {
                return HttpNotFound();
            }
            return View(propertyForRent);
        }

        // POST: PropertyForRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PropertyForRentID,Street,Area,City,Post_Code,Type,Rooms,Rent,BranchID,OwnerID,StaffID")] PropertyForRent propertyForRent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyForRent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(propertyForRent);
        }

        // GET: PropertyForRents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            if (propertyForRent == null)
            {
                return HttpNotFound();
            }
            return View(propertyForRent);
        }

        // POST: PropertyForRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            db.PropertyForRents.Remove(propertyForRent);
            await db.SaveChangesAsync();
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
