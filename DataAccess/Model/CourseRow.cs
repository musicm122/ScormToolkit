using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class CourseRow
    {
        /// <summary>
        /// Course Identifier as specified at import-time
        /// </summary>
        public string CourseId
        {
            get; set;
        }

        /// <summary>
        /// Count of the number of versions for this course/package
        /// </summary>
        public int NumberOfVersions
        {
            get; set;
        }

        /// <summary>
        /// Count of the number of existing registrations there are for this
        /// course -- the number of instances that a user has taken this course.
        /// </summary>
        public int NumberOfRegistrations
        {
            get; set;
        }

        /// <summary>
        /// The title of this course
        /// </summary>
        public string Title
        {
            get; set;
        }
    }
}
