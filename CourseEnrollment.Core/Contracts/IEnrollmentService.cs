using CourseEnrollment.Core.Models;
using CourseEnrollment.Core.Utilities;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Contracts
{
    public interface IEnrollmentService
    {
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(string id);
        Enrollment GetById(string id);
        List<Enrollment> GetAll();
        List<Enrollment> GetByStudentId(string studentId);
        List<Enrollment> GetByStatus(EnrollmentStatusEnum status);
    }
}
