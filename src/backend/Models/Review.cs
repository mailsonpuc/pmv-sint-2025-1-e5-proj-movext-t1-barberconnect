using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        [Range(1,5)]
        public double Score { get; set; }

        public int AppointmentId { get; set; }

        public int BarberId { get; set; }

        public int ClientId { get; set; }


        public Appointment Appointment { get; set; }

        public Barber Barber { get; set; }

        public Client Client { get; set; }
    }
}
