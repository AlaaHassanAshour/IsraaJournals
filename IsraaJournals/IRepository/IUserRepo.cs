using IsraaJournals.DTOs;
using IsraaJournals.Models;
using IsraaJournals.ViewModel;

namespace IsraaJournals.IRepository
{
    public interface IUserRepo
    {
        Task<bool> Create(RegisterVM dto);
        Task<List<AppUserVM>> GetAll();
        Task<TokenViewModel> Login(LoginDto dto);
        Task<string> userRole(string userId);
    }
}
