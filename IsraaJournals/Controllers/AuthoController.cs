using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IsraaJournals.Data;
using Microsoft.AspNetCore.Identity;
using IsraaJournals.Models;

namespace IsraaJournals.Controllers
{
    public class AuthoController : BaseController
    {
        private readonly IUserRepo _repo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AuthoController(IUserRepo repo, ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> Add(RegisterVM user)
        {

            return Ok(await _repo.Create(user));
        }
        [AllowAnonymous]
        [HttpPost("logIn")]
        public async Task<IActionResult> LogIn(LoginDto user)
        {
            var userlogin = await _repo.Login(user);
            return Ok(userlogin);
        }
        [HttpGet("usersRole")]
        public async Task<IActionResult> GetRoleForUser(string UserId)
        {
            return Ok(await _repo.userRole(UserId));
        }
        [HttpGet("UserInfo")]
        public async Task<IActionResult> UserInfo()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var user = _context.Users.Select(x => new
            {
                x.UserName,
                x.FirstName,
                x.Id,
                x.Degree,
                x.HomePage,
                x.Address,
                x.Affiliation,
                x.Comments,
                x.Email,
                x.Mobile,
                x.LastName,
                x.PostlCode,
                x.Position
            }).SingleOrDefault(x => x.Id == userId);
            return Ok(user);
        }
        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {

                    user.EmailConfirmed = true;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    //var result = await _userManager.ConfirmEmailAsync(user, token);
                    //if (!result.Succeeded)
                    //{
                    //    return BadRequest(result.Errors);
                    //}
                }
            }

            return Ok();
        }
    }
}
