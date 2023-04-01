namespace eCommerce.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }

        // Column - MER
        // [ForeignKey("User")] --> FK(POO Property)
        public int UserId { get; set; }

        // POO - Navigation purpose
        // [ForeignKey("UserId")] --> UserId (MER-Column)
        public User? User { get; set; }
    }
}