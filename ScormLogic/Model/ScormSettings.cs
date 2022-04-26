using System;
using System.Configuration;

namespace ScormLogic.Model
{
    public class ScormSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        public string ApplicationId
        {
            get { return (string)this["ApplicationId"]; }
            set { this["ApplicationId"] = value; }
        }

        [UserScopedSetting]
        public string SecretKey
        {
            get { return (string)this["SecretKey"]; }
            set { this["SecretKey"] = value; }
        }


        [UserScopedSetting]
        public string License
        {
            get { return (string)this["License"]; }
            set { this["License"] = value; }
        }

        [UserScopedSetting]
        public string ProductId
        {
            get { return (string)this["ProductId"]; }
            set { this["ProductId"] = value; }
        }

        public bool HasSettingsPopulated
            => !String.IsNullOrWhiteSpace(SecretKey) && !String.IsNullOrWhiteSpace(ApplicationId);

    }
}