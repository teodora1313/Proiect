using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "First name must start with capital letter.")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Trainer First Name")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Last name must start with capital letter.")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Trainer Last Name")]
        public string? LastName { get; set; }

        [RegularExpression(@"^\(?([0]{1})?([1-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage =
            "Phone number needs to start with 0 and have the format '0722-123-123' or '0722.123.123' or '0722 123 123'")]
        public string? Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage =
            "Email must be in a valid format like 'example@domain.com'")]
        public string? Email { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Specialty { get; set; }

        [Display(Name = "Trainer Name")]
        public string TrainerName => String.Concat(FirstName, " ", LastName);

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
