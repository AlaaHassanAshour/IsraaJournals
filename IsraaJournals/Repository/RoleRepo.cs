using IsraaJournals.Data;
using IsraaJournals.IRepository;
using IsraaJournals.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace IsraaJournals.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RoleRepo(RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _db = db;
        }
        public List<RoleVM> Index()
        {
            var data = _db.Roles.Select(x => new RoleVM() { Name = x.Name }).ToList();
            return data;
        }
        public async Task InitRole()
        {
            var role = new List<string>();
            role.Add("Author");
            role.Add("Reviewer");
            role.Add("Editor");
            role.Add("Publisher");
            role.Add("Admin");
            foreach (var item in role)
            {
                await _roleManager.CreateAsync(new IdentityRole(item));
            }
        }
    
    }
}
