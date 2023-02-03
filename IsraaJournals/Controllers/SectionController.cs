using IsraaJournals.Data;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsraaJournals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public SectionController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var section =await _context.Sections.ToListAsync();
            return Ok(section);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Section model)
        {

           _context.Sections.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var section =await _context.Sections.FindAsync(id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
