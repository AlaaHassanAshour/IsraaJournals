using IsraaJournals.Data;
using IsraaJournals.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IsraaJournals.Models;
using Microsoft.EntityFrameworkCore;
using IsraaJournals.Services.File;
using IsraaJournals.Services.Email;
using IsraaJournals.DTOs;

namespace IsraaJournals.Controllers
{
    public class ManuscriptController : BaseController
    {
        private readonly IMailHelper _mailService;
        private readonly ApplicationDbContext _context;
        private readonly IFileServises _fileServises;
        private static int micId;

        public ManuscriptController(IMailHelper mailService, ApplicationDbContext context, IFileServises fileServises)
        {
            _mailService = mailService;
            _context = context;
            _fileServises = fileServises;
        }
        [HttpPost("AddAuthors")]
        public async Task<IActionResult> Authors(List<AuthorDTO> authors)
        {
            foreach (var authorDto in authors)
            {
                var author = new Author()
                {
                    Affillation = authorDto.Affillation,
                    Biography = authorDto.Biography,
                    CorrespoindingAuthor = authorDto.CorrespoindingAuthor,
                    Country = authorDto.Country,
                    FirstName = authorDto.FirstName,
                    HomePage = authorDto.HomePage,
                    LastName = authorDto.LastName,
                    Linkprofile = authorDto.Linkprofile,
                    Title = authorDto.Title,
                    Twitter = authorDto.Twitter,
                    ManuscriptId = micId
                };
                _context.Author.Add(author);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpPost("AddFile")]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var files = await _fileServises.UploadImageAsync(file);
            FileMans fileMans = new FileMans()
            {
                file = files,
                ManuscriptId = micId

            };
            await _context.AddAsync(fileMans);
            await _context.SaveChangesAsync();
            string url = "https://localhost:7116//File/" + files;
            string body = $"Add Submit Mansucrpit,<a href={url}>Click here</a>";
            try
            {
                await _mailService.SendEmailAsync(new InputEmailMessage()
                {
                    Body = String.Format("Israa Jornal:Add Submit Mansucrpit {0:C2} from {1} ",
                    body, user.FirstName + user.LastName),
                    Subject = "Add Submit Mansucrpit",
                    ToEmail = "a0592437455@gmail.com"

                });
            }
            catch (Exception e)
            {

                throw;
            }
            return Ok();
        }
        [HttpPost("SuggestReivewr")]
        public async Task<IActionResult> SuggestReivewr(List<SuggestReivewrDTO> model)
        {
            foreach (var suggestReivewrDTO in model)
            {
                var suggestReivewr = new SuggestReivewr()
                {
                    Affiliation = suggestReivewrDTO.Affiliation,
                    Email = suggestReivewrDTO.Email,
                    FirstName = suggestReivewrDTO.FirstName,
                    LastName = suggestReivewrDTO.LastName,
                    ManuscriptId = micId,
                };
                _context.SuggestReivewr.Add(suggestReivewr);
                await _context.SaveChangesAsync();

            }
            return Ok();
        }
        [HttpPost("ExcludeReviwer")]
        public async Task<IActionResult> ExcludeReviwer(List<ExcludeReviwerDTO> model)
        {
            foreach (var excludeReviwerDTO in model)
            {
                var excludeReviwer = new ExcludeReviwer()
                {
                    Affiliation = excludeReviwerDTO.Affiliation,
                    Email = excludeReviwerDTO.Email,
                    FirstName = excludeReviwerDTO.FirstName,
                    LastName = excludeReviwerDTO.LastName,
                    ManuscriptId = micId,
                };
                _context.ExcludeReviwer.Add(excludeReviwer);
                await _context.SaveChangesAsync();

            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitMansucrpit([FromForm] ManuscriptDTO model)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            var manuscript = new Manuscript()
            {
                ArticleId = model.ArticleId,
                Abstract = model.Abstract,
                JournalId = model.JournalId,
                Keyword = model.Keyword,
                NumberOfAuthor = model.NumberOfAuthor,
                NumberOfPage = model.NumberOfPage,
                title = model.title,
                // file = files,
                AutherId = userId,
                SectionId = model.SectionId,
                RecarcheTypeId = model.RecarcheTypeId,
            };
            _context.Manuscript.Add(manuscript);
            await _context.SaveChangesAsync();
            micId = manuscript.Id;
            return Ok(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetMansucrpit()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

            var mansucrpit = await _context.Manuscript.Where(x => x.AutherId == userId).Select(x => new ManuscriptVM()
            {
                Id = x.Id,   
                Article = new ArticleVM()
                {
                    Title = x.Article.Title,
                    Auther = new AppUserVM()
                    {
                        FirstName = x.Article.Auther.FirstName,
                    },
                }
            }).ToListAsync();
            return Ok(mansucrpit);
        }
        [HttpGet("GetMansucrpittoEditor")]
        public async Task<IActionResult> GetMansucrpittoEditor()
        {

            var mansucrpit = await _context.Manuscript.Select(x => new ManuscriptVM()
            {
                Id = x.Id,
                Article = new ArticleVM()
                {
                    Auther = new AppUserVM()
                    {
                        FirstName = x.Article.Auther.FirstName,
                    },
                    Title = x.Article.Title,
                }

            }).ToListAsync();
            return Ok(mansucrpit);
        }
    }
}