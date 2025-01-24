using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Membership Type")]
        public string? Type { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.00, 3000)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
