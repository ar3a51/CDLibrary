using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;
using System.Collections.Generic;

using CDLibrary.BL;
using CDLibrary.BL.structs;
using CDLibrary.Common;

//using CDLibrary.Common.structs;

namespace CDLibraryTest
{
    [TestClass]
    public class ProspectRepTest
    {
        [TestMethod]
        public void insertProspects()
        {
            int numOfProspects = 4;

            Prospect[] plist = new Prospect[numOfProspects];

            for (int i =0; i<numOfProspects;i++)
            {
                plist[i] = new Prospect { Firstname = "fname" + i+1,
                                      Lastname = "lname" + i + 1,
                                      AddressLine1 = "Address" + i + 1,
                                      AddressLine2 = "Address2" + i + 1,
                                      Suburb = "Suburb" + i+ 1,
                                      state = "state" + i+1,
                                      phoneNumber="0412"+ (i+1).ToString() + (i+1).ToString(),
                                     insertBy = "me",
                                     emailAddress ="email" + (i+1).ToString(),
                                     insertDate = DateTime.Now,
                                     updateDate = DateTime.Now};
                                    

            }

            foreach(Prospect p in plist )
            {
                Assert.AreNotEqual(0, ProspectRepository.addNewProspect(p));

            }

        }

        [TestMethod]
        public void getAllCDLoaned()
        {
            List<StructCDProspect> result = ProspectRepository.GetAllCDFromProspect(15, 1, 1, "me") as List<StructCDProspect>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            foreach(StructCDProspect cdProspect in result)
            {
                Debug.WriteLine(cdProspect.cd.Title);
                Debug.WriteLine(cdProspect.cdLoanCollection[0].endLoanDate);

            }
        }

        [TestMethod]
        public void loanACD()
        {
            Assert.IsTrue(ProspectRepository.LoanCD(15, 24, 3, DateTime.Parse("2014-06-29"),"me"));

        }

    }


    [TestClass]
    public class BusinessLayerTest1
    {
       
        [TestMethod]
        public void InsertCd()
        {
            try
            {
                CD[] cdTest = new CD[4];

                cdTest[0] = new CD{ Artist= "Artis5", insertBy="me", insertDate=DateTime.Now,updateDate=DateTime.Now, quantity= 8, Title="Title5"};
                cdTest[1] = new CD { Artist = "Artist6", insertBy = "me", insertDate = DateTime.Today,updateDate=DateTime.Now, quantity = 8, Title = "title6" };
                cdTest[2] = new CD { Artist = "Artist7", insertBy = "me", insertDate = DateTime.Today,updateDate=DateTime.Now, quantity = 8, Title = "title7" };
                cdTest[3] = new CD { Artist = "Artist8", insertBy = "me", insertDate = DateTime.Today,updateDate=DateTime.Now, quantity = 8, Title = "Title8" };

                foreach(CD cd in cdTest)
                {
                    Assert.AreNotEqual(0,CDRepository.AddNewCD(cd));
                    
                }
            
                

                
                 
            }
            catch (Exception ex)
            {
                throw ex;
              

            }

            
        }

        [TestMethod]
        public void updateCD()
        {
            CD cd = CDRepository.FindCDById(24,"me");
            cd.updateDate = DateTime.Now;
           
            cd.quantity = 8;

            Assert.IsTrue(CDRepository.updateCD(cd));
            
            

        }

        [TestMethod]
        public void findCDByName()
        {
            List<CD> list = CDRepository.FindCDByName("Title7", "me") as List<CD>;
            Assert.IsNotNull(list);
            Assert.AreNotEqual(0, list.Count);
            Assert.AreEqual(1, list.Count);
            if (list.Count > 0)
            { 
                foreach (CD cd in list)
                {
                    Debug.WriteLine(cd.Title);
                    Debug.WriteLine(cd.Artist);
                    Debug.WriteLine(cd.quantity);
                }
            }
        }

        
        //[TestMethod]
        /*public void retrieveCDloan()
        {
               List<Prospect> result = CDProviderManager.Default.findCDLoanById(10, 10, 1) as List<Prospect>;

               StructProspectLoanCD structP = new StructProspectLoanCD();
               



            foreach(Prospect p in result)
            {
                structP.prospect = p;
                structP.CDLoanCollection =  new CDLoan[p.cdLoanCollection.Count];
                p.cdLoanCollection.CopyTo(structP.CDLoanCollection, 0);
                Debug.WriteLine(p.Firstname);

                foreach(CDLoan l in structP.CDLoanCollection)
                {
                    Debug.WriteLine(l.starLoanDate);
                    Debug.WriteLine(l.endLoanDate);

                }

            }
                //Debug.Write(p.cdLoanCollection.ToString());

            
        }*/
    }
}
