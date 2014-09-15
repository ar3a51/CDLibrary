using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Provider;

using CDLibrary.Common;

namespace CDLibraryDataLayer.Abstracts
{
    public abstract class CDproviderbase : ProviderBase
    {
       

        public abstract int InsertCD(CD cdObject);
        public abstract Boolean UpdateCD(CD cdObject);

        public abstract ICollection<CD> FindCDByName(String name, String owner);
        public abstract CD FindCDByID(long id, String owner);

        public abstract ICollection<CD> FindCDLoanedbyProspectId(long prospectID, int length, int page, String owner);

        public abstract int countCDbyAlphabet(char character, String owner);

        public abstract Boolean addLoanInformation(CDLoan loanInfo);

        public abstract int saveChanges();
    }
}
