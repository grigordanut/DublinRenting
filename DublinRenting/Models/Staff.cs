using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DublinRenting.Models
{
    public class Staff
    {
        private ICollection<Branch> _branches;

        public Staff()
        {
            _branches = new List<Branch>();
        }

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
        public virtual ICollection<Viewing> Viewings { get; set; }
        public virtual ICollection<PropertyForRent> PropertyForRents { get; set; }

        //receive PK as FK from
        public virtual ICollection<Branch> Branches
        {
            get { return _branches; }
            set { _branches = value; }
        }
    }
}