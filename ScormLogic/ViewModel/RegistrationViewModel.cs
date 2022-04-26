using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HackerFerret.ScormHelper.Api;
using HackerFerret.ScormHelper.Extensions;
using HackerFerretCommon.Helpers;
using RusticiSoftware.HostedEngine.Client;
using ScormLogic.Extension;
using ScormLogic.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ScormLogic.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        #region ctor
        public RegistrationViewModel()
        {
            //FetchRegistrations.Execute(null);
            //RegistrationCollection = RegistrationApi.GetAllRegistrationDataAsync().Result.ToObservableCollection<RegistrationData>();
            RegistrationCollection = RegistrationApi.GetAllRegistrationData().ToObservableCollection<RegistrationData>();

        }
        #endregion ctor

        #region Collections
        public ObservableCollection<RegistrationData> RegistrationCollection { get; set; }
        #endregion

        #region Properties
        private ScormSettings _settings = new ScormSettings();
        private string _searchFilter = String.Empty;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;
                RaisePropertyChanged();
            }
        }

        private RegistrationData _selectedRegistration;
        public RegistrationData SelectedRegistration
        {
            get
            {
                return _selectedRegistration;
            }
            set
            {
                _selectedRegistration = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand FetchRegistrations
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var result = await RegistrationApi.GetAllRegistrationDataAsync();
                    RegistrationCollection = result.ToObservableCollection<RegistrationData>();
                    RaisePropertyChanged("RegistrationCollection");
                }, CanFetchRegistrations);
            }
        }
        public RelayCommand ViewDetailedRegistration
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DialogHelper.ShowInfoDialog("Registation Info", SelectedRegistration.ToFormattedString());
                }, CanAccessContextMenu);
            }
        }
        public RelayCommand ResetRegistration
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (DialogHelper.ShowConfirmationDialog(body: $"Are you sure you want to Reset the progress of {SelectedRegistration.LearnerFirstName} {SelectedRegistration.LearnerLastName} for course: {SelectedRegistration.CourseTitle}"))
                    {
                        RegistrationApi.ResetRegistration(SelectedRegistration.RegistrationId);
                    }
                }, CanAccessContextMenu);
            }
        }
        public RelayCommand CopyRegistration
        {
            get
            {
                return new RelayCommand(() =>
                {
                    OsHelper.CopyToClipboard(SelectedRegistration.ToFormattedString());
                    DialogHelper.ShowInfoDialog(body: "Registration Copied");
                }, CanAccessContextMenu);
            }
        }
        public RelayCommand DeleteRegistration
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (DialogHelper.ShowConfirmationDialog(body: $"Are you sure you want to Delete the registration {SelectedRegistration.LearnerFirstName} {SelectedRegistration.LearnerLastName} for course: {SelectedRegistration.CourseTitle}"))
                    {
                        RegistrationApi.DeleteRegistration(SelectedRegistration.RegistrationId);
                    }
                }, CanAccessContextMenu);
            }
        }
        public RelayCommand FilterResults { get; set; }

        public bool CanFetchRegistrations()
        {
            return _settings.HasSettingsPopulated && NetworkHelper.IsConnectedToInternet();
        }

        public bool CanAccessContextMenu()
        {
            return (SelectedRegistration != null);
        }
        #endregion
    }


}