using SchoolManagement.Models;

namespace SchoolManagement.Repos.Interfaces
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        Task<List<Student>> Search(string Name);
        Task<List<Student>> Filter(string Gender);
        Task<List<Student>> Getpagination(int PageNumber, int PageSize);

    }
}
