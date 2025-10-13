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
        public DbSet<Policy> Policies { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<Claim> Claims { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite primary key for the join entity.
            // EF Core requires this for composite keys — an attribute cannot define a composite key.
            modelBuilder.Entity<CustomerPolicy>()
                .HasKey(cp => new { cp.CustomerId, cp.PolicyNumber });

            // Configure relationship: CustomerPolicy -> Customer
            // - Each CustomerPolicy has one Customer
            // - Each Customer has many CustomerPolicies (the collection)
            // - The FK is CustomerId on CustomerPolicy
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPolicies)
                .HasForeignKey(cp => cp.CustomerId);

            // Configure relationship: CustomerPolicy -> Policy
            // - Each CustomerPolicy has one Policy
            // - Each Policy has many CustomerPolicies (the collection)
            // - The FK is PolicyNumber on CustomerPolicy
            modelBuilder.Entity<CustomerPolicy>()
                .HasOne(cp => cp.Policy)
                .WithMany(p => p.CustomerPolicies)
                .HasForeignKey(cp => cp.PolicyNumber);

            // Call base method last or first (both acceptable) — keeps EF internal mappings intact.
            base.OnModelCreating(modelBuilder);
        }
    }
}
