using SchoolManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.DTOs.Course
{
    public class CreateCourseDTO
    {
        public string Title { get; set; }
        [Required, Range(1, 6)]
        public int CreditHours { get; set; }
        public int TeacherId { get; set; }
    }
}
