using System;
using System.ComponentModel.DataAnnotations;


namespace HRBMS.Models
{

    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [StringLength(100)]
        public string RoomType { get; set; } // Optional: Room type (e.g., Deluxe, Suite) I'll make this an enum later

        [StringLength(500)]
        public string Notes { get; set; } 

        public bool IsConfirmed { get; set; }
    }

}