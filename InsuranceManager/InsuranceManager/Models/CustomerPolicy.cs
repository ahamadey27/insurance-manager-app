using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class CustomerPolicy
    {
        // Composite key will be configured in ApplicationDbContext
        public int CustomerId { get; set; }
        public int PolicyNumber { get; set; }

        // Navigation properties
        public Customer Customer { get; set; } = null!;
        public Policy Policy { get; set; } = null!;



    }
}
