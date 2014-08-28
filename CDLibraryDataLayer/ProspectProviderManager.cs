using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;

using CDLibraryDataLayer.Abstracts;
using CDLibraryDataLayer.ProviderConfiguration;

namespace CDLibraryDataLayer
{
   public class ProspectProviderManager
    {

        static ProspectProviderManager()
        {
            Initialize();
        }

        private static ProspectProviderBase _default;
        /// <summary>
        /// Returns the default configured data provider
        /// </summary>
        public static ProspectProviderBase Default
        {
            get { return _default; }
        }

        private static ProspectCollection _providerCollection;
        /// <summary>
        /// .Returns the provider collection
        /// </summary>
        public static ProspectCollection Providers
        {
            get { return _providerCollection; }
        }

        

        /// <summary>
        /// Reads the configuration related to the set of configured 
        /// providers and sets the default and collection of providers and settings.
        /// </summary>
        private static void Initialize()
        {
            ProspectProviderConfiguration configSection = (ProspectProviderConfiguration)ConfigurationManager.GetSection("ProspectProviders");
            if (configSection == null)
                throw new ConfigurationErrorsException("Data provider section is not set.");

            _providerCollection = new ProspectCollection();
            ProvidersHelper.InstantiateProviders(configSection.Providers, _providerCollection, typeof(ProspectProviderBase));

            Providers.SetReadOnly();

            _default = Providers[configSection.DefaultProviderName];
        }
    }
   }

