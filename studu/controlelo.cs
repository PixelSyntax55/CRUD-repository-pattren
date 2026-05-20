using Microsoft.AspNetCore.Mvc;
using lastoneapi.repo;
using lastoneapi.studu;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace lastoneapi.controlelo
{
    [ApiController]
    [Route("api/[Controller]")]
    public class controlelo : ControllerBase
    {

        private readonly repo2 _repo;

        public controlelo(repo2 repo)

        {

            _repo = repo;

        }

        // get 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var jk = await _repo.GetAllAsync();

            return Ok(jk);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var jk =  _repo.GetByIdAsync(id);

            if (jk == null) return NotFound();   

            return Ok(jk);

        }

        [HttpPost]
        public async Task<IActionResult> Create(input input) 
        {
        
            var jk = await _repo.CreateAsync(input);

            return CreatedAtAction ( nameof (GetById) , new { id = jk.id } , jk);

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> update(int id ,input input)
        {
            var jk = await _repo.UpdateAsync(id , input);

            if (jk == null) return NotFound();

            return Ok(jk);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {

            var jk =  _repo.DeleteAsync(id);

            if (jk == null) return NotFound();

            return NoContent();  

        }
    }
}
    