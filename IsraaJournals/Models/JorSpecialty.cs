namespace IsraaJournals.Models
{
    public class JorSpecialty
    {
        public int Id{ get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}
