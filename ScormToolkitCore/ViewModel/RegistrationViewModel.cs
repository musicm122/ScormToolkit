using HackerFerretCommon.Helpers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RusticiSoftware.HostedEngine.Client;
using ScormToolkitCore.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScormLogic.Model;
using ScormApi.Api;
using ScormApi.Helpers;

namespace ScormToolkitCore.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {

        public RegistrationViewModel()
        {
            InitSubscriptions();
        }

        void InitSubscriptions()
        {
            LoadRegistrations = ReactiveCommand.CreateAsyncObservable(
                this.WhenAnyValue(x => x.HasKey && !x.IsLoading && NetworkHelper.IsConnectedToInternet()),
                _ => FetchCoursesFromCacheAndServer());
        }

        [Reactive]
        public ReactiveList<RegistrationData> RegistrationsFromServer
        {
            get; set;
        }

        ReactiveCommand<List<RegistrationData>> LoadRegistrations { get; set; }

        private async Task<List<RegistrationData>> FetchRemoteRegistrations()
        {
            var retval = await RegistrationApi.GetAllRegistrationDataAsync().ConfigureAwait(false);
            return retval;
        }

        private IObservable<List<RegistrationData>> FetchCoursesFromCacheAndServer()
        {
            return DataStore.GetCachedAndFetchTask<List<RegistrationData>>("Registrations", fetchFunc: FetchRemoteRegistrations, condition: x => true);
        }


        public override bool SaveViewModel()
        {
            DataStore.Set("Registrations", RegistrationsFromServer);
            return true;
        }
    }
}
