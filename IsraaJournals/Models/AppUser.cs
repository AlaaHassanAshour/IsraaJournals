using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IsraaJournals.Models
{
    public class AppUser :IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Degree{ get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        [StringLength(100)]
        public string Mobile{ get; set; }
        [StringLength(100)]
        public string HomePage{ get; set; }
        [StringLength(100)]
        public string PostlCode{ get; set; }
        [StringLength(100)]
        public string Address{ get; set; }
        [StringLength(100)]
        public string Affiliation { get; set; }
        [StringLength(500)]
        public string Comments { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }= DateTime.Now;

    }
}
