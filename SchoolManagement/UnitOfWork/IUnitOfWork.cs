using SchoolManagement.Data;
using SchoolManagement.Repos.Interfaces;

namespace SchoolManagement.UnitOfWork
{
    public interface IUnitOfWork
    {

        IStudentRepo studentRepo { get; }
        ICourseRepo courseRepo { get; }
        int save();
    }
}
