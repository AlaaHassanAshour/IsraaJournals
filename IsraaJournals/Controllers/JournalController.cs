using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsraaJournals.Controllers
{
    public class JournalController : BaseController
    {
        private readonly IJournalRepo _repo;

        public JournalController(IJournalRepo repo, IUserRepo userRepo)
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
        public async Task<IActionResult> Add(JournalDTO model)
        {

            await _repo.Add(model);
            return Ok(model);
            //ViewData["AdminId"] = new SelectList(_context.Users, "Id", "Id", journal.AdminId);
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Journal model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
               
                return Ok(await _repo.Update(id, model));
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
