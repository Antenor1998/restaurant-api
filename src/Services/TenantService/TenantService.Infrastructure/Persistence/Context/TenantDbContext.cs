using Microsoft.EntityFrameworkCore;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Context;

public class TenantDbContext : DbContext {
	public const string DEFAULT_SCHEMA = "tenant";
	public const string BILLING_SCHEMA = "billing";

	public DbSet<Feature> Features { get; set; }
	public DbSet<Plan> Plans { get; set; }
	public DbSet<PlanFeature> PlanFeatures { get; set; }
	public DbSet<AddOn> AddOns { get; set; }
	public DbSet<AddOnFeature> AddOnFeatures { get; set; }
	public DbSet<Pricing> Pricings { get; set; }
	public DbSet<TenantSubscription> Subscriptions { get; set; }

	public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
		modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
		
		
	}

}
