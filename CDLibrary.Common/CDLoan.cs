using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLibrary.Common
{
    public class CDLoan
    {
        public CDLoan()
        { }

        public long CDid { set; get; }
        public long prospectId { set; get; }

        public virtual CD cd { set; get; }
        public virtual Prospect prospect { set; get; }

        public DateTime starLoanDate { set; get; }
        public DateTime endLoanDate { set; get; }

        public int quantity { set; get; }

        public String insertBy { set; get; }

    }

    
}
