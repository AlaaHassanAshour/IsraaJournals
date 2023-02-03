using AutoMapper;
using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace IsraaJournals.Repository
{
    public class JournalRepo: IJournalRepo
    {
        private readonly ApplicationDbContext _context;
         private readonly IMapper _mapper;

        public JournalRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
                _mapper = mapper;
        }
        public async Task<JournalDTO> Add(JournalDTO model)
        {
            var Journal = _mapper.Map<Journal>(model);
            Journal.insertDate = DateTime.Now;
            await _context.Journals.AddAsync(Journal);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var Journal = await _context.Journals.FindAsync(id);
            _context.Journals.Remove(Journal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<JournalVM>> GetAll()
        {
            return await _context.Journals.Include(x => x.Admin).Select(x=>new JournalVM()
            {
                Admin = new AppUserVM()
                {
                    FirstName=x.Admin.FirstName,
                    LastName=x.Admin.LastName,
                },
                Id = x.Id,
                insertDate=x.insertDate,
                Name=x.Name,
                prefix=x.prefix
                
            }).ToListAsync();
        }

        public async Task<Journal> GetBtId(int id)
        {
            return await _context.Journals.FindAsync(id);
        }
        public async Task<Journal> Update(int id, Journal model)
        {
            var Journal = await _context.Journals.FindAsync(id);
            Journal.Name = model.Name;
            Journal.prefix = model.prefix;
            Journal.AdminId= model.AdminId;
            _context.Journals.Update(Journal);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
