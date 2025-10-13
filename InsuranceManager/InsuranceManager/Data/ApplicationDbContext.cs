using InsuranceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies {get; set;}
        public DbSet<CustomerPolicy> CustomerPolicies { get; set;}
        public DbSet<Claim> Claims { get; set; }
    }
}
