using SchoolManagement.Data;
using SchoolManagement.Repos.Interfaces;

namespace SchoolManagement.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IStudentRepo studentRepo { get; }

        public ICourseRepo courseRepo { get; }
        public UnitOfWork(AppDbContext context, IStudentRepo studentRepo, ICourseRepo courseRepo)
        {
            this.context = context;
            this.studentRepo = studentRepo;
            this.courseRepo = courseRepo;
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
