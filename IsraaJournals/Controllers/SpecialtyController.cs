using IsraaJournals.IRepository;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsraaJournals.Controllers
{
    public class SpecialtyController : BaseController
    {
        private readonly ISpecialtyRepo _repo;

        public SpecialtyController(ISpecialtyRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetBtId(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(Specialty model)
        {

            if (ModelState.IsValid)
            {
                await _repo.Add(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Specialty model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _repo.Update(id, model);
                return Ok("Done");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            return Ok(await _repo.Delete(id));
        }

    }
}
