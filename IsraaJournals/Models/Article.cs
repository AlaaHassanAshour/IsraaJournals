using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsraaJournals.Models
{
    public class Article
    {

        public int Id { get; set; }
        [StringLength(400)]
        public string Title { get; set;}
        [ForeignKey("AppUser")]
        public string AutherId { get; set; }
        public AppUser Auther { get; set; }
        public int VolumeId { get; set; }
        public Volume Volume { get; set; }
        public ArtivalStutas ArtivalStutass { get; set; }
      

    }
   public enum ArtivalStutas
    {
        pandind,
        inPgroress,
        finshed
    }
}
