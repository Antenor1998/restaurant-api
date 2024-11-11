
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant> {
	public void Configure(EntityTypeBuilder<Tenant> builder) {
		builder.HasKey(t => t.Id);
		builder.Property(t => t.Name).IsRequired();
		builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
		builder.Property(t => t.Domain).IsRequired().HasMaxLength(50);
		builder.Property(t => t.Status).IsRequired();
		builder.Property(t => t.CreatedAt).HasDefaultValueSql("NOW()");

		builder.HasMany(t => t.Subscriptions)
				.WithOne(s => s.Tenant)
				.HasForeignKey(s => s.TenantId);
	}
}
