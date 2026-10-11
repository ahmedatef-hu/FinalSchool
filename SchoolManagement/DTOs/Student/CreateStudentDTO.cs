using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.DTOs.Student
{
    public class CreateStudentDTO
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
