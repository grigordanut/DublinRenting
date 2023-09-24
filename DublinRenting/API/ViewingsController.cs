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
    public class ViewingsController : ApiController
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: api/Viewings
        public IQueryable<ViewingDTO> GetViewings()
        {
            var viewings = from v in db.Viewings
                           select new ViewingDTO
                           {
                               ViewingID = v.ViewingID,
                               Date = v.Date,
                               Comments = v.Comments,
                               Price_Offered = v.Price_Offered,
                               PropertyForRentID = v.PropertyForRentID,
                               RenterID = v.RenterID,
                               StaffID = v.StaffID
                           };
            return viewings;
        }

        // GET: api/Viewings/5
        [ResponseType(typeof(Viewing))]
        public async Task<IHttpActionResult> GetViewing(int id)
        {
            Viewing viewing = await db.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return NotFound();
            }

            return Ok(viewing);
        }

        // PUT: api/Viewings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutViewing(int id, Viewing viewing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewing.ViewingID)
            {
                return BadRequest();
            }

            db.Entry(viewing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewingExists(id))
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

        // POST: api/Viewings
        [ResponseType(typeof(Viewing))]
        public async Task<IHttpActionResult> PostViewing(Viewing viewing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Viewings.Add(viewing);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = viewing.ViewingID }, viewing);
        }

        // DELETE: api/Viewings/5
        [ResponseType(typeof(Viewing))]
        public async Task<IHttpActionResult> DeleteViewing(int id)
        {
            Viewing viewing = await db.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return NotFound();
            }

            db.Viewings.Remove(viewing);
            await db.SaveChangesAsync();

            return Ok(viewing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewingExists(int id)
        {
            return db.Viewings.Count(e => e.ViewingID == id) > 0;
        }
    }
}