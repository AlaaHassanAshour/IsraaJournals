using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsraaJournals.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticalRepo _repo;
        private readonly ApplicationDbContext _context;

        public ArticleController(IArticalRepo repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
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
        public async Task<IActionResult> Add(ArticleDTO model)
        {
            await _repo.Add(model);
            return Ok(model);
        }
     
        [HttpGet("changeStatus")]
        public async Task<IActionResult> changeStatus(ArtivalStutas status, int id)
        {
            //  var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var stutasUser = _context.Articles.SingleOrDefault(x => x.Id == id);
            if (stutasUser == null)
            {
                return NotFound();
            }
            else
            {
                stutasUser.ArtivalStutass = status;
                _context.Update(stutasUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
  

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Article model)
        {

            await _repo.Update(id, model);

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return Ok();
        }
    }
}
