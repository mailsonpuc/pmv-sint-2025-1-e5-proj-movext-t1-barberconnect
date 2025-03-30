namespace backend.Models
{
    public class Barber
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
