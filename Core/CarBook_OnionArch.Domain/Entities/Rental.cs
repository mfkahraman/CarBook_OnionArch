using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBook_OnionArch.Domain.Entities
{
    public class Rental : IEntity
    {
        [Key]
        public int Id { get; set; }

        //Car Realation
        [Required]
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car? Car { get; set; }

        //User Realation
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        //Rental Dates
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        //Locations
        [Required]
        public int PickUpLocationId { get; set; }
        public Location? PickUpLocation { get; set; }
        [Required]
        public int DropOffLocationId { get; set; }
        public Location? DropOffLocation { get; set; }

        //Prices
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        // Status
        public string? Status { get; set; }
        // Logging
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
