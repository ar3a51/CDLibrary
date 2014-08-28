using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Provider;

using CDLibraryDataLayer.Abstracts;

namespace CDLibraryDataLayer
{
    public class ProspectCollection:ProviderCollection
    {

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("Provider cannot be null");

            base.Add(provider);
        }

        new public ProspectProviderBase this[String name]
        {
            get { return (ProspectProviderBase)base[name]; }

        }



    }
}
