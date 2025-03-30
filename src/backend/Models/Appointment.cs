namespace backend.Models
{
    public class Appointment
    {   
        public int Id { get; set; }

        public int BarberId { get; set; }
        
        public Barber Barber { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime DateTime { get; set; }


        public Review? Review { get; set; }
    }
}
