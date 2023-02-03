using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using IsraaJournals.Services.Email;
using IsraaJournals.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IsraaJournals.Repository
{
    public class UserRepo : IUserRepo
    {

        private ApplicationDbContext _DB;
        private SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailHelper _mailService;
        public UserRepo(ApplicationDbContext DB, SignInManager<AppUser> signInManager, IMailHelper mailService, UserManager<AppUser> userManager)
        {
            _DB = DB;
            _signInManager = signInManager;
            _userManager = userManager;
            _mailService = mailService;

        }

        public async Task<List<AppUserVM>> GetAll()
        {

            var users = await _DB.Users.Select(x => new AppUserVM()
            {
                FirstName = x.FirstName,
                LastName = x.FirstName,
                Email = x.Email,
                Id = x.Id,


            }).ToListAsync();

            return users;
        }
        public async Task<bool> Create(RegisterVM dto)
        {
            var user = new AppUser()
            {
                Address = dto.Address,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Affiliation = dto.Affiliation,
                Comments = dto.Comments,
                Degree = dto.Degree,
                Mobile = dto.Mobile,
                PhoneNumber = dto.Mobile,
                Position = dto.Position,
                PostlCode = dto.PostlCode,
                HomePage = dto.HomePage,
                SpecialtyId = dto.SpecialtyId,
                UserName = dto.Email,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                //create link for confirmation password
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                //var url = _urlHelper.Action("ConfirmEmail", "Account", new { token = token, user = user.Id },
                //     this option to add domain to url with confirmation token like ourdomai.com / Account / ConfirmEmail


                //    _httpRequest.Scheme);
                // send Email
                string url = $"http://localhost:4200/auth/confirmEmail?token={token}&userId={user.Id}";
                string body = $"to confirm your Email ,you should <a href={url}>Click here</a>";

                //StringBuilder body = new StringBuilder();
                //body.AppendLine("Israa Jornal: Email Confirmation ");
                //body.AppendFormat("to confirm your Email ,you should <a href='{0}>Click here</a>' ",
                //    $"http://localhost:4200/auth/confirmEmail?token={token}&userId={user.Id}");
                try
                {
                    await _mailService.SendEmailAsync(new InputEmailMessage()
                    {
                        Body = String.Format("Israa Jornal: Email Confirmation {0:C2} ",
                        body),
                        Subject = "Email Confirmation Message",
                        ToEmail = dto.Email

                    });
                }
                catch (Exception e)
                {

                    throw;
                }
                await _userManager.AddToRoleAsync(user, "Author");
            }
            return result.Succeeded;
        }
        public async Task<TokenViewModel> Login(LoginDto dto)
        {

            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.email);

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (result.Succeeded)
            {

                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = await GenerateAccessToken(user);

                return token;
            }
            return null;
        }
        //public void Update(UserDto dto, string id)
        //{
        //    var user = _Db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);

        //    var updatedUser = _Mapper.Map<UserDto, Data.Model.User>(dto, user);

        //    _Db.Users.Update(updatedUser);
        //    _Db.SaveChanges();
        //}

        //public UserDto Get(string id)
        //{
        //    var user = _Db.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
        //    var userDto = _Mapper.Map<Data.Model.User, UserDto>(user);
        //    return userDto;
        //}
        private async Task<TokenViewModel> GenerateAccessToken(AppUser user)
        {
            //claim
            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim("UserId", user.Id),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

             };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Secret Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dhdhdfghuytvdayfvyjduvdkbdydvj"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            //Token

            var accessToken = new JwtSecurityToken("https://localhost:7116/",
                "https://localhost:7116/",
                claims,
                expires: expires,
                signingCredentials: credentials
            );
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var response = new TokenViewModel();
            response.token = AccessToken;
            response.expiration = expires;
            return response;
        }

        public async Task<string> userRole(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);

            var roles = await _userManager.GetRolesAsync(user);

            return string.Join(", ", roles);
        }
    }


}

