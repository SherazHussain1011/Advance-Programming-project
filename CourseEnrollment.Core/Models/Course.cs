using CourseEnrollment.Core.Utilities;

namespace CourseEnrollment.Core.Models
{
    public class Course
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public DepartmentEnum Department { get; set; }
        public int Credits { get; set; }
        public int AvailableSeats { get; set; }
        public CourseStatusEnum Status { get; set; }

        public Course() { }
    }
}
