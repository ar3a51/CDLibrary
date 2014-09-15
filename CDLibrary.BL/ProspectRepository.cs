using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using CDLibraryDataLayer;
using CDLibrary.Common;
using CDLibrary.BL.structs;

namespace CDLibrary.BL
{
    public class ProspectRepository
    {
        static List<StructCDProspect> list = new List<StructCDProspect>();
        static Object syncRoot = new Object();

        public ProspectRepository() { }

        public static int addNewProspect(Prospect prospObject)
        {
            return ProspectProviderManager.Default.AddProspect(prospObject);
        }

        public static Boolean updateProspect(Prospect prospObject)
        {
            if (ProspectProviderManager.Default.updateProspect(prospObject))
            { ProspectProviderManager.Default.saveChanges(); 
                return true; }
            else return false;
        }

        public static Prospect FindProspectById(long prospectId, String owner)
        {
            return ProspectProviderManager.Default.FindProspectByID(prospectId, owner);
        }

        public static IEnumerable<Prospect> FindProspectByLastName(String lastName, String owner)
        {
            return ProspectProviderManager.Default.FindProspectByLastname(lastName, owner);

        }

        public static Prospect FindProspectByEmail(String email, String owner)
        {
            return ProspectProviderManager.Default.FindProspectByEmail(email, owner);
        }

        public static Prospect FindProspectByPhone(String phoneNumber, String owner)
        {
            return ProspectProviderManager.Default.FindProspectByPhoneNumber(phoneNumber, owner);

        }

        public static IEnumerable<StructCDProspect> GetAllCDFromProspect(long prospectId, int length, int page, String owner) { 
        
            lock(syncRoot)
            {
                list.Clear();

                List<CD> cdList = CDProviderManager.Default.FindCDLoanedbyProspectId(prospectId, length, page, owner) as List<CD>;

                StructCDProspect structC;

                foreach (CD c in cdList)
                {
                    structC = new StructCDProspect();
                    structC.cd = c;
                    structC.cdLoanCollection = new CDLoan[c.cdLoanCollection.Count];
                    c.cdLoanCollection.CopyTo(structC.cdLoanCollection, 0);

                    list.Add(structC);

                }

            }
            return list;
        }

        public static Boolean LoanCD(long prospectId,long cdid, int quantity, DateTime endLoanDate, String insertBy)
        {
            return CDRepository.LoanCD(prospectId, cdid, quantity, endLoanDate, insertBy);

        }
    }
}
