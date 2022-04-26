using Akavache;
using HackerFerretCommon.Helpers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RusticiSoftware.HostedEngine.Client;
using ScormApi.Api;
using ScormToolkitCore.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScormToolkitCore.ViewModel
{
    // Define other methods and classes here
    public class CourseViewModel : BaseViewModel
    {

        [Reactive]
        public ReactiveList<CourseData> CoursesFromServer
        {
            get; set;
        }

        ReactiveCommand<List<CourseData>> LoadCourses { get; set; }

        public CourseViewModel()
        {
            InitSubscriptions();
        }

        void InitSubscriptions()
        {
            LoadCourses = ReactiveCommand.CreateAsyncObservable(
                this.WhenAnyValue(x => x.HasKey && !x.IsLoading && NetworkHelper.IsConnectedToInternet()),
                _ => FetchCoursesFromCacheAndServer());

            LoadCourses.Subscribe(courses =>
            {
                courses.Clear();
                foreach (CourseData c in courses)
                {
                    CoursesFromServer.Add(c);
                }
            });
            LoadCourses.ThrownExceptions.Subscribe(ex => UserError.Throw("Could not get Course Data from server"));
            LoadCourses.ExecuteAsyncTask();
        }

        private async Task<List<CourseData>> FetchRemoteCourses()
        {
            var courses = await CourseApi.GetCourseDetailListAsync().ConfigureAwait(false);
            return courses;
        }

        private IObservable<List<CourseData>> FetchCoursesFromCacheAndServer()
        {
            return DataStore.GetCachedAndFetchTask<List<CourseData>>("Courses", fetchFunc: FetchRemoteCourses, condition: x => true);
        }

        public override bool SaveViewModel()
        {
            DataStore.Set("Courses", CoursesFromServer);
            return true;
        }
    }
}
