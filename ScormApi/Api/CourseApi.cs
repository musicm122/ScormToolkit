using System.Collections.Generic;
using System.Linq;
using RusticiSoftware.HostedEngine.Client;
using System.Threading.Tasks;
using HackerFerretLogger;
using System;
using System.Diagnostics;

namespace ScormApi.Api
{
    public static class CourseApi
    {

        public static CourseData GetCourseDetails(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                CourseData retval = ScormCloud.CourseService.GetCourseList().FirstOrDefault(x => x.CourseId == courseSeq);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }

        }

        public static async Task<CourseData> GetCourseDetailsAsync(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
                    ScormCloud.CourseService.GetCourseList().FirstOrDefault(x => x.CourseId == courseSeq)
                );
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }

        }

        public static List<CourseData> GetCourseDetailList()
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.CourseService.GetCourseList();
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }

        }

        public static async Task<List<CourseData>> GetCourseDetailListAsync()
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
               ScormCloud.CourseService.GetCourseList()
           );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }


        public static string GetCoursePreviewUrl(string courseSeq, string redirectOnExitUrl = "")
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                string retval = ScormCloud.CourseService.GetPreviewUrl(courseSeq, redirectOnExitUrl);
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }

        }


        public static async Task<string> GetCoursePreviewUrlAsync(string courseSeq, string redirectOnExitUrl = "")
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
                    ScormCloud.CourseService.GetPreviewUrl(courseSeq, redirectOnExitUrl)
                );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }

        }

        public static string GetCourseTitle(string courseId)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var course = GetCourseDetails(courseId);
                var retval = course.Title;
                return retval;

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }


        public static async Task<string> GetCourseTitleAsync(string courseId)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
                    GetCourseDetails(courseId).Title
                );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }


        }


        public static void DeleteCourse(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                ScormCloud.CourseService.DeleteCourse(courseSeq);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }


        public static async Task DeleteCourseAsync(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                await Task.Run(() =>
                    ScormCloud.CourseService.DeleteCourse(courseSeq)
                );

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }

        public static bool CourseExists(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = ScormCloud.CourseService.Exists(courseSeq);
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }

        public static async Task<bool> CourseExistsAsync(string courseSeq)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
                    ScormCloud.CourseService.Exists(courseSeq)
                );
                return retval;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }
        }


        public static bool UploadCourse(string zipPath, string domain)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var result = ScormCloud.UploadService.UploadFile(zipPath, domain);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "ScormApi.Api.CourseApi");
                throw;
            }


        }


        public static async Task<bool> UploadCourseAsync(string zipPath, string domain)
        {
            global::ScormApi.Api.Common.InitScormConfig();
            try
            {
                var retval = await Task.Run(() =>
                {
                    var result = ScormCloud.UploadService.UploadFile(zipPath, domain);
                    return String.IsNullOrWhiteSpace(result.location);
                });
                return retval;
            }
            catch (System.Exception)
            {
                return false;

            }


        }
    }
}