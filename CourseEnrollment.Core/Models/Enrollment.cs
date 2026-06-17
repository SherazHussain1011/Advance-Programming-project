using CourseEnrollment.Core.Utilities;
using System;

namespace CourseEnrollment.Core.Models
{
    public class Enrollment
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Grade { get; set; }
        public EnrollmentStatusEnum Status { get; set; }

        public Enrollment()
        {
            EnrollDate = DateTime.Now;
            Status = EnrollmentStatusEnum.Enrolled;
        }
    }
}
