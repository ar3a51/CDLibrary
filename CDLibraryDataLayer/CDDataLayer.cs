using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CDLibrary.Common;
using CDLibraryDataLayer.Abstracts;

namespace CDLibraryDataLayer
{
   public class CDDataLayer:CDproviderbase
    {
        private CDLibraryContext context;
        

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            context = CDLibraryContext.Context;
        }

       

        public override int InsertCD(CD cdObject)
        {
            try
            {
                context.CDs.Add(cdObject);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public override bool UpdateCD(CD cdObject)
        {
             try
            {
                CD cd = context.CDs.Find(cdObject.CDid);

                cd.Artist = cdObject.Artist;
                cd.Title = cdObject.Title;
                cd.insertBy = cdObject.insertBy;
                cd.quantity = cdObject.quantity;
                cd.updateDate = DateTime.Now;

                 

                return true;
            }
            catch(Exception ex)
             {

                 return false;
             }
            
        }

        public override ICollection<CD> FindCDByName(string name, String owner)
        {
            IQueryable<CD> result = context.CDs.Where(c => c.Title.Contains(name) && c.insertBy.Equals(owner));

            
            return result.ToList<CD>();

        }

        public override CD FindCDByID(long id, String owner)
        {
            return context.CDs.Where(c => c.CDid == id && c.insertBy == owner).FirstOrDefault<CD>();
        }

        public override int countCDbyAlphabet(char character, String owner)
        {
            return context.CDs.Where(c => c.Title.StartsWith(character.ToString()) 
                && c.insertBy.Equals(owner)).Count();
        }

        public override int saveChanges()
        {
            return context.SaveChanges();
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
    
        public override bool addLoanInformation(CDLoan loanInfo)
        {
            try
            {
                context.CDLoans.Add(loanInfo);

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
}
}
