using EFProject3.Data;
using EFProject3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFProject3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult StudentList()
        {
            var result = _context.Student.ToList();
            if (result == null)
            {
                return BadRequest("Not foundList");
            }
            return Ok(result);
        }

        [HttpPost("create")]

        public IActionResult StudentCreate([FromBody] Student student)
        {
           _context.Student.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpGet("details/{id}")]

        public IActionResult StudentDetails(int id)
        {
            var result = _context.Student.FirstOrDefault(m => m.Id == id);
            if(result==null)
            {
                return BadRequest("Student Not Found!!");
            }
            return Ok(result);
        }

        [HttpGet("delete/{id}")]

        public IActionResult StudentDelete(int id)
        {
            var result = _context.Student.FirstOrDefault(m => m.Id == id);
            if(result==null)
            {
                return BadRequest("Student Not Found!!");
            }
            _context.Student.Remove(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpPut("update/{id}")]

        public IActionResult StudentUpdate(int id, [FromBody] Student student)
        {
            var result = _context.Student.FirstOrDefault(m => m.Id == id);
            if(result==null)
            {
                return BadRequest("Student Not Found!!");
            }
            result.Name = student.Name;
            result.Address = student.Address;
            result.Class = student.Class;
            result.Email = student.Email;
            result.Gender = student.Gender;
            _context.Student.Update(result);
            _context.SaveChanges();
            return Ok(result);
        }


    }
}
