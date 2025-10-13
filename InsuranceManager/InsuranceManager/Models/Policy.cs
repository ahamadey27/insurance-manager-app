using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class Policy
    {
        [Key]
        public int PolicyNumber { get; set; }

    }
}
