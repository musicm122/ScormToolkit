using System;
using System.Windows.Controls;
using System.Windows.Data;
using RusticiSoftware.HostedEngine.Client;
using ScormLogic.ViewModel;
using ScormToolkit_Wpf.Controls;
using ScormLogic.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace ScormToolkit_Wpf.Pages
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : UserControl
    {
        public static ViewModelLocator Locator { get; } = SimpleIoc.Default.GetInstance<ViewModelLocator>();
        CourseViewModel vm = Locator.Course;
        SearchBar SearchBar { get; set; }

        public Courses()
        {
            InitializeComponent();
            this.DataContext = vm;
            SearchBar = (SearchBar)FindName("CourseSearchBar");
            SearchBar.TextChangedEvent += OnFilter;

        }

        public void OnFilter(object sender, EventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView(vm.CourseCollection);

            if (String.IsNullOrWhiteSpace(SearchBar.FilterText.Text))
            {
                view.Filter = null;
            }
            else
            {
                view.Filter = x => ((CourseData)x).Title.IndexOf(SearchBar.FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
            }
        }
    }
}
