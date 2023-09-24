using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DublinRenting.Models;

namespace DublinRenting.API
{
    public class RentersController : ApiController
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: api/Renters
        public IQueryable<RenterDTO> GetRenters()
        {
            var renters = from r in db.Renters
                          select new RenterDTO()
                          {
                              RenterID = r.RenterID,
                              First_Name = r.First_Name,
                              Last_Name = r.Last_Name,
                              Phone_No = r.Phone_No,
                              Pref_Type = r.Pref_Type,
                              Max_Rent = r.Max_Rent
                          };

            return renters;
        }

        // GET: api/Renters/5
        [ResponseType(typeof(Renter))]
        public async Task<IHttpActionResult> GetRenter(int id)
        {
            Renter renter = await db.Renters.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }

            return Ok(renter);
        }

        // PUT: api/Renters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRenter(int id, Renter renter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != renter.RenterID)
            {
                return BadRequest();
            }

            db.Entry(renter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Renters
        [ResponseType(typeof(Renter))]
        public async Task<IHttpActionResult> PostRenter(Renter renter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Renters.Add(renter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = renter.RenterID }, renter);
        }

        // DELETE: api/Renters/5
        [ResponseType(typeof(Renter))]
        public async Task<IHttpActionResult> DeleteRenter(int id)
        {
            Renter renter = await db.Renters.FindAsync(id);
            if (renter == null)
            {
                return NotFound();
            }

            db.Renters.Remove(renter);
            await db.SaveChangesAsync();

            return Ok(renter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RenterExists(int id)
        {
            return db.Renters.Count(e => e.RenterID == id) > 0;
        }
    }
}