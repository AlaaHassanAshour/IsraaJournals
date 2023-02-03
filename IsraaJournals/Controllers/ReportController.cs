using IsraaJournals.ViewModel;
using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AspNetCore.Reporting;
using System.Data;

namespace IsraaJournals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult RDLC(int id)
        {
            #region
            var model = _context.Manuscript.Include(x => x.Auther)
                .Include(x => x.SuggestReivewrs)
                .Include(x => x.Auther)
                .Include(x => x.Section)
                .Include(x => x.RecarcheType)
                .Include(x => x.Article)
                .Include(x => x.Journal)
                .Include(x => x.ExcludeReviwers)
                .Include(x => x.Authors)
                .Select(x => new ManuscriptVM()
                {
                    Id = x.Id,
                    Abstract = x.Abstract,
                    NumberOfAuthor = x.NumberOfAuthor,
                    NumberOfPage = x.NumberOfPage,
                    title = x.title,
                    Keyword = x.Keyword,
                    appUser = new AppUserVM()
                    {
                        FirstName = x.Auther.FirstName
                    },
                    RecarcheType = new RecarcheType()
                    {
                        Name = x.RecarcheType.Name,
                    },
                    Section = new Section()
                    {
                        Name = x.Section.Name,
                    },
                    Journal = new JournalDTO()
                    {
                        Name = x.Journal.Name,
                    },
                    Article = new ArticleVM()
                    {
                        Title = x.Article.Title,
                    },
                    Authors = x.Authors.Select(y => new AuthorDTO()
                    {
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Affillation = y.Affillation,
                        Biography = y.Biography,
                        CorrespoindingAuthor = y.CorrespoindingAuthor,
                        Country = y.Country,
                        HomePage = y.HomePage,
                        Linkprofile = y.Linkprofile,
                        Title = y.Title,
                        Twitter = y.Twitter,

                    }).ToList(),
                    SuggestReivewrs = x.SuggestReivewrs.Select(y => new SuggestReivewrDTO()
                    {
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Affiliation = y.Affiliation,
                        Email = y.Email,

                    }).ToList(),
                    ExcludeReviwers = x.ExcludeReviwers.Select(y => new ExcludeReviwerDTO()
                    {
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        Affiliation = y.Affiliation,
                        Email = y.Email,

                    }).ToList(),
                })
                .FirstOrDefault(x => x.Id == id);

            #endregion

            Manuscript manuscript = new Manuscript()
            {
                Id = model.Id,
                Abstract = model.Abstract,
                ArticleId = 5,
                NumberOfAuthor = model.NumberOfAuthor,
                AutherId = "sa",
                JournalId = 4,
                Keyword = model.Keyword,
                NumberOfPage = model.NumberOfPage,
                title = model.title,
                RecarcheTypeId = 4,
                SectionId = 5,
            };

            var assamble = Assembly.GetExecutingAssembly();
            var Location = assamble.Location;
            var dictory = Path.GetDirectoryName(Location);
            var path = Path.Combine(dictory, "MunscriptReport.rdlc");
            LocalReport report = new LocalReport(path);
            report.AddDataSource("DataSet2", manuscript);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Logo", "asdasdasdasdasdadsasd");
            var resulat = report.Execute(RenderType.Pdf, parameters: data);
            return File(resulat.MainStream, "application/pdf");
        }

    }
}
