using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repos.Interfaces;

namespace SchoolManagement.Repos.Impelementation
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> Filter(string Gender)
        {
            return context.Students.Where(s => s.Gender == Gender).ToList();
        }

        public async Task<List<Student>> Getpagination(int PageNumber, int PageSize)
        {
            var result = context.Students
                .Skip((PageNumber - 1) * 10)
                .Take(PageSize).ToList();
            return result;
        }

        public async Task<List<Student>> Search(string Name)
        {
            return await context.Students.Where(c => c.FullName.Contains(Name)).ToListAsync();
        }
    }
}
