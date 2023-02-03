using IsraaJournals.Data;
using IsraaJournals.IRepository;
using IsraaJournals.Models;
using Microsoft.EntityFrameworkCore;

namespace IsraaJournals.Repository
{
    public class SpecialtyRepo : ISpecialtyRepo
    {
        private readonly ApplicationDbContext _context;
        // private readonly IMapper _mapper;

        public SpecialtyRepo(ApplicationDbContext context)
        {
            _context = context;
            //    _mapper = mapper;
        }
        public async Task<Specialty> Add(Specialty model)
        {
            //var addres = _mapper.Map<Specialty>(model);
            await _context.Specialtys.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var Specialty = await _context.Specialtys.FindAsync(id);
            _context.Specialtys.Remove(Specialty);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Specialty>> GetAll()
        {
            return await _context.Specialtys.ToListAsync();
        }

        public async Task<Specialty> GetBtId(int id)
        {
            return await _context.Specialtys.FindAsync(id);
        }
        public async Task<Specialty> Update(int id, Specialty model)
        {
            var Specialty = await _context.Specialtys.FindAsync(id);
            Specialty.Name = model.Name;
            _context.Specialtys.Update(Specialty);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
