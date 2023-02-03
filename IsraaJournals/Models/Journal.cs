using System.ComponentModel.DataAnnotations.Schema;

namespace IsraaJournals.Models
{
    public class Journal
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        [ForeignKey("AppUser")]
        public string AdminId{ get; set; }
        public AppUser Admin { get; set; }
        public string  prefix{ get; set; }
        public DateTime insertDate{ get; set; }=DateTime.Now;
    }
}
