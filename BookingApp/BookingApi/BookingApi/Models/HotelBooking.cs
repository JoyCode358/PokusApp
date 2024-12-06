using System.ComponentModel.DataAnnotations;

namespace BookingApi.Models
{
    public class HotelBooking
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public string? ClientsName { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; }
    }
}
