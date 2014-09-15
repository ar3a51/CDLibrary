using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CDLibrary.Common;
using CDLibraryDataLayer.Abstracts;

namespace CDLibraryDataLayer
{
    public class ProspectDataLayer:ProspectProviderBase
    {
        private CDLibraryContext context;

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            context = CDLibraryContext.Context;
        }


        public override int AddProspect(Prospect prospectObject)
        {
            context.Prospects.Add(prospectObject);
            return context.SaveChanges();
        }

        public override bool updateProspect(Prospect prospectObject)
        {
            try
            {
                Prospect pro = context.Prospects.Find(prospectObject.prospectID);

                pro.AddressLine1 = prospectObject.AddressLine1;
                pro.AddressLine2 = prospectObject.AddressLine2;
                pro.emailAddress = prospectObject.emailAddress;
                pro.Firstname = prospectObject.Firstname;
                pro.insertBy = prospectObject.insertBy;
                pro.insertDate = prospectObject.insertDate;
                pro.Lastname = prospectObject.Lastname;
                pro.phoneNumber = prospectObject.phoneNumber;
                pro.state = prospectObject.state;
                pro.Suburb = prospectObject.Suburb;
                pro.updateDate = prospectObject.updateDate;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override ICollection<Prospect> FindProspectByFirstname(string firstName, String owner)
        {
            return context.Prospects.Where(p => p.Firstname.Contains(firstName) && p.insertBy.Equals(owner)).ToList<Prospect>();
        }

        public override ICollection<Prospect> FindProspectByLastname(string lastName, String owner)
        {
            return context.Prospects.Where(p => p.Lastname.Contains(lastName) && p.insertBy.Equals(owner)).ToList<Prospect>();
        }

        public override Prospect FindProspectByEmail(string emailAddress, String owner)
        {
            return context.Prospects.Where(p => p.emailAddress.Equals(emailAddress) && p.insertBy.Equals(owner)).FirstOrDefault<Prospect>();
        }

        public override Prospect FindProspectByID(long prospectID, String owner)
        {
            return context.Prospects.Where(p => p.prospectID == prospectID && p.insertBy.Equals(owner)).FirstOrDefault<Prospect>();
        }

        public override Prospect FindProspectByPhoneNumber(string phoneNumber, String owner)
        {
            return context.Prospects.Where(p => p.phoneNumber.Equals(phoneNumber) && p.insertBy.Equals(owner)).FirstOrDefault<Prospect>();
        }

        public override bool loanCD(Prospect prospectObject, CD CDObject, DateTime endLoanDate, String insertBy)
        {
            //throw new NotImplementedException();
            try
            {
                CDLoan loanCD = new CDLoan
                {
                    CDid = CDObject.CDid,
                    endLoanDate = endLoanDate,
                    prospectId = prospectObject.prospectID,
                    insertBy = insertBy,
                    starLoanDate = DateTime.Now
                };

                context.CDLoans.Add(loanCD);

                

                return true;
            }
            catch(Exception ex)
            { return false; }
        }

     

        public override IEnumerable<Prospect> findCDLoanById(long cdid, int length, int page, String owner)
        {

            page = page - 1;



            return (from cl in context.CDLoans
                    join p in context.Prospects on cl.prospectId equals p.prospectID
                    where cl.CDid == cdid && cl.insertBy.Equals(owner)
                    select p
                     ).Take(length).OrderBy(p => p.Lastname).Skip(length * page).ToList<Prospect>();


        }

        public override int saveChanges()
        {
            return context.SaveChanges();
        }
    }
}
