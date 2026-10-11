using SchoolManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.DTOs.Course
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreditHours { get; set; }
        public string TeacherName { get; set; }
    }
}
