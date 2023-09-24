using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class PropertyForRent
    {
        private ICollection<Branch> _branches;
        private ICollection<Owner> _owners;
        private ICollection<Staff> _staffs;

        public PropertyForRent()
        {
            _branches = new List<Branch>();
            _owners = new List<Owner>();
            _staffs = new List<Staff>();
        }

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
        public virtual ICollection<Viewing> Viewings { get; set; }

        //receive PK as FK from
        public virtual ICollection<Branch> Branches
        {
            get { return _branches; }
            set { _branches = value; }
        }
        public virtual ICollection<Owner> Owners
        {
            get { return _owners; }
            set { _owners = value; }
        }
        public virtual ICollection<Staff> Staffs
        {
            get { return _staffs; }
            set { _staffs = value; }
        }
    }
}