using Microsoft.AspNetCore.Mvc;
using lastoneapi.studu;
using lastoneapi.repo;

namespace lastoneapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryPattern _studentRepository;

        public StudentController(IRepositoryPattern studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var student = await _studentRepository.GetByIdAsync(Id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student Student)
        {

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _studentRepository.CreateAsync(Student);
            return CreatedAtAction(nameof(GetById), new { Id = created.Id }, created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Student Student)
        {

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _studentRepository.UpdateAsync(Id, Student);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var deleted = await _studentRepository.DeleteAsync(Id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}