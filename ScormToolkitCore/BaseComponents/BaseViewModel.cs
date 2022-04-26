using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ScormToolkitCore.Contracts;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScormToolkitCore.BaseComponents
{
    public abstract class BaseViewModel : ReactiveObject
    {
        protected ILogger Logger;
        protected IPersistantDataStore DataStore;
        public IScreen HostScreen { get; private set; }

        public BaseViewModel(IScreen screen)
        {
            HostScreen = screen;
            DataStore.Get<string>("SelectedApplicationKey")
                .Subscribe(x => HasKey = !String.IsNullOrWhiteSpace(x));

        }
        [Reactive]
        public bool IsLoading
        {
            get; set;

        }

        [Reactive]
        public bool HasKey
        {
            get; set;
        }



        public abstract bool SaveViewModel();
    }
}
