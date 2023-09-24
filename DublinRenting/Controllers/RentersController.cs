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
    public class RentersController : Controller
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: Renters
        public async Task<ActionResult> Index()
        {
            return View(await db.Renters.ToListAsync());
        }

        //GET: Renters/search
        public ActionResult Search()
        {
            return View();
        }

        // GET: Renters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renter renter = await db.Renters.FindAsync(id);
            if (renter == null)
            {
                return HttpNotFound();
            }
            return View(renter);
        }

        // GET: Renters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Renters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RenterID,First_Name,Last_Name,Address,Phone_No,Pref_Type,Max_Rent")] Renter renter)
        {
            if (ModelState.IsValid)
            {
                db.Renters.Add(renter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(renter);
        }

        // GET: Renters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renter renter = await db.Renters.FindAsync(id);
            if (renter == null)
            {
                return HttpNotFound();
            }
            return View(renter);
        }

        // POST: Renters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RenterID,First_Name,Last_Name,Address,Phone_No,Pref_Type,Max_Rent")] Renter renter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(renter);
        }

        // GET: Renters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renter renter = await db.Renters.FindAsync(id);
            if (renter == null)
            {
                return HttpNotFound();
            }
            return View(renter);
        }

        // POST: Renters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Renter renter = await db.Renters.FindAsync(id);
            db.Renters.Remove(renter);
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
