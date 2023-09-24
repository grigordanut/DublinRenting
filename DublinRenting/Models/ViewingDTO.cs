using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class ViewingDTO
    {
        public int ViewingID { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public decimal Price_Offered { get; set; }

        //foreign Keys
        public int PropertyForRentID { get; set; }
        public int RenterID { get; set; }
        public int StaffID { get; set; }
    }
}