using System.ComponentModel.DataAnnotations; //used to provide EF Core with metadata about the database schema

namespace InsuranceManager.Models
{
    public class Customer
    {
        [Key] //Assigns primary key
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CustomerPhotoUrl { get; set; }

        //Navigation property for the many-to-many relationships
        public ICollection<CustomerPolicy> CustomerPolicies { get; set; }
    }
}
