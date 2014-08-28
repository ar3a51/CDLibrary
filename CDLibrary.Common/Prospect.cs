using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace CDLibrary.Common
{
    public class Prospect
    {
        public Prospect()
        { }

        
        public long prospectID { set; get; }
        public String Firstname { set; get; }
        public String Lastname { set; get; }

        public String AddressLine1 { set; get; }
        public String AddressLine2 { set; get; }
        public String Suburb { set; get; }
        public String state { set; get; }

        public String phoneNumber { set; get; }
        public String emailAddress { set; get; }

        public DateTime insertDate { set; get; }
        public DateTime updateDate { set; get; }

        public String insertBy { set; get; }

        public virtual ICollection<CDLoan> cdLoanCollection { set; get; }

    }
}
