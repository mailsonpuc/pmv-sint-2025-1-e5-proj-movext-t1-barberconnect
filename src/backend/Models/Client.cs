namespace backend.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Phone { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
