using SchoolManagement.Models;

namespace SchoolManagement.Repos.Interfaces
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        Task<List<Course>> Search(string Title);
        Task<List<Course>> Filter(int teacherId, int CreditHours);
    }
}
