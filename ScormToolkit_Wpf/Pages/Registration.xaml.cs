using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RusticiSoftware.HostedEngine.Client;
using ScormLogic.ViewModel;
using FirstFloor.ModernUI.Windows.Controls;

namespace ScormToolkit_Wpf.Pages
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void OnFilter(object sender, EventArgs e)
        {
            var vm = (RegistrationViewModel)DataContext;
            var view = CollectionViewSource.GetDefaultView(vm.RegistrationCollection);

            if (String.IsNullOrWhiteSpace(FilterText.Text))
            {
                view.Filter = null;
            }
            else
            {
                if (FilterField.SelectedValue == null)
                {
                    FilterField.SelectedIndex = 1;
                }

                var val = FilterField.SelectedValue.ToString();


                switch (val)
                {
                    case "RegistrationId":
                        view.Filter = x => ((RegistrationData)x).RegistrationId.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "CourseId":
                        view.Filter = x => ((RegistrationData)x).CourseId.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "CourseTitle":
                        view.Filter = x => ((RegistrationData)x).CourseTitle.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "LastCourseVersionLaunched":
                        view.Filter = x => ((RegistrationData)x).LastCourseVersionLaunched.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "LearnerId":
                        view.Filter = x => ((RegistrationData)x).LastCourseVersionLaunched.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "LearnerFirstName":
                        view.Filter = x => ((RegistrationData)x).LearnerFirstName.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "LearnerLastName":
                        view.Filter = x => ((RegistrationData)x).LearnerLastName.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "Email":
                        view.Filter = x => ((RegistrationData)x).Email.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "CreateDate":
                        view.Filter = x => ((RegistrationData)x).CreateDate.ToString(CultureInfo.CurrentCulture).IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "FirstAccessDate":
                        view.Filter = x => ((RegistrationData)x).FirstAccessDate.ToString().IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "LastAccessDate":
                        view.Filter = x => ((RegistrationData)x).LastAccessDate.ToString().IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    case "CompletedDate":
                        view.Filter = x => ((RegistrationData)x).CompletedDate.ToString().IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                    default:
                        view.Filter = x => ((RegistrationData)x).CourseTitle.IndexOf(FilterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
                        break;
                }


            }

        }
    }
}
