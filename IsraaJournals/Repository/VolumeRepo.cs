using AutoMapper;
using IsraaJournals.Data;
using IsraaJournals.DTOs;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace IsraaJournals.Repository
{
    public class VolumeRepo : IVolumeRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VolumeRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VolumeDTO> Add(VolumeDTO model)
        {
            var volume = _mapper.Map<Volume>(model);
            await _context.Volumes.AddAsync(volume);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<bool> Delete(int id)
        {
            var Volume = await _context.Volumes.FindAsync(id);
            _context.Volumes.Remove(Volume);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<VolumeVM>> GetAll()
        {
            return await _context.Volumes.Include(x => x.Journal).Select(X=>new VolumeVM()
            {
                Name=X.Name,
                insertDate=X.insertDate,
                Id=X.Id,
             
                Journal=new JournalVM()
                {
                    Name =X.Journal.Name,
                }
            }).ToListAsync();
        }

        public async Task<Volume> GetBtId(int id)
        {
            return await _context.Volumes.FindAsync(id);
        }
        public async Task<Volume> Update(int id, Volume model)
        {
            var Volume = await _context.Volumes.FindAsync(id);
            Volume.Name = model.Name;
           
            Volume.JournalId = model.JournalId;
            _context.Volumes.Update(Volume);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
