using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleManagement.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(50)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Display(Name = "Last Maintenance Date")]
        [DataType(DataType.Date)]
        public DateTime? LastMaintenanceDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
