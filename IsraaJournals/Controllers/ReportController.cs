using IsraaJournals.ViewModel;
using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AspNetCore.Reporting;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace IsraaJournals.Controllers
{
    [AllowAnonymous]
   
    public class ReportController : BaseController
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
            List<Manuscript> list = new List<Manuscript>();
            
            Manuscript manuscript = new Manuscript()
            {
                Keyword = model.Keyword,
                Abstract = model.Abstract,
                NumberOfAuthor = model.NumberOfAuthor,
                NumberOfPage = model.NumberOfPage,
                title = model.title,
                ArticleId = model.Article.Id,
                AutherId = model.appUser.Id,
                JournalId = model.Id,
                Id = model.Id,
                RecarcheTypeId= model.RecarcheType.Id,

            };
            list.Add(manuscript);
            #endregion

            if (model!=null)
            {
                var assamble = Assembly.GetExecutingAssembly();
                var Location = assamble.Location;
                var dictory = Path.GetDirectoryName(Location);
                var path = Path.Combine(dictory, "MunscriptReport.rdlc");
                LocalReport report = new LocalReport(path);
                report.AddDataSource("DataSet1", model.Authors);
                report.AddDataSource("DataSet2", model.SuggestReivewrs);
                report.AddDataSource("DataSet3", model.ExcludeReviwers);
                report.AddDataSource("DataSet4", list);
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("Logo", "RDLC report");
                var resulat = report.Execute(RenderType.Pdf, parameters: parameters);
                return File(resulat.MainStream, "application/pdf");
            }

              return Ok(list);
            }
     

        
        }

    }
