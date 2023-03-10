namespace IsraaJournals.Models
{
    public class Author
    {
        public int Id{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Title{ get; set; }
        public string Country{ get; set; }
        public string CorrespoindingAuthor{ get; set; }
        public string Affillation{ get; set; }
        public string? HomePage{ get; set; }
        public string? Biography{ get; set; }
        public string? Linkprofile{ get; set; }
        public string? Twitter{ get; set; }
        public int? ManuscriptId { get; set; }
        public Manuscript Manuscript { get; set; }
    }
}
