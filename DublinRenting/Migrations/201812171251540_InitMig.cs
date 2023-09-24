namespace DublinRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Area = c.String(),
                        City = c.String(),
                        Post_Code = c.String(),
                        Tel_No = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.PropertyForRents",
                c => new
                    {
                        PropertyForRentID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Area = c.String(),
                        City = c.String(),
                        Post_Code = c.String(),
                        Type = c.String(),
                        Rooms = c.Int(nullable: false),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BranchID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyForRentID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone_No = c.String(),
                        Position = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        ViewingID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Price_Offered = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PropertyForRentID = c.Int(nullable: false),
                        RenterID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViewingID);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        RenterID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Address = c.String(),
                        Phone_No = c.String(),
                        Pref_Type = c.String(),
                        Max_Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RenterID);
            
            CreateTable(
                "dbo.PropertyForRentBranches",
                c => new
                    {
                        PropertyForRent_PropertyForRentID = c.Int(nullable: false),
                        Branch_BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PropertyForRent_PropertyForRentID, t.Branch_BranchID })
                .ForeignKey("dbo.PropertyForRents", t => t.PropertyForRent_PropertyForRentID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchID, cascadeDelete: true)
                .Index(t => t.PropertyForRent_PropertyForRentID)
                .Index(t => t.Branch_BranchID);
            
            CreateTable(
                "dbo.OwnerPropertyForRents",
                c => new
                    {
                        Owner_OwnerID = c.Int(nullable: false),
                        PropertyForRent_PropertyForRentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Owner_OwnerID, t.PropertyForRent_PropertyForRentID })
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.PropertyForRents", t => t.PropertyForRent_PropertyForRentID, cascadeDelete: true)
                .Index(t => t.Owner_OwnerID)
                .Index(t => t.PropertyForRent_PropertyForRentID);
            
            CreateTable(
                "dbo.StaffBranches",
                c => new
                    {
                        Staff_StaffID = c.Int(nullable: false),
                        Branch_BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Staff_StaffID, t.Branch_BranchID })
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchID, cascadeDelete: true)
                .Index(t => t.Staff_StaffID)
                .Index(t => t.Branch_BranchID);
            
            CreateTable(
                "dbo.StaffPropertyForRents",
                c => new
                    {
                        Staff_StaffID = c.Int(nullable: false),
                        PropertyForRent_PropertyForRentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Staff_StaffID, t.PropertyForRent_PropertyForRentID })
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID, cascadeDelete: true)
                .ForeignKey("dbo.PropertyForRents", t => t.PropertyForRent_PropertyForRentID, cascadeDelete: true)
                .Index(t => t.Staff_StaffID)
                .Index(t => t.PropertyForRent_PropertyForRentID);
            
            CreateTable(
                "dbo.ViewingPropertyForRents",
                c => new
                    {
                        Viewing_ViewingID = c.Int(nullable: false),
                        PropertyForRent_PropertyForRentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Viewing_ViewingID, t.PropertyForRent_PropertyForRentID })
                .ForeignKey("dbo.Viewings", t => t.Viewing_ViewingID, cascadeDelete: true)
                .ForeignKey("dbo.PropertyForRents", t => t.PropertyForRent_PropertyForRentID, cascadeDelete: true)
                .Index(t => t.Viewing_ViewingID)
                .Index(t => t.PropertyForRent_PropertyForRentID);
            
            CreateTable(
                "dbo.RenterViewings",
                c => new
                    {
                        Renter_RenterID = c.Int(nullable: false),
                        Viewing_ViewingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Renter_RenterID, t.Viewing_ViewingID })
                .ForeignKey("dbo.Renters", t => t.Renter_RenterID, cascadeDelete: true)
                .ForeignKey("dbo.Viewings", t => t.Viewing_ViewingID, cascadeDelete: true)
                .Index(t => t.Renter_RenterID)
                .Index(t => t.Viewing_ViewingID);
            
            CreateTable(
                "dbo.ViewingStaffs",
                c => new
                    {
                        Viewing_ViewingID = c.Int(nullable: false),
                        Staff_StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Viewing_ViewingID, t.Staff_StaffID })
                .ForeignKey("dbo.Viewings", t => t.Viewing_ViewingID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID, cascadeDelete: true)
                .Index(t => t.Viewing_ViewingID)
                .Index(t => t.Staff_StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViewingStaffs", "Staff_StaffID", "dbo.Staffs");
            DropForeignKey("dbo.ViewingStaffs", "Viewing_ViewingID", "dbo.Viewings");
            DropForeignKey("dbo.RenterViewings", "Viewing_ViewingID", "dbo.Viewings");
            DropForeignKey("dbo.RenterViewings", "Renter_RenterID", "dbo.Renters");
            DropForeignKey("dbo.ViewingPropertyForRents", "PropertyForRent_PropertyForRentID", "dbo.PropertyForRents");
            DropForeignKey("dbo.ViewingPropertyForRents", "Viewing_ViewingID", "dbo.Viewings");
            DropForeignKey("dbo.StaffPropertyForRents", "PropertyForRent_PropertyForRentID", "dbo.PropertyForRents");
            DropForeignKey("dbo.StaffPropertyForRents", "Staff_StaffID", "dbo.Staffs");
            DropForeignKey("dbo.StaffBranches", "Branch_BranchID", "dbo.Branches");
            DropForeignKey("dbo.StaffBranches", "Staff_StaffID", "dbo.Staffs");
            DropForeignKey("dbo.OwnerPropertyForRents", "PropertyForRent_PropertyForRentID", "dbo.PropertyForRents");
            DropForeignKey("dbo.OwnerPropertyForRents", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.PropertyForRentBranches", "Branch_BranchID", "dbo.Branches");
            DropForeignKey("dbo.PropertyForRentBranches", "PropertyForRent_PropertyForRentID", "dbo.PropertyForRents");
            DropIndex("dbo.ViewingStaffs", new[] { "Staff_StaffID" });
            DropIndex("dbo.ViewingStaffs", new[] { "Viewing_ViewingID" });
            DropIndex("dbo.RenterViewings", new[] { "Viewing_ViewingID" });
            DropIndex("dbo.RenterViewings", new[] { "Renter_RenterID" });
            DropIndex("dbo.ViewingPropertyForRents", new[] { "PropertyForRent_PropertyForRentID" });
            DropIndex("dbo.ViewingPropertyForRents", new[] { "Viewing_ViewingID" });
            DropIndex("dbo.StaffPropertyForRents", new[] { "PropertyForRent_PropertyForRentID" });
            DropIndex("dbo.StaffPropertyForRents", new[] { "Staff_StaffID" });
            DropIndex("dbo.StaffBranches", new[] { "Branch_BranchID" });
            DropIndex("dbo.StaffBranches", new[] { "Staff_StaffID" });
            DropIndex("dbo.OwnerPropertyForRents", new[] { "PropertyForRent_PropertyForRentID" });
            DropIndex("dbo.OwnerPropertyForRents", new[] { "Owner_OwnerID" });
            DropIndex("dbo.PropertyForRentBranches", new[] { "Branch_BranchID" });
            DropIndex("dbo.PropertyForRentBranches", new[] { "PropertyForRent_PropertyForRentID" });
            DropTable("dbo.ViewingStaffs");
            DropTable("dbo.RenterViewings");
            DropTable("dbo.ViewingPropertyForRents");
            DropTable("dbo.StaffPropertyForRents");
            DropTable("dbo.StaffBranches");
            DropTable("dbo.OwnerPropertyForRents");
            DropTable("dbo.PropertyForRentBranches");
            DropTable("dbo.Renters");
            DropTable("dbo.Viewings");
            DropTable("dbo.Staffs");
            DropTable("dbo.Owners");
            DropTable("dbo.PropertyForRents");
            DropTable("dbo.Branches");
        }
    }
}
