﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CDLibraryDataLayer.ProviderConfiguration
{
    public class CDProviderConfiguration:ConfigurationSection
    {
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];

            }

        }

        [ConfigurationProperty("default", DefaultValue="CDProvider")]
        public String DefaultProviderName
        {
            get
            {
                return base["default"] as String;
            }
            set
            {
                base["default"] = value;
            }

        }
    }
}
