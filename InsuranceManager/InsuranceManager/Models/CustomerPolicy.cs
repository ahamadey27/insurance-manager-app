using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class CustomerPolicy
    {
        // FK to Customer
        public int CustomerId { get; set; }

        // FK to Policy (PolicyNumber is PK on Policy)
        public int PolicyNumber { get; set; }

        // Reference navigation properties (use null-forgiving if nullable refs enabled)
        public Customer Customer { get; set; } = null!;
        public Policy Policy { get; set; } = null!;



    }
}
