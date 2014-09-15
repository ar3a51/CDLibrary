using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Provider;

using CDLibrary.Common;

namespace CDLibraryDataLayer.Abstracts
{
    public abstract class ProspectProviderBase : ProviderBase
    {
        public abstract int AddProspect (Prospect prospectObject);
        public abstract Boolean updateProspect(Prospect prospectObject);

        public abstract ICollection<Prospect> FindProspectByFirstname(String firstName, String owner);
        public abstract ICollection<Prospect> FindProspectByLastname(String lastName, String owner);
        public abstract Prospect FindProspectByEmail(String emailAddress, String owner);
        public abstract Prospect FindProspectByID(long prospectID, String owner);

        public abstract Prospect FindProspectByPhoneNumber(String phoneNumber, String owner);

        public abstract Boolean loanCD(Prospect prospectObject, CD CDObject, DateTime endLoanDate, String insertBy);

       
        public abstract IEnumerable<Prospect> findCDLoanById(long cdid, int length, int page, String owner);

        public abstract int saveChanges();
        
    }

}
