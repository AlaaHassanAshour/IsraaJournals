namespace IsraaJournals.DTOs
{
    public class ManuscriptDTO
    {
        public int ArticleId { get; set; }
        public int? RecarcheTypeId { get; set; }
        public int? SectionId { get; set; }
        public int JournalId { get; set; }
        public string title { get; set; }
        public string Abstract { get; set; }
        public string Keyword { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfAuthor { get; set; }

    }
}
