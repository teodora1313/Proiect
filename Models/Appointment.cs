using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment date and time")]
        public DateTime AppointmentTime { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
    }
}
