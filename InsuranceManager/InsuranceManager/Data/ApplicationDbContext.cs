using InsuranceManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InsuranceManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for join entity (CustomerId + PolicyNumber)
            modelBuilder.Entity<CustomerPolicy>()
                .HasKey(cp => new { cp.CustomerId, cp.PolicyNumber });

            // CustomerPolicy -> Customer (one Customer, many CustomerPolicies)
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPolicies) // requires Customer.CustomerPolicies
                .HasForeignKey(cp => cp.CustomerId);

            // CustomerPolicy -> Policy (one Policy, many CustomerPolicies)
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.Policy)
                .WithMany(p => p.CustomerPolicies) // requires Policy.CustomerPolicies
                .HasForeignKey(cp => cp.PolicyNumber);

            base.OnModelCreating(modelBuilder);
        }
    }   
}
