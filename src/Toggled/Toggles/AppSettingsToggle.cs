﻿using System;
using System.Configuration;

namespace Toggled.Toggles
{
    public class AppSettingsToggle : IFeatureToggle
    {
        public const string SettingsPrefix = "Feature:";

        public bool? IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            string configName = SettingsPrefix + feature.Id;
            string configValue = ConfigurationManager.AppSettings[configName];

            bool result;
            if (bool.TryParse(configValue, out result))
            {
                return result;
            }

            return null;
        }
    }
}