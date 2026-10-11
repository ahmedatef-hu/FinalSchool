using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagement.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        [Required, Phone]
        public string ParentPhone { get; set; }
        [Required, Phone]
        public string EmergencyContact { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }

    }
}
