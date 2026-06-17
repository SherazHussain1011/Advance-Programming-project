using CourseEnrollment.Core.Models;
using System.Collections.Generic;

namespace CourseEnrollment.Core.Contracts
{
    public interface IAnnouncementService
    {
        void Add(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(string id);
        Announcement GetById(string id);
        List<Announcement> GetAll();
        List<Announcement> GetActive();
    }
}
