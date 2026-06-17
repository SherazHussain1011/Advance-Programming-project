using CourseEnrollment.Core.Models;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Contracts
{
    public interface IStudentService
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(string id);
        Student GetById(string id);
        List<Student> GetAll();
        List<Student> Search(string query);
    }
}
