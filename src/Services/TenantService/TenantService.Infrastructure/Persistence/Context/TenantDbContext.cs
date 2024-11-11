using Microsoft.EntityFrameworkCore;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Context;

public class TenantDbContext : DbContext {
	public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

	public DbSet<Tenant> Tenants { get; set; }
	public DbSet<Subscription> Subscriptions { get; set; }

	 protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
	}

}
