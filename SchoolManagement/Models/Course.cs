using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SchoolManagement.Models
{
    public class Course
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        [Required, Range(1, 6)]
        public int CreditHours { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
