using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class Viewing
    {
        private ICollection<PropertyForRent> _propertyforrents;
        private ICollection<Renter> _renters;
        private ICollection<Staff> _staffs;

        public Viewing()
        {
            _propertyforrents = new List<PropertyForRent>();
            _renters = new List<Renter>();
            _staffs = new List<Staff>();
        }

        public int ViewingID { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public decimal Price_Offered { get; set; }

        //foreign Keys
        [Display(Name = "Property For Rent ID")]
        public int PropertyForRentID { get; set; }
        public int RenterID { get; set; }
        public int StaffID { get; set; }

        //receive PK as FK from
        public virtual ICollection<PropertyForRent> PropertyForRents
        {
            get { return _propertyforrents; }
            set { _propertyforrents = value; }
        }
        public virtual ICollection<Renter> Renters
        {
            get { return _renters; }
            set { _renters = value; }
        }
        public virtual ICollection<Staff> Staffs
        {
            get { return _staffs; }
            set { _staffs = value; }
        }
    }
}