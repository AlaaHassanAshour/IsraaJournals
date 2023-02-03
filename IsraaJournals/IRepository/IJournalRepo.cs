using IsraaJournals.DTOs;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;

namespace IsraaJournals.IRepository
{
    public interface IJournalRepo
    {
        Task<List<JournalVM>> GetAll();
        Task<Journal> GetBtId(int id);
        Task<JournalDTO> Add(JournalDTO model);
        Task<Journal> Update(int id, Journal model);
        Task<bool> Delete(int id);
    }
}
