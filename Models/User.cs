namespace VehicleManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        // Navigation property (optional but useful)
        public ICollection<Vehicle>? Vehicles { get; set; }

    }
}