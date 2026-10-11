using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.DTOs.Student
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
