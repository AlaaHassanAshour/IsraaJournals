namespace IsraaJournals.Models
{
    public class FileMans
    {
        public int Id{ get; set; }
        public string file{ get; set; }
        public int ManuscriptId { get; set; }
        public Manuscript Manuscript { get; set; }
    }
}
