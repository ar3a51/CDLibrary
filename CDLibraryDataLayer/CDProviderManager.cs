using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;

using CDLibraryDataLayer.Abstracts;
using CDLibraryDataLayer.ProviderConfiguration;

namespace CDLibraryDataLayer
{
   public class CDProviderManager
    {
       static CDProviderManager()
        {
            Initialize();
        }

        private static CDproviderbase _default;
        /// <summary>
        /// Returns the default configured data provider
        /// </summary>
        public static CDproviderbase Default
        {
            get { return _default; }
        }

        private static CDCollection _providerCollection;
        /// <summary>
        /// .Returns the provider collection
        /// </summary>
        public static CDCollection Providers
        {
            get { return _providerCollection; }
        }

        

        /// <summary>
        /// Reads the configuration related to the set of configured 
        /// providers and sets the default and collection of providers and settings.
        /// </summary>
        private static void Initialize()
        {
            CDProviderConfiguration configSection = (CDProviderConfiguration)ConfigurationManager.GetSection("CDProviders");
            if (configSection == null)
                throw new ConfigurationErrorsException("Data provider section is not set.");

            _providerCollection = new CDCollection();
            ProvidersHelper.InstantiateProviders(configSection.Providers, _providerCollection, typeof(CDproviderbase));

            Providers.SetReadOnly();

            _default = Providers[configSection.DefaultProviderName];
        }
    }
}
