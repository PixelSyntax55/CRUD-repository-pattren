using AutoMapper;
using lastoneapi.Data;
using lastoneapi.School.Controllers.DTOS;
using lastoneapi.School.Repositories;
using lastoneapi.School;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lastoneapi.studu;



namespace lastoneapi.School.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryPattern _RepositoryPattern;
        private readonly IMapper _mapper;

        public StudentController(IRepositoryPattern RepositoryPattern, IMapper mapper)
        {

            _RepositoryPattern = RepositoryPattern;
            _mapper = mapper;
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var student = await _RepositoryPattern.GetAllAsync();

            var DTO = _mapper.Map<List<ResponceStudentDto>>(student);
            
            return Ok(DTO);  
            
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            var student = await _RepositoryPattern.GetByIdAsync(Id);

            if (student == null) return NotFound();

            var DTO = _mapper.Map<ResponceStudentDto>(student);

            return Ok(DTO);

        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestStudentDto Postrequest)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

           var RequestStudent = _mapper.Map<Student>(Postrequest);

           var StudentCreated = await _RepositoryPattern.CreateAsync(RequestStudent);
           
           var DTO = _mapper.Map<ResponceStudentDto>(StudentCreated);

           return CreatedAtAction(nameof(GetById), new { Id = DTO.Id }, DTO);

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id,ResponceStudentDto PutRequest)
        {

            var StudentRequest = _mapper.Map<Student>(PutRequest);

            var updatedStudent = await _RepositoryPattern.UpdateAsync(Id, StudentRequest);

            if (updatedStudent  == null) return NotFound();

            var DTO = _mapper.Map<ResponceStudentDto>(updatedStudent);

            return Ok(DTO);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {

            var deleted = await _RepositoryPattern.DeleteAsync(Id);

            if (!deleted) return NotFound();

            return NoContent();

        }
    }
}