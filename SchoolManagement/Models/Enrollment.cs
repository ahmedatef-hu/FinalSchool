using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Range(0, 100)]
        public decimal? Grade { get; set; }
    }
}
