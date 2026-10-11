using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repos.Interfaces;

namespace SchoolManagement.Repos.Impelementation
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        public CourseRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Course>> Filter(int teacherId, int CreditHours)
        {
            var result = context.Courses.Where(t => t.TeacherId == teacherId && t.CreditHours <= CreditHours).ToList();
            return result;
        }

        public async Task<List<Course>> Search(string Title)
        {
            return context.Courses.Where(t => t.Title.Contains(Title)).ToList();
        }
    }
}
