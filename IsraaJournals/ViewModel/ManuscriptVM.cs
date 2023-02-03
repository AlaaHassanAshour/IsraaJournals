using IsraaJournals.DTOs;
using IsraaJournals.Models;

namespace IsraaJournals.ViewModel
{
    public class ManuscriptVM
    {
        public int Id{ get; set; }
        public ArticleVM Article { get; set; }
        public AppUserVM appUser{ get; set; }
        public RecarcheType RecarcheType { get; set; }
        public Section Section { get; set; }
        public JournalDTO Journal { get; set; }
        public string title { get; set; }
        public string Abstract { get; set; }
        public string Keyword { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfAuthor { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<ExcludeReviwerDTO> ExcludeReviwers { get; set; }
        public List<SuggestReivewrDTO> SuggestReivewrs { get; set; }

    }
}
