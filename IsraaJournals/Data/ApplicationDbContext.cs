using IsraaJournals.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IsraaJournals.ViewModel;

namespace IsraaJournals.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }
        public DbSet<JorSpecialty> JorSpecialtys { get; set; }
        public DbSet<Manuscript> Manuscript { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<RecarcheType> RecarcheTypes { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<ExcludeReviwer> ExcludeReviwer { get; set; }
        public DbSet<SuggestReivewr> SuggestReivewr { get; set; }
        public DbSet<FileMans> File { get; set; }
        public DbSet<IsraaJournals.ViewModel.RoleVM> RoleVM { get; set; }
    }
}