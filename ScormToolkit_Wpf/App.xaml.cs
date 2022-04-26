using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ScormLogic.Model;
using ScormToolkit_Wpf.Pages.Settings;
using ScormToolkit_Wpf.Properties;

namespace ScormToolkit_Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppBootstrap.Init();

            ScormSettings settings = new ScormSettings();
            if (settings.HasSettingsPopulated)
            {
                HackerFerret.ScormHelper.Api.Common.InitScormConfig(appId: settings.ApplicationId, secretKey: settings.SecretKey);
            }
        }

        void LicensePrompt()
        {

        }
    }
}
