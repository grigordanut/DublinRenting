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
    public class PropertyForRentsController : ApiController
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: api/PropertyForRents
        public IQueryable<PropertyForRentDTO> GetPropertyForRents()
        {
            var propertyforrents = from p in db.PropertyForRents
                                   select new PropertyForRentDTO()
                                   {
                                       PropertyForRentID = p.PropertyForRentID,
                                       Street = p.Street,
                                       City = p.City,
                                       Post_Code = p.Post_Code,
                                       Type = p.Type,
                                       Rooms = p.Rooms,
                                       Rent = p.Rent,
                                       BranchID = p.BranchID,
                                       OwnerID = p.OwnerID,
                                       StaffID = p.StaffID,
                                   };

            return propertyforrents;
        }

        // GET: api/PropertyForRents/5
        [ResponseType(typeof(PropertyForRent))]
        public async Task<IHttpActionResult> GetPropertyForRent(int id)
        {
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            if (propertyForRent == null)
            {
                return NotFound();
            }

            return Ok(propertyForRent);
        }

        // PUT: api/PropertyForRents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropertyForRent(int id, PropertyForRent propertyForRent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyForRent.PropertyForRentID)
            {
                return BadRequest();
            }

            db.Entry(propertyForRent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyForRentExists(id))
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

        // POST: api/PropertyForRents
        [ResponseType(typeof(PropertyForRent))]
        public async Task<IHttpActionResult> PostPropertyForRent(PropertyForRent propertyForRent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PropertyForRents.Add(propertyForRent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = propertyForRent.PropertyForRentID }, propertyForRent);
        }

        // DELETE: api/PropertyForRents/5
        [ResponseType(typeof(PropertyForRent))]
        public async Task<IHttpActionResult> DeletePropertyForRent(int id)
        {
            PropertyForRent propertyForRent = await db.PropertyForRents.FindAsync(id);
            if (propertyForRent == null)
            {
                return NotFound();
            }

            db.PropertyForRents.Remove(propertyForRent);
            await db.SaveChangesAsync();

            return Ok(propertyForRent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyForRentExists(int id)
        {
            return db.PropertyForRents.Count(e => e.PropertyForRentID == id) > 0;
        }
    }
}