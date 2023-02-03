using System.ComponentModel.DataAnnotations;
namespace IsraaJournals.Models
{
    public class Volume
    {
        public int Id{ get; set; }
        [StringLength(100)]
        public string Name{ get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
        public DateTime insertDate { get; set; }
    }
}