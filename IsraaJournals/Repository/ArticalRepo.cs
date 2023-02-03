using AutoMapper;
using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace IsraaJournals.Repository
{
    public class ArticalRepo : IArticalRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ArticalRepo(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public async Task<ArticleDTO> Add(ArticleDTO model)
        {

            var article = _mapper.Map<Article>(model);
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<ManuscriptDTO> SubmitMansucrpit(ManuscriptDTO model)
        {

            //string fileName = null;
            //if (model.file != null && model.file.Length > 0)
            //{
            //    var uploads = Path.Combine(_env.WebRootPath, "File");
            //    Replace to format only
            //    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.file.FileName);
            //    await using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
            //    await model.file.CopyToAsync(fileStream);
            //}
            //var Manuscript = new Manuscript()
            //{
            //    ArticleId = model.ArticleId,
            //    file = fileName,
            //};

           // _context.Manuscript.Add(Manuscript);
            await _context.SaveChangesAsync();
            return model;
        }
   
        public async Task<bool> Delete(int id)
        {
            var Article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(Article);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ArticleVM>> GetAll()
        {
            var artical = await _context.Articles.Include(x => x.Auther)
                .Select(x => new ArticleVM()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArtivalStutass = x.ArtivalStutass,
                    Auther = new AppUserVM()
                    {
                        FirstName = x.Auther.FirstName,
                        LastName = x.Auther.LastName,
                    },
                    Volume = new VolumeVM()
                    {
                        Name = x.Volume.Name,
                    }
                }).ToListAsync();
            return artical;

        }
        public async Task<Article> GetBtId(int id)
        {
            return await _context.Articles.FindAsync(id);
        }
        public async Task<Article> Update(int id, Article model)
        {
            var Article = await _context.Articles.FindAsync(id);
            Article.AutherId = model.AutherId;
            Article.Title = model.Title;
            Article.ArtivalStutass = model.ArtivalStutass;
            _context.Articles.Update(Article);
            await _context.SaveChangesAsync();
            return model;
        }

       
    }
}
