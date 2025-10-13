using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class Policy
    {

        // This property is treated as the primary key by convention.
        // You named it PolicyNumber — that's fine as long as it's unique.
        [Key]
        public int PolicyNumber { get; set; }

        // Optional: expose the reverse navigation so Policy knows its CustomerPolicies.
        // This is recommended so the relationship is fully navigable from both sides.
        public ICollection<CustomerPolicy> CustomerPolicies { get; set; } = new List<CustomerPolicy>();

    }
}
