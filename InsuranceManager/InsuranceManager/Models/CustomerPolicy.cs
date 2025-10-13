using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class CustomerPolicy
    {
        [Key]
        public string? PolicyType { get; set; }

    }
}
