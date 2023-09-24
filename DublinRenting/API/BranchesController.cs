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
    public class BranchesController : ApiController
    {
        private DublinRentingContext db = new DublinRentingContext();

        // GET: api/Branches
        public IQueryable<BranchDTO> GetBranches()
        {
            var branches = from b in db.Branches
                           select new BranchDTO()
                           {
                               BranchID = b.BranchID,
                               Street = b.Street,
                               Area = b.Area,
                               City = b.City,
                               Post_Code = b.Post_Code,
                               Tel_No = b.Tel_No
                           };
            return branches;
        }

        // GET: api/Branches/5
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> GetBranch(int id)
        {
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // PUT: api/Branches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBranch(int id, Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branch.BranchID)
            {
                return BadRequest();
            }

            db.Entry(branch).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        // POST: api/Branches
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> PostBranch(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Branches.Add(branch);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = branch.BranchID }, branch);
        }

        // DELETE: api/Branches/5
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> DeleteBranch(int id)
        {
            Branch branch = await db.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            db.Branches.Remove(branch);
            await db.SaveChangesAsync();

            return Ok(branch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchExists(int id)
        {
            return db.Branches.Count(e => e.BranchID == id) > 0;
        }
    }
}