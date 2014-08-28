using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CDLibrary.Common
{
    public class CD 
    {
        public CD()
        {

            

        }

        
        public long CDid { set; get; }
        public String Title { set; get; }
        public String Artist { set; get; }
        public int quantity { set; get; }
        public DateTime insertDate { set; get; }
        public DateTime updateDate { set; get; }
        

        public String insertBy { set; get; }
       

        public virtual ICollection<CDLoan> cdLoanCollection { set; get; }

        
    }
}
