using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant> {
	public void Configure(EntityTypeBuilder<Tenant> builder) {
		builder.ToTable("Tenants", TenantDbContext.DEFAULT_SCHEMA );

		builder.HasKey(t => t.Id);
		
		builder.Property(t => t.Id).HasColumnName("id");
		builder.Property(t => t.Name).IsRequired().HasColumnName("name");
		builder.Property(t => t.SubscriptionId).HasColumnName("subscription_id");
		builder.Property(t => t.BusinessName).IsRequired().HasColumnName("business_name");
		builder.Property(t => t.DatabaseConnectionString).IsRequired().HasColumnName("database_connection_string");
		builder.Property(t => t.Status).IsRequired().HasColumnName("status");
		builder.Property(t => t.CreatedAt).HasColumnName("created_at");
		builder.Property(t => t.TrialEndsAt).HasColumnName("trial_ends_at");

		builder.HasData(
			// new Tenant { Id = 1, Name = "WerSoft", BusinessName = "WerSOft S.A de C.V", DatabaseConnectionString = "werSoft", Status = 1, CreatedAt = DateTime.Now, TrialEndsAt = DateTime.Now.AddMonths(1) }
		);
	}
}
