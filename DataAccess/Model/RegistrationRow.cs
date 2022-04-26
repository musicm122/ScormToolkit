using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Model
{
    public class RegistrationRow
    {
        public string RegistrationId
        {
            get; set;
        }

        /// <summary>
        /// Course Identifier as specified at import-time
        /// </summary>
        public string CourseId
        {
            get; set;
        }

        /// <summary>
        /// The title of this course
        /// </summary>
        public string CourseTitle
        {
            get; set;
        }


        /// <summary>
        /// The last version of the course that was launched
        /// </summary>
        public string LastCourseVersionLaunched
        {
            get; set;
        }



        /// <summary>
        /// Learner Identifier as specified at import-time
        /// </summary>
        public string LearnerId
        {
            get; set;
        }


        /// <summary>
        /// Learner First Name as specified at import-time
        /// </summary>
        public string LearnerFirstName
        {
            get; set;
        }


        /// <summary>
        /// Learner Last Name as specified at import-time
        /// </summary>
        public string LearnerLastName
        {
            get; set;
        }


        /// <summary>
        /// Learner Email as specified at import-time
        /// </summary>
        public string Email
        {
            get; set;
        }


        /// <summary>
        /// Date in which the registration was created
        /// </summary>
        public DateTime CreateDate
        {
            get; set;
        }


        /// <summary>
        /// Date in which the registration was first accessed
        /// </summary>
        public DateTime? FirstAccessDate
        {
            get; set;
        }


        /// <summary>
        /// Date in which the registration was last accessed
        /// </summary>
        public DateTime? LastAccessDate
        {
            get; set;
        }


        /// <summary>
        /// Date in which the registration was completed
        /// </summary>
        public DateTime? CompletedDate
        {
            get; set;
        }


        /// <summary>
        /// List of Verions/Instances available for this course
        /// </summary>
        public List<InstanceData> Instances
        {
            get; set;
        }
    }

    public class InstanceData
    {
        public string InstanceId
        {

            get; set;

        }


        /// <summary>
        /// Version of the Course this Instance refers to
        /// </summary>
        public string CourseVersion
        {

            get; set;
        }


        /// <summary>
        /// Date this instance/version of the course was updated
        /// </summary>
        public DateTime UpdateDate
        {

            get; set;
        }

    }

}
