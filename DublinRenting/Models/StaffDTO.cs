using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class StaffDTO
    {
        public int StaffID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        //foreign Key
        public int BranchID { get; set; }

        //send PK as FK to
        public List<PropertyForRent> PropertyForRents { get; set; }
        public List<Viewing> Viewings { get; set; }
    }
}