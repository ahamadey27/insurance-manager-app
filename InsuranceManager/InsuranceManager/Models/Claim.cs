using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }
    }
}
