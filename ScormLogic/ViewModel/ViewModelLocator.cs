/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ScormLogic"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using HackerFerretLogger;
using Microsoft.Practices.ServiceLocation;

namespace ScormLogic.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default );


            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CourseViewModel>();
            SimpleIoc.Default.Register<RegistrationViewModel>();
            SimpleIoc.Default.Register<ScormSettingsViewModel>();
            SimpleIoc.Default.Register<ILogger, ScormLogic.Log.Logger>();

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CourseViewModel Course
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CourseViewModel>();
            }
        }

        public RegistrationViewModel Registration
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegistrationViewModel>();
            }
        }

        public ScormSettingsViewModel ScormSettings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ScormSettingsViewModel>();
            }
        }


        public ILogger Logger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILogger>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}