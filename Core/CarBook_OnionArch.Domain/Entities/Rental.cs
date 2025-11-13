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

        //Customer Realation
        [Required]
        public int CustomerId { get; set; } = 1;
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        //Rental Dates
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        //Locations
        [Required]
        public int PickUpLocationId { get; set; }
        [ForeignKey("PickUpLocationId")]
        public Location? PickUpLocation { get; set; }
        [Required]
        public int DropOffLocationId { get; set; }
        [ForeignKey("DropOffLocationId")]
        public Location? DropOffLocation { get; set; }

        //Prices
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        // Status
        public RentalStatus Status { get; set; } = RentalStatus.Pending;

        // Logging
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public enum RentalStatus
    {
        Pending = 0,
        Active = 1,
        Completed = 2,
        Cancelled = 3
    }
}
