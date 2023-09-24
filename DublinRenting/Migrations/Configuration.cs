namespace DublinRenting.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using DublinRenting.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DublinRenting.Models.DublinRentingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DublinRenting.Models.DublinRentingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //seeds Branches
            var branches = new List<Branch>
            {
                new Branch{BranchID=2, Street="23 Finglas Road", Area="Finglas", City="Dublin", Post_Code="D11",Tel_No="01-4567896"}
            };
            branches.ForEach(b => context.Branches.AddOrUpdate(branch => branch.Street, b));
            context.SaveChanges();

            //seeds Owners
            var owners = new List<Owner>
            {
                new Owner {OwnerID=1, First_Name="Peter", Last_Name="Murphy", Address="45 Casimir Avenue", Phone="0879654584"}
            };
            owners.ForEach(o => context.Owners.AddOrUpdate(owner => owner.First_Name, o));
            context.SaveChanges();

            //sseds Properties for Rent
            var propertyforrents = new List<PropertyForRent>
            {
                new PropertyForRent{PropertyForRentID=1, Street="234 Clontarf Road", Area="Clontarf", City="Dublin", Post_Code="D3", Type="Flat", Rooms=3, Rent=1200, BranchID=1,OwnerID=2, StaffID=1}
            };
            propertyforrents.ForEach(p => context.PropertyForRents.AddOrUpdate(propertyforrent => propertyforrent.Street, p));
            context.SaveChanges();

            //seeds Renters
            var renters = new List<Renter>
            {
                new Renter{RenterID=1, First_Name="Michael", Last_Name="Duncan", Address="89 Parnell Street", Phone_No="0895674573", Pref_Type="Flat", Max_Rent=900}
            };
            renters.ForEach(r => context.Renters.AddOrUpdate(renter => renter.First_Name, r));
            context.SaveChanges();

            //seeds Staffs
            var staffs = new List<Staff>
            {
                new Staff{StaffID=1, First_Name="Brenda", Last_Name="Clarke",Gender="Female", Address="34 Manor Street", Phone_No="0879675564", Position="Manager", Salary=28000, BranchID=1}
            };
            staffs.ForEach(s => context.Staffs.AddOrUpdate(staff => staff.First_Name, s));
            context.SaveChanges();

            //seeds Viewing
            var viewings = new List<Viewing>
            {
                
            };
            viewings.ForEach(v => context.Viewings.AddOrUpdate(viewing => viewing.Date, v));
            context.SaveChanges();
        }
    }
}
