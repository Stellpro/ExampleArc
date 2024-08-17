using ExamleArc.Db.Repo;
using ExampleArc.Application.Services;
using ExampleArc.Contracts;
using ExampleArc.Core.Abstraction;
using ExampleArc.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExampleArc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: StudentController
        [HttpGet]
        public async Task<ActionResult<List<StudentResponce>>> GetStudents()
        {
            var studentlist = await _studentService.GetAll();
            var response = studentlist.ToList();
            return Ok(response);
        }


        // POST: StudentController/Create
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] StudentRequest request)
        {
            var item = new Student
            {
                Name = request.request.Name,
                FirstName = request.request.FirstName,
                LastName = request.request.LastName,
                Age = request.request.Age,
            };
            var result = await _studentService.Create(item);
            return Ok(result.StudentId);
        }

        // POST: StudentController/Update/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> Update(int id, [FromBody] StudentRequest request)
        {
            var item = new Student
            {
                Name = request.request.Name,
                FirstName = request.request.FirstName,
                LastName = request.request.LastName,
                Age = request.request.Age,
            };// можно сделать отдельным приватным методом заполнение
            var result = await _studentService.Update(item,id);
           
                return Ok(result.StudentId);
           
        }

        // GET: StudentController/Delete/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await _studentService.Delete(id));
        }

    }
}
