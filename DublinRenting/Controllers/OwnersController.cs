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
    public class OwnersController : Controller
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: Owners
        public async Task<ActionResult> Index()
        {
            return View(await db.Owners.ToListAsync());
        }

        //GET: Owners/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: Owners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = await db.Owners.FindAsync(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OwnerID,First_Name,Last_Name,Address,Phone")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(owner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = await db.Owners.FindAsync(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OwnerID,First_Name,Last_Name,Address,Phone")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = await db.Owners.FindAsync(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Owner owner = await db.Owners.FindAsync(id);
            db.Owners.Remove(owner);
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
