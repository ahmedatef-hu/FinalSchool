using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DTOs.Course;
using SchoolManagement.Models;
using SchoolManagement.UnitOfWork;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class coursesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public coursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = await unitOfWork.courseRepo.GetAll();
            var coursedto = mapper.Map<List<GetCourseDTO>>(c);
            return Ok(coursedto);
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDTO course)
        {
            var coursedto = mapper.Map<Course>(course);
            unitOfWork.courseRepo.Create(coursedto);
            unitOfWork.save();
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Update(GetCourseDTO course)
        {
            var coursedto = mapper.Map<Course>(course);
            unitOfWork.courseRepo.Update(coursedto);
            unitOfWork.save();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var c = await unitOfWork.courseRepo.GetById(id);
            unitOfWork.courseRepo.Delete(c);
            unitOfWork.save();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> search(string title)
        {
            var courses = await unitOfWork.courseRepo.Search(title);
            var dto = mapper.Map<List<GetCourseDTO>>(courses);
            return Ok(dto);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> filter(int teacherId, int hours)
        {
            var courses = await unitOfWork.courseRepo.Filter(teacherId, hours);
            var dto = mapper.Map<List<GetCourseDTO>>(courses);
            return Ok(dto);
        }
    }
}
