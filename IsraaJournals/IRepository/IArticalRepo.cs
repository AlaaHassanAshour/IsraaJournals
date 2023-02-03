using IsraaJournals.DTOs;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;

namespace IsraaJournals.IRepository
{
    public interface IArticalRepo
    {
        Task<List<ArticleVM>> GetAll();
        Task<Article> GetBtId(int id);
        Task<ArticleDTO> Add(ArticleDTO model);
        Task<Article> Update(int id, Article model);
        Task<bool> Delete(int id);
    }
}
