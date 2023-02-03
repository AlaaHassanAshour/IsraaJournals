using IsraaJournals.Data;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsraaJournals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecercheTypeController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public RecercheTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> GetAll()
        {
            var recarcheTypes =await _context.RecarcheTypes.ToListAsync();
            return Ok(recarcheTypes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RecarcheType model)
        {

            _context.RecarcheTypes.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _context.RecarcheTypes.FindAsync(id);
            _context.RecarcheTypes.Remove(section);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
