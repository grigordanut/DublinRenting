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
    public class OwnersController : ApiController
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: api/Owners
        public IQueryable<OwnerDTO> GetOwners()
        {
            var owners = from o in db.Owners
                         select new OwnerDTO()
                         {
                             OwnerID = o.OwnerID,
                             First_Name = o.First_Name,
                             Last_Name = o.Last_Name,
                             Address = o.Address,
                             Phone = o.Phone
                         };
            return owners;
        }

        // GET: api/Owners/5
        [ResponseType(typeof(Owner))]
        public async Task<IHttpActionResult> GetOwner(int id)
        {
            Owner owner = await db.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOwner(int id, Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.OwnerID)
            {
                return BadRequest();
            }

            db.Entry(owner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        [ResponseType(typeof(Owner))]
        public async Task<IHttpActionResult> PostOwner(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Owners.Add(owner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = owner.OwnerID }, owner);
        }

        // DELETE: api/Owners/5
        [ResponseType(typeof(Owner))]
        public async Task<IHttpActionResult> DeleteOwner(int id)
        {
            Owner owner = await db.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            db.Owners.Remove(owner);
            await db.SaveChangesAsync();

            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerExists(int id)
        {
            return db.Owners.Count(e => e.OwnerID == id) > 0;
        }
    }
}