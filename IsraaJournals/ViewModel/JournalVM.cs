using IsraaJournals.Models;

namespace IsraaJournals.ViewModel
{
    public class JournalVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUserVM Admin { get; set; }
        public string prefix { get; set; }
        public DateTime insertDate { get; set; } = DateTime.Now;
    }
}
