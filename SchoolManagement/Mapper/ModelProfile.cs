using AutoMapper;
using SchoolManagement.DTOs.Course;
using SchoolManagement.DTOs.Student;
using SchoolManagement.Models;

namespace SchoolManagement.Mapper
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Student, GetStudentDTO>();
            CreateMap<CreateStudentDTO, Student>();


            CreateMap<Course, GetCourseDTO>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FullName));
            CreateMap<CreateCourseDTO, Course>();
        }
    }
}
