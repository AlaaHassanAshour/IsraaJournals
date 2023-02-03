using IsraaJournals.Models;
using System.ComponentModel.DataAnnotations;

namespace IsraaJournals.ViewModel
{
    public class RegisterVM
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(220)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Degree { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        public int SpecialtyId { get; set; }
        [StringLength(100)]
        public string Mobile { get; set; }
        [StringLength(100)]
        public string HomePage { get; set; }
        [StringLength(100)]
        public string PostlCode { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Affiliation { get; set; }
        [StringLength(500)]
        public string Comments { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string CofiermPassword { get; set; }
    }
}
