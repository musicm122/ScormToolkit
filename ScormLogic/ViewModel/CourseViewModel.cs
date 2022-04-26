using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HackerFerret.ScormHelper.Api;
using HackerFerret.ScormHelper.Extensions;
using HackerFerretCommon.Helpers;
using HackerFerretLogger;
using PropertyChanged;
using RusticiSoftware.HostedEngine.Client;
using ScormLogic.Base;
using ScormLogic.Extension;
using ScormLogic.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace ScormLogic.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [ImplementPropertyChanged]
    public class CourseViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CourseViewModel class.
        /// </summary>
        #region ctor
        public CourseViewModel()
        {
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    var courseList = ScormApi.Helpers.Converter.ToCourseData(TestData.CourseListXml);
            //    this.CourseCollection = courseList.ToObservableCollection<CourseData>();
            //    this.ErrorMessage = "Test Error";
            //    this.Domain = "http://www.google.com";
            //}
            FetchCoursesRelayCommand = new RelayCommand(FetchCourses, CanPreformAction);
            UploadCourseCommand = new RelayCommand(UploadCourse, CanPreformAction);
            DeleteCourseDetailCommand = new RelayCommand(DeleteCourse, CanPreformActionOnSelection);
            CopyCourseDetailCommand = new RelayCommand(CopyCourseDetail, CanCopyCourseDetail);
            PreviewCourseRelayCommand = new RelayCommand(PreviewCourse, CanPreformActionOnSelection);
            try
            {
                if (CanPreformAction())
                {
                    FetchCourses();
                }

            }
            catch (Exception ex)
            {
                DialogHelper.ShowErrorDialog("Error Fetching Courses", "Could not fetch Course Data from scorm server. Please Verify that you have an internet connection and the correct AppId and Secret Values in the settings.");
                Debug.Write($"ScormLogic.ViewModel.CourseViewModel: ctor: Exception:{ex.Message}", "ScormToolkit:Course");
                this.Logger.Write($"ScormLogic.ViewModel.CourseViewModel: ctor: Exception:{ex.Message}", HackerFerretLogger.EventSeverity.Warning);
            }
        }



        #endregion

        #region Properties

        public string Domain { get; set; } = String.Empty;
        public CourseData SelectedCourse { get; set; }
        public int CourseCount
        {
            get
            {
                if (CourseCollection != null)
                {
                    return CourseCollection.Count();
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region Collections
        public ObservableCollection<CourseData> CourseCollection { get; set; }
        #endregion

        #region Commands

        public RelayCommand UploadCourseCommand { get; set; }
        public RelayCommand ViewCourseDetailCommand { get; set; }
        public RelayCommand CopyCourseDetailCommand { get; set; }
        public RelayCommand DeleteCourseDetailCommand { get; set; }
        public RelayCommand FetchCoursesRelayCommand { get; set; }
        public RelayCommand PreviewCourseRelayCommand { get; set; }


        #endregion Commands

        #region CommandMethods

        public async void UploadCourse()
        {

            var zipFiles = DialogHelper.GetZipFiles("Select Scorm Course(s)");
            if (zipFiles.Count == 0)
            {
                return;
            }

            await Task.Run(() =>
            {
                try
                {
                    zipFiles.ForEach(zip =>
                    {
                        CourseApi.UploadCourse(zip, Domain);
                    });
                    MessageBox.Show("Courses Uploaded Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    this.Logger.Write($"Course Upload Failed: {ex.Message}", HackerFerretLogger.EventSeverity.Warning);
                }
            });
        }

        public async void FetchCourses()
        {
            IsQuerying = true;
            try
            {
                //var temp = CourseApi.GetCourseDetailList().OrderBy(x => x.Title);
                var temp = await CourseApi.GetCourseDetailListAsync();

                if (temp == null)
                {
                    ErrorMessage = "There was an issue when attempting to fetch courses from your scorm cloud. Verify that your Key and Application Id are valid.";
                }
                else if (!temp.Any())
                {
                    ErrorMessage = "There are no available courses to display at this time.";
                }

                CourseCollection = temp.OrderBy(x => x.Title).ToObservableCollection();
                RaisePropertyChanged("CourseCollection");
                RaisePropertyChanged("CourseCount");
                IsQuerying = false;
            }
            catch (WebException ex)
            {
                ErrorMessage = "There was an issue when attempting to connect to the internet.\r\n";
                ErrorMessage += ex.Message;
                IsQuerying = false;
                Logger.Write(ErrorMessage, EventSeverity.Warning);
                //todo:add failure logging;
            }
            catch (Exception ex)
            {
                ErrorMessage = "There was an issue when attempting to fetch courses from your scorm cloud. Verify that your Key and Application Id are valid.\r\n";
                ErrorMessage += ex.Message;
                IsQuerying = false;
                Logger.Write(ErrorMessage, EventSeverity.Warning);

                //todo:add failure logging;
            }
        }

        private void CopyCourseDetail()
        {
            Debug.Write("Copy Course Detail");
            OsHelper.CopyToClipboard(SelectedCourse.ToFormattedString());
        }

        private async void DeleteCourse()
        {
            Debug.Write("Delete Course");
            //var result = await CourseApi.DeleteCourseAsync("");
            var deleteConfirmed = DialogHelper.ShowConfirmationDialog("Delete Course?", $"Delete course {SelectedCourse.Title}");
            if (deleteConfirmed)
            {
                try
                {
                    await CourseApi.DeleteCourseAsync(SelectedCourse.CourseId);
                }
                catch (Exception ex)
                {
                    DialogHelper.ShowErrorDialog($"An error occured when attempting to delete the course {SelectedCourse.Title}?\r\n {ex.Message}", "Error occured when attempting to delete");
                    this.Logger.Write($"Delete Course Failed: {ex.Message}", HackerFerretLogger.EventSeverity.Warning);
                }

            }
        }

        private void PreviewCourse()
        {
            var previewUrl = HackerFerret.ScormHelper.Api.CourseApi.GetCoursePreviewUrl(SelectedCourse.CourseId);
            Process.Start(previewUrl);
        }

        #endregion CommandMethods

        #region ConditionMethods

        private bool CanCopyCourseDetail()
        {
            Debug.Write("Can Copy Course Detail");
            return (SelectedCourse != null);
        }

        public bool CanPreformAction()
        {
            return Settings.HasSettingsPopulated;
        }

        public bool CanPreformActionOnSelection()
        {
            return (SelectedCourse != null) && Settings.HasSettingsPopulated;
        }

        #endregion ConditionMethods
    }
}