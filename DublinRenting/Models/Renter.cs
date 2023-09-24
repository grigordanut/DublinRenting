using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class Renter
    {
        public int RenterID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Pref_Type { get; set; }
        public decimal Max_Rent { get; set; }

        //send PK as FK to
        public virtual ICollection<Viewing> Viewings { get; set; }
    }
}