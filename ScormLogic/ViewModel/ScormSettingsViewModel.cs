using System;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ScormLogic.Model;
using ScormLogic.Base;
using PropertyChanged;

namespace ScormLogic.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [ImplementPropertyChanged]
    public class ScormSettingsViewModel : BaseViewModel, IDisposable
    {

        #region ctor
        /// <summary>
        /// Initializes a new instance of the ScormSettingsViewModel class.
        /// </summary>
        public ScormSettingsViewModel()
        {
            this.Settings.SettingsSaving += ScormSettings_SettingsSaving;
            SaveScormSettingsRelayCommand = new RelayCommand(Save, CanSave);
        }

        public void LoadNewSettings()
        {
            HackerFerret.ScormHelper.Api.Common.InitScormConfig(appId: Settings.ApplicationId,
                    secretKey: Settings.ApplicationId);
        }


        private void ScormSettings_SettingsSaving(object sender, CancelEventArgs e)
        {
            if (Settings.HasSettingsPopulated)
            {
                LoadNewSettings();
            }
        }
        #endregion ctor

        #region Fields
        //private ISaveSettings _saveSettings;

        #endregion

        #region Properties
        public string ApplicationId
        {
            get { return Settings.ApplicationId; }
            set
            {
                Settings.ApplicationId = value;
            }
        }

        public string SecretKey
        {
            get { return Settings.SecretKey; }
            set
            {
                Settings.SecretKey = value;
            }
        }


        public string ProductId
        {
            get { return Settings.ProductId; }
            set
            {
                Settings.ProductId = value;
                RaisePropertyChanged();
                SaveScormSettingsRelayCommand.RaiseCanExecuteChanged();
            }
        }

        public string License
        {
            get { return Settings.License; }
            set
            {
                Settings.License = value;
                RaisePropertyChanged();
                SaveScormSettingsRelayCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        public RelayCommand SaveScormSettingsRelayCommand { get; set; }

        bool CanSave()
        {
            return !String.IsNullOrWhiteSpace(ApplicationId) &&
                    !String.IsNullOrWhiteSpace(SecretKey);
        }

        void Save()
        {
            Settings.Save();
        }

        #endregion Commands        



        public void Dispose()
        {
            Settings.SettingsSaving -= ScormSettings_SettingsSaving;
            Settings = null;

        }
    }
}