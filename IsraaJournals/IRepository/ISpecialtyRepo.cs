using IsraaJournals.Models;

namespace IsraaJournals.IRepository
{
    public interface ISpecialtyRepo
    {
        Task<List<Specialty>> GetAll();
        Task<Specialty> GetBtId(int id);
        Task<Specialty> Add(Specialty model);
        Task<Specialty> Update(int id, Specialty model);
        Task<bool> Delete(int id);
    }
}
