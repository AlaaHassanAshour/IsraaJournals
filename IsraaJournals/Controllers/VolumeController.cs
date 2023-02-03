using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsraaJournals.Controllers
{
    public class VolumeController : BaseController
    {
        private readonly IVolumeRepo _repo;
        //private readonly IArticalRepo _articalrepo;
        //private readonly IJournalRepo _Jornalrepo;

        public VolumeController(IVolumeRepo repo)
        {
            _repo = repo;
            //_Jornalrepo = Jornalrepo;
            //_articalrepo = articalrepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetBtId(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(VolumeDTO model)
        {
            await _repo.Add(model);
            return Ok(model);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Volume model)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            return Ok(await _repo.Update(id, model));

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            return Ok(await _repo.Delete(id));
        }
    }
}
