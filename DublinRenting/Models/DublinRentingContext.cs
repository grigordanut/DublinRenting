using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DublinRenting.Models
{
    public class DublinRentingContext : DbContext
    {
        public DublinRentingContext() : base("DublinRentingContext")
        {

        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyForRent> PropertyForRents { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Viewing> Viewings { get; set; }
    }
}