using System.ComponentModel.DataAnnotations.Schema;

namespace IsraaJournals.Models
{
    public class Manuscript
    {
        public int Id { get; set; }
      //  public string file { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
        public string title { get; set; }
        public string Abstract { get; set; }
        public string Keyword { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfAuthor { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        public int? RecarcheTypeId { get; set; }
        public RecarcheType RecarcheType { get; set; }
        [ForeignKey("AppUser")]
        public string? AutherId { get; set; }
        public AppUser Auther { get; set; }

        public List<Author> Authors { get; set; }
        public List<ExcludeReviwer> ExcludeReviwers { get; set; }
        public List<SuggestReivewr> SuggestReivewrs { get; set; }
    }
}