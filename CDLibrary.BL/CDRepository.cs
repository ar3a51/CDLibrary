using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using CDLibrary.Common;

using CDLibraryDataLayer;
using CDLibrary.BL.structs;

namespace CDLibrary.BL
{
    public class CDRepository
    {
        static Object syncObject = new Object();
        static List<StructProspectLoanCD> list = new List<StructProspectLoanCD>();
        public CDRepository()
        { 
            
        }

        public static int AddNewCD(CD cd)
        {

            return CDProviderManager.Default.InsertCD(cd);

        }

        public static Boolean updateCD(CD cd)
        {
            if(CDProviderManager.Default.UpdateCD(cd))
            {
                CDProviderManager.Default.saveChanges();
                return true;
            }
            else { return false; };
        }

        public static IEnumerable<CD> FindCDByName(String name, String insertBy)
        {
            return CDProviderManager.Default.FindCDByName(name, insertBy);
        }

        public static IEnumerable<Object> GenerateAlphabeticalListCD()
        {
            //TODO: generate alphabetical list of CDs
            throw new NotImplementedException("not yet");
        }

        public static IEnumerable<StructProspectLoanCD> FindProspectLoanById(long cdid, int length,int pageNumber, String insertBy)
        {

            lock (syncObject)
            {

                List<Prospect> result = CDProviderManager.Default.findCDLoanById(cdid, length,
                                                                                pageNumber,
                                                                                insertBy) as List<Prospect>;

                list.Clear();

                StructProspectLoanCD structP;

                foreach (Prospect p in result)
                {
                    structP = new StructProspectLoanCD();
                    structP.prospect = p;
                    structP.CDLoanCollection = new CDLoan[p.cdLoanCollection.Count];
                    p.cdLoanCollection.CopyTo(structP.CDLoanCollection, 0);

                    list.Add(structP);

                }
            }

            return list;
        
        }

        public static CD FindCDById(long cdid, String insertBy)
        {
            return CDProviderManager.Default.FindCDByID(cdid, insertBy);
        }

        public static Boolean LoanCD(long prospectId, 
                                    long cdId, 
                                    int quantity, 
                                    DateTime endLoanDate, 
                                    String insertBy)
        {
            CDLoan loanDetails;

            lock(syncObject)
            {
                CD cd = CDProviderManager.Default.FindCDByID(cdId, insertBy);
                if (cd.quantity.Equals(0))
                    throw new ArgumentOutOfRangeException("You don't have any more CD");

                cd.quantity = cd.quantity - quantity;

                if (CDProviderManager.Default.UpdateCD(cd))
                {
                    loanDetails = new CDLoan
                    {
                        CDid = cdId,
                        prospectId = prospectId,
                        starLoanDate = DateTime.Now,
                        endLoanDate = endLoanDate,
                        insertBy = insertBy,
                        quantity = quantity
                    };

                    if (CDProviderManager.Default.addLoanInformation(loanDetails))
                        CDProviderManager.Default.saveChanges();
                    return true;
                }
                else
                    return false;

            }

        }
    }
}
