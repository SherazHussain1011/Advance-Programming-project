using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Contracts
{
    public interface ICourseService
    {
        Course Add(Course course);
        bool Update(Course course);
        bool Delete(string id);
        Course GetById(string id);
        List<Course> GetAll();
        List<Course> Search(string text, DepartmentEnum? department, CourseStatusEnum? status);
    }
}
