using IsraaJournals.ViewModel;

namespace IsraaJournals.IRepository
{
    public interface IRoleRepo
    {
      
            Task  InitRole();
            List<RoleVM> Index();

   
    }
}
