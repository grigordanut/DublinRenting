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
    public class ViewingsController : Controller
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: Viewings
        public async Task<ActionResult> Index()
        {
            return View(await db.Viewings.ToListAsync());
        }

        //GET: Viewings/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: Viewings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewing viewing = await db.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return HttpNotFound();
            }
            return View(viewing);
        }

        // GET: Viewings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viewings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ViewingID,Date,Comments,Price_Offered,PropertyForRentID,RenterID,StaffID")] Viewing viewing)
        {
            if (ModelState.IsValid)
            {
                db.Viewings.Add(viewing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewing);
        }

        // GET: Viewings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewing viewing = await db.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return HttpNotFound();
            }
            return View(viewing);
        }

        // POST: Viewings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ViewingID,Date,Comments,Price_Offered,PropertyForRentID,RenterID,StaffID")] Viewing viewing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewing);
        }

        // GET: Viewings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viewing viewing = await db.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return HttpNotFound();
            }
            return View(viewing);
        }

        // POST: Viewings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Viewing viewing = await db.Viewings.FindAsync(id);
            db.Viewings.Remove(viewing);
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
