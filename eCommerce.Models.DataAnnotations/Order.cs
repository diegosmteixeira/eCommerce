using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Order
    {
        //Order.Customer.Name
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Supervisor")]
        public int SupervisorId { get; set; }

        public User? Customer { get; set; }
        public User? Employee { get; set; }
        public User? Supervisor { get; set; }
    }
}