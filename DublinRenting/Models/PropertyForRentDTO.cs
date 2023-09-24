using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class PropertyForRentDTO
    {
        public int PropertyForRentID { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Post_Code { get; set; }
        public string Type { get; set; }
        public int Rooms { get; set; }
        public decimal Rent { get; set; }

        //foreign Keys
        public int BranchID { get; set; }
        public int OwnerID { get; set; }
        public int StaffID { get; set; }

        //send PK as FK to
        public List<Viewing> Viewings { get; set; }
    }
}