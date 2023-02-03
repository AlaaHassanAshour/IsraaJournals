using IsraaJournals.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace IsraaJournals.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleRepo _roleService;
        public RoleController(IRoleRepo roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var role = _roleService.Index();
            return Ok(role);
        }
        [HttpPost]

        public async Task<IActionResult> InitRole()
        {
            await _roleService.InitRole();
            return Ok(_roleService.Index());
        }
    }
}
