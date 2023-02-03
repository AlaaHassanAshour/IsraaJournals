using IsraaJournals.DTOs;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;

namespace IsraaJournals.IRepository
{
    public interface IVolumeRepo
    {
        Task<List<VolumeVM>> GetAll();
        Task<Volume> GetBtId(int id);
        Task<VolumeDTO> Add(VolumeDTO model);
        Task<Volume> Update(int id, Volume model);
        Task<bool> Delete(int id);
    }
}
