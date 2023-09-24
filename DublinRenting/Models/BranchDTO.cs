using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class BranchDTO
    {
        public int BranchID { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Post_Code { get; set; }
        public string Tel_No { get; set; }

        //send PK as FK to
        public List<Staff> Staffs { get; set; }
        public List<PropertyForRent> PropertyForRents { get; set; }
    }
}