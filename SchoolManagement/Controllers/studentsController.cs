using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DTOs.Student;
using SchoolManagement.Models;
using SchoolManagement.UnitOfWork;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public studentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create(CreateStudentDTO dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                Gender = dto.Gender,
                Phone = dto.Phone,
            };
            unitOfWork.studentRepo.Create(student);
            unitOfWork.save();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await unitOfWork.studentRepo.GetAll();
            var result = students.Select(x => new GetStudentDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Email = x.Email,
                Gender = x.Gender,
                Phone = x.Phone,
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await unitOfWork.studentRepo.GetById(id);
            var result = new GetStudentDTO
            {
                FullName = s.FullName,
                BirthDate = s.BirthDate,
                Email = s.Email,
                Gender = s.Gender,
                Phone = s.Phone,
                Id = s.Id,
            };
            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, CreateStudentDTO dto)
        {
            var s = await unitOfWork.studentRepo.GetById(id);
            s.FullName = dto.FullName;
            s.BirthDate = dto.BirthDate;
            s.Email = dto.Email;
            s.Phone = dto.Phone;
            unitOfWork.studentRepo.Update(s);
            unitOfWork.save();
            return Ok(dto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string Name)
        {
            var students = await unitOfWork.studentRepo.Search(Name);
            var result = students.Select(x => new GetStudentDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Email = x.Email,
                Gender = x.Gender,
                Phone = x.Phone,
            });
            return Ok(result);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> filter(string gender)
        {
            var students = await unitOfWork.studentRepo.Filter(gender);
            var result = students.Select(x => new GetStudentDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                Email = x.Email,
                Gender = x.Gender,
                Phone = x.Phone,
            });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await unitOfWork.studentRepo.GetById(id);
            unitOfWork.studentRepo.Delete(s);
            unitOfWork.save();
            return NoContent();
        }
    }
}
