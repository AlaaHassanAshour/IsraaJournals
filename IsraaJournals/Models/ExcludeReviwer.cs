namespace IsraaJournals.Models
{
    public class ExcludeReviwer
    {
        public int Id{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string Affiliation{ get; set; }
        public int ManuscriptId { get; set; }
        public Manuscript Manuscript { get; set; }
    }
}
