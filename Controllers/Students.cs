using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;

namespace TestingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        private readonly AppDbContext _db;

        public Students(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _db.Students.ToList();
            return Ok(students);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest("Некорректный id");

            var student = _db.Students
                             .Include(s => s.User)
                             .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }


        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student.User == null)
                return BadRequest("User должен быть указан");

            if (_db.Students.Any(s => s.User.Email == student.User.Email))
                return Conflict("Такая почта уже есть");

            _db.Students.Add(student);
            _db.SaveChanges();

            return Created($"/api/students/{student.Id}", student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent([FromBody] Student student, [FromRoute] int id)
        {
            if (id != student.Id)
                return BadRequest("id в пути и в теле запроса не совпадают");

            if (id <= 0)
                return BadRequest("Некорректный id");

            var exists = _db.Students.Any(s => s.Id == id);
            if (!exists)
                return NotFound();

            var emailExists = _db.Students.FirstOrDefault(s => s.User.Email == student.User.Email && s.Id != id);
            if (emailExists is not null)
                return Conflict("Такой email уже используется");

            _db.Students.Update(student);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _db.Students.Find(id);
            if (student is null)
                return NotFound();

            _db.Students.Remove(student);
            _db.SaveChanges();

            return NoContent();
        }








    }

}
