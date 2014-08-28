using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Provider;

using CDLibraryDataLayer.Abstracts;

namespace CDLibraryDataLayer
{
   public class CDCollection : ProviderCollection
    {
       

       new public CDproviderbase this[String name]
       {

           get { return (CDproviderbase)base[name]; }
       }

       
    }
}
